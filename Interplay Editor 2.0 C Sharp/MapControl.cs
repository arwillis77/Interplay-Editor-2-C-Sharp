
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interplay_Editor_2_C_Sharp.Classes;

namespace Interplay_Editor_2_C_Sharp
{
    public partial class MapControl : UserControl
    {

        public Tiles gmapTile;
        public Palette gmapPalette;
        public Archive loadedArchive;
        TabPage tpg = new TabPage();
        ProgramForm cf;
        public int MapIndex;
        public int MapValue;
        public string MapFilename;
        public Map mcMap;


        public MapControl(ProgramForm callingForm)
        {
            cf = callingForm;
            InitializeComponent();

           
        }


        public MapControl()
        {
            InitializeComponent();

        }

        void ProcessMap(int MapVal)
        {
            Archive archive;
            int map = MapVal;
            if (MapConstants.GameMaps[map, 0] > 0xff)
                MapFilename = "map1";
            else
                MapFilename = "map0";

            textMapFilename.Text = MapFilename;
            
            archive = Archive.NDXOpen(MapFilename);
            gmapTile = Map.MapSetTiles(archive, MapConstants.GameMaps[map, 2] % 0x100,                                       // int basictileindex
                            MapConstants.GameMaps[map, 2] % 0x100 + 1,                                                        // int tileindex
                            MapConstants.GameMaps[map, 2] % 0x100 + 2,                                                        // int largetileindex
                            MapConstants.GameMaps[map, 2] % 0x100 + 4);														// int tiletypeindex  
            gmapPalette = Map.MapSetPaletteResource(archive, MapConstants.GameMaps[map, 2] % 0x100 + 3);
            loadedArchive = archive;
        }

        private void ButtonUpdateMap_Click(object sender, EventArgs e)
        {
            MapValue = (int)NbrMapValue.Value;
            ProcessMap(MapValue);
            GameMap gm = new GameMap(gmapTile, gmapPalette, loadedArchive, MapValue);
            gm.Dock = DockStyle.Fill;
            tpg.Controls.Add(gm);
            cf.AddResourceTab(tpg);
            
        }

        private void MapControl_Load(object sender, EventArgs e)
        {
            MapValue = (int)NbrMapValue.Value;
            MapIndex = MapConstants.GameMaps[MapValue,0] % 0x100;
            textMapIndex.Text = MapIndex.ToString();
        }

        private void NbrMapValue_ValueChanged(object sender, EventArgs e)
        {
            MapValue = (int)NbrMapValue.Value;
            MapIndex = MapConstants.GameMaps[MapValue, 0] % 0x100;
            textMapIndex.Text = MapIndex.ToString();
            if (MapConstants.GameMaps[MapValue, 0] > 0xff)
                MapFilename = "map1";
            else
                MapFilename = "map0";
            textMapFilename.Text = MapFilename;
        }
    }
}
