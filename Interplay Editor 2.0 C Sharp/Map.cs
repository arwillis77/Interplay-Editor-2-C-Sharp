using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interplay_Editor_2_C_Sharp.Classes;

namespace Interplay_Editor_2_C_Sharp
{
    public class Map
    {
        public int mapID;
        //public int buildingID;
        public string mapFile;
        //public int mapFrame;
        //public int mapAnimFrame;
        //public int mapFade;
        public int mapWidth;
        public int mapHeight;
        //public int mapLastX;
        //public int mapLastY;
        //public int mapClimbMode;
        public int[,] MapDesc;
        Palette MapPalette;
        public int loadedMapDesc;
        public int loadedMapGraphics;
       
        public Map()
        {
            MapDesc = new int[MapConstants.MapWidth,MapConstants.MapHeight];
            loadedMapGraphics = -1;
            loadedMapDesc = -1;
        }

        // Get values from the GameMaps integer array.  
        private int GameMapsGetDescValue(int index)
        {
            int m_value;
            m_value = MapConstants.GameMaps[index,0];
            return m_value;
        }
        int GameMapsGetTextHotValue(int index)
        {
            int m_value;
            m_value = MapConstants.GameMaps[index,1];
            return m_value;
        }

        int GameMapsGetGraphicsValue(int index)
        {
            int m_value;
            m_value = MapConstants.GameMaps[index,2];
            return m_value;
        }

        public static byte [] GetTileData(string filename)
        {
            byte[] result;
            long fs;
            FileInfo fi = new FileInfo(filename);
            fs =                fi.Length;
            result = new byte[fs];
            //filename = MapConstants.basictilefile;
            FileStream f1 = new FileStream(filename, FileMode.Open);            // Initialize Filestream for reading palette
            BinaryReader br1 = new BinaryReader(f1);
            for (int i = 0; i < fs; i++)                                        // Cycle through values of the RAW data.
                result[i] = (br1.ReadByte());
            f1.Close();
            return result;

        }
        public static Tiles MapSetTiles(Archive archive, int bTileIndex, int tileIndex, int lTileIndex, int tTypeIndex)
        {
                Tiles mapTiles = new Tiles();
                int t_size = Tiles.TileSize;

                byte[] data;
                int size = 0;
                int i, k, l;
                /* Basic Tiles Process */
                MessageBox.Show("Processing Basic Tiles!");
                data = Archive.decompressNDXArchive(archive, bTileIndex, ref size);

                string fname = MapConstants.basictilefile;
                using(var fs = new FileStream(fname, FileMode.Create,FileAccess.Write))
                {
                    fs.Write(data, 0, data.Length);
                }
                
                if ((size != bTileIndex * t_size* t_size)) 
                {
                    string err1 = "lotr: Basic Tiles Data Corrupted!";
                    string err2 = size.ToString();
                    string full = string.Concat(err1, err2);
                    MessageBox.Show(full, "File Data Corruption Error!");
                }
                for (i = 0; i < Tiles.BasicTileNum; ++i)                                                                  // Breaks down tile data into individual basic tiles 8x8.
                {
                    mapTiles.BasicTiles[i] = new Pixmap(Tiles.TileSize, Tiles.TileSize);
                    Buffer.BlockCopy(data, i * t_size * t_size, mapTiles.BasicTiles[i].data, 0, t_size * t_size);
                    //memcpy(basictiles[i]->data, data + i * TILESIZE * TILESIZE, TILESIZE * TILESIZE);               // Copy data into Pixmap for basic tiles structure.
                }
                for (i = 0; i < Tiles.TileNum; ++i)                                                                       // Cycle through 0 to 1280 filling tile array.
                    for (l = 0; l < 4; ++l)
                        for (k = 0; k < 4; ++k)
                            mapTiles.MapTiles[i,k,l] = data[(i * 16 + 1 * 4 + k) * 2] + 0x100 * data[(i * 16 + l * 4 + k) * 2 + 1];
                MessageBox.Show("Basic Tiles Processing Complete", "MapSetTiles - Action Completed!");
                
                /* Large Tile Processing */
                data = Archive.decompressNDXArchive(archive, lTileIndex, ref size);
                fname = MapConstants.largetilefile;
                using (var fs = new FileStream(fname, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(data, 0, data.Length);
                }
                for (i = 0; i < Tiles.LargeTileNum; ++i)
            	    for (l = 0; l < 4; ++l)
            		    for (k = 0; k < 4; ++k)
            			mapTiles.LargeTiles[i,k,l] = data[(i * 16 + 1 * 4 + k) * 2] + 0x100 * data[(i * 16 + l * 4 + k) * 2 + 1];

                /* Tile Terrain Processing */
                data = Archive.decompressNDXArchive(archive, tTypeIndex, ref size);
                for(i=0;i < Tiles.BasicTileNum; ++i)    
                    mapTiles.TileTerrain[i] = data[i];
                return mapTiles;
        }
        public static Palette MapSetPaletteResource(Archive archive, int paletteIndex)
        {
            Palette t_pal;
            int size=0;
            byte[] mPal;
            mPal = Archive.decompressNDXArchive(archive, paletteIndex, ref size);

            string err1 = "Palette byte data size ";
            string full = string.Concat(err1, size.ToString());

            //MessageBox.Show(full,"Size of Palette Bytes");
            t_pal = new Palette(mPal);

            return t_pal;
        }
        public static FileSummary ReadMapFile(string filename, int index)
        {
            Archive archive;
            FileSummary mp1 = new FileSummary();
            int a = index;
            int filPost = (4 * index);

            archive = Archive.NDXOpen(filename);
            mp1.ItemNumber = a;
            mp1.ItemName = string.Concat("MAP_", a.ToString());
            mp1.ItemOffset = archive.IndexOffsets[a];
            return mp1;
        }



    }
    public static class MapConstants
    {
        public const string basictilefile = "lotrbasictiles.dat";
        public const string largetilefile = "largetiles.dat";
        public const int MapWidth = 64;
        public const int MapHeight = 64;
        public const int BuildingWidth = 32;
        public const int BuildingHeight = 128;
        public const int TileSize = 8;
        /* Map Modes */
        public const int MapDark = 0;
        public const int MapNormal = 1;
        public const int MapLighted = 2;
        public const int MapFog = 4;

        public const int MapNearDistance = 0x11;

        /* Terrain Types */
        public const int TerrainPath = 0;
        public const int TerrainImPassable = 1;
        public const int TerrainSwamp = 2;
        public const int TerrainRock = 3;
        public const int TerrainDown = 4;
        public const int TerrainUp = 5;
        public const int TerrainPit = 6;
        public const int TerrainStairsDown = 7;
        public const int TerrainWater2 = 8;
        public const int TerrainEasy = 10;
        public const int TerrainHard = 11;
        public const int TerrainHarder = 12;
        public const int TerrainIce = 13;
        public const int TerrainIcePath = 14;
        public const int TerrainWater = 15;

        public static int[,] GameMaps = {  { 0x7, 0x0, 0x2 },	                        // {7, 0, 2}
                                            { 0xF, 0x0, 0xA },							// {15, 0, 10}
                                            { 0x107, 0x100, 0x2 },						// {263, 256, 258}
                                            { 0x10f, 0x100, 0xa },						// {271, 256, 266}
                                            { 0x117, 0x110, 0x2 },						// {279, 272, 258}
                                            { 0x11f, 0x110, 0xa },						// {287, 272, 282}
                                            { 0x127, 0x120, 0x122 },
                                            { 0x12f, 0x120, 0xa },
                                            { 0x0, 0x130, 0x0 },
                                            { 0x13f, 0x130, 0x13a },
                                            { 0x147, 0x140, 0x142 },
                                            { 0x14f, 0x140, 0xa },
                                            { 0x157, 0x150, 0x122 },
                                            { 0x15f, 0x150, 0x13a },
                                         };

    }
}
