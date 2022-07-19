using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interplay_Editor_2_C_Sharp
{
    public class Tiles
    {
        public const int BasicTileNum = 1280;
        public const int TileSize = 8;
        public const int TileNum = 1280;
        public const int LargeTileNum = 768;

        public Pixmap[] BasicTiles;
        public int[,,] MapTiles;
        public int[,,] LargeTiles;
        public int[] TileTerrain;


        public Tiles()
        {
            BasicTiles = new Pixmap[TileNum];
            MapTiles = new int[TileNum, 4, 4];
            LargeTiles = new int[LargeTileNum, 4, 4];
            TileTerrain = new int[TileNum];
        }

        public static int TilenNum { get; private set; }
    }
}
