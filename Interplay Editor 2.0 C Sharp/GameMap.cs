using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interplay_Editor_2_C_Sharp.Classes;


namespace Interplay_Editor_2_C_Sharp
{
	/// <summary>
	/// Class GameMap - UserControl to display gamemap tiles and map.
	/// </summary>
	public partial class GameMap : UserControl
	{
		const int TileSize = 8;									/* Tile size for normal sized tiles.*/
		const int TileNum = 1280;								/*  Number of total tiles. */
		readonly int SizeFactor = 2;							/* Size multiplier for tiles. */
		ImageList mapTileList;									/* List of images where indiviual tile bitmaps are stored */
		List<Bitmap> largeTileList;								/* List of large tiles */
		Tiles mapTiles;											/* Map tiles stored as objects.  See Tiles class. */
		Palette mapPalette;										
		Archive MapArchive;
		int MapValue;
		Color PixelColor;										/* Color object holding RGB values for the index color */
		bool BasicTilesComplete = false;
		bool LargeTileSetComplete = false;
		Map gameMap;
		int[] largeTileVals;

		public GameMap()
		{
			
		}

		public GameMap(Tiles tileSet, Palette mPal, Archive mapArchive, int MapVal)
		{
			InitializeComponent();
			mapTiles = tileSet;
			mapPalette = mPal;
			MapArchive = mapArchive;
			MapValue = MapVal;
		}
		/// <summary>
		/// GameMap_Load - Loads the GameMap Form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GameMap_Load(object sender, EventArgs e)
		{

			String BHex;
			int val;
			nbrTileNumber.Maximum = TileNum-1;
			nbrLargeTileNumber.Maximum = Tiles.LargeTileNum - 1;
			DrawTiles();
			BasicTilesComplete = true;
			splitContainer1.Panel1.Invalidate();
			splitContainer1.Panel1.Update();
			val = (int)nbrTileNumber.Value;
			RefreshTileHex(val);
			BHex = utils.ShortToHex(val);
			txtBasicTileHex.Text = "0x" + BHex;
			MapSetMap(MapArchive,MapValue,MapConstants.GameMaps[MapValue,0] % 0x100);

			
			this.Controls.Add(panelLargeTile);

			DrawTilesL();
			LargeTileSetComplete = true;
			panelLargeTile.Invalidate();
			panelLargeTile.Update();
			LargeTileSetComplete = false;

			//splitContainer1.Panel2.Invalidate();
			//splitContainer1.Panel2.Update();
			nbrTileNumber.Value = 0;
			DisplayBasicTiles();
		}

		public string RefreshTileHex(int decimalVal)
        {
			string BHex = utils.ShortToHex(decimalVal);
			txtBasicTileHex.Text = "0x" + BHex;
			return BHex;


		}
		


		private void DrawTiles()
		{
			int tileSize = TileSize * SizeFactor;
			int red, green, blue;
			mapTileList = new ImageList
			{
				ImageSize = new Size(tileSize, tileSize)
			};
			byte[] result;
			int x, y, i;
			byte b;
			Graphics g;
			int z = 0;
			//result = Graphics_Get_Tiledata(TileFilename);
			result = Map.GetTileData(MapConstants.basictilefile);
			for (i = 0; i < TileNum; i++)
			{
				Bitmap bit = new Bitmap(tileSize, tileSize);
				g = Graphics.FromImage(bit);
				for (y = 0; y < TileSize; y++)
				{
					for (x = 0; x < TileSize; x++)
					{
						b = result[z];
						PixelColor = GetMapPaletteColor(b);
						Rectangle pixel_rectangle = new Rectangle
						{
							X = (x * SizeFactor),
							Y = (y * SizeFactor),
							Width = SizeFactor,
							Height = SizeFactor
						};
						SolidBrush brush = new SolidBrush(PixelColor);
						Pen pen = new Pen(PixelColor);
						g.DrawRectangle(pen, pixel_rectangle.X, pixel_rectangle.Y,
							pixel_rectangle.Width, pixel_rectangle.Height);
						g.FillRectangle(brush, pixel_rectangle.X, pixel_rectangle.Y,
							pixel_rectangle.Width, pixel_rectangle.Height);
						z++;
					}
				}
				mapTileList.Images.Add(bit);
			}
			MessageBox.Show(mapTileList.Images.Count.ToString(), "MapTileList Total!");
		}

		public Color GetMapPaletteColor(int val)
        {
			Color result;
			int r, g, b;
			int i = val;
            r = 4 * (mapPalette.colors[3 * i]);
			g = 4 * (mapPalette.colors[(3 * i) + 1]);
			b = 4 * (mapPalette.colors[(3 * i) + 2]);

			result = Color.FromArgb(r, g, b);
			return result;
		}
		
		private void DisplayBasicTiles()
		{
			int curBTile = (int)nbrTileNumber.Value;
			pbBasicTile.Image = mapTileList.Images[curBTile];
		}

		private void DisplayLargeTiles()
		{
		int curLTile = (int)nbrLargeTileNumber.Value;
			pbLargeTile.Image = largeTileList[curLTile];
		}


		/// <summary>
		/// MapSetMap -- Set Map Description
		/// </summary>
		/// <param name="archive"></param>
		/// <param name="id"></param>
		/// <param name="mapIndex"></param>
		private void MapSetMap(Archive archive,int id,int mapIndex)
        {
			gameMap = new Map();
			byte[] data;
			int size=0;
			int k, l;
			data = Archive.decompressNDXArchive(archive, mapIndex, ref size);
			string fname = "mapfile.dat";
			using (var fs = new FileStream(fname, FileMode.Create, FileAccess.Write))
			{
				fs.Write(data, 0, data.Length);
			}

			for (l = 0; l < MapConstants.MapHeight; ++l)
				for (k = 0; k < MapConstants.MapWidth; ++k)
					gameMap.MapDesc[k, l] = data[(l * MapConstants.MapWidth + k) * 2] + 0x100 * data[(l * MapConstants.MapWidth + k) * 2 + 1];
        }
		/// <summary>
		/// SplitContainer2 Paint - Draws TileSet for Basic Tiles.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
		{
			if (BasicTilesComplete != true)
				return;
			Graphics gr = e.Graphics;
			int tileSize = TileSize * SizeFactor;
			int wmax = splitContainer1.Panel1.Width - tileSize;
			int hmax = splitContainer1.Panel1.Height;
			int k;
			int destX = 0;
			int destY = 0;
			Image mImage;
			for (k = 0; k < TileNum; k++)
			{
				mImage = mapTileList.Images[k];
				gr.DrawImage(mImage, destX, destY, tileSize, tileSize);
				if (destX > wmax)
				{
					destY += tileSize;
					destX = 0;
				}
				else
				{
					destX += tileSize;
				}
			}
			Bitmap bmp = new Bitmap(splitContainer2.Panel1.Width, splitContainer2.Panel1.Height);
			splitContainer1.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, splitContainer2.Panel1.Width, splitContainer2.Panel1.Height));
			bmp.Save("tilemap.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
		}


		/// <summary>
		/// SplitContainer1Panel2 Paint --- Draws Game Map through Tiles
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
			//if (L2Form != true)
			//	return;

			//Graphics gr = e.Graphics;
			//int smallTileSize = TileSize * SizeFactor;
			//int tileSize = (4 * TileSize) * SizeFactor;
			//int wmax = splitContainer1.Panel2.Width - tileSize;
			//int hmax = splitContainer1.Panel2.Height;
			//int k;
			//int destX = 1;
			//int destY = 1;
			//Image mImage;
			//for (k = 0; k < TileNum; k++)
			//{
			//	//mImage = largeTileList.Images[k];
			//	gr.DrawImage(mImage, destX, destY, smallTileSize, smallTileSize);
			//	if (destX > wmax)
			//	{
			//		destY += smallTileSize;
			//		destX = 1;
			//	}
			//	else
			//	{
			//		destX += tileSize;
			//	}
			//}
			//Bitmap bmp = new Bitmap(splitContainer1.Panel2.Width, splitContainer1.Panel2.Height);
			//splitContainer1.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, splitContainer1.Panel2.Width, splitContainer1.Panel2.Height));
			//bmp.Save("largetilemap.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
		}

        private void nbrTileNumber_ValueChanged(object sender, EventArgs e)
        {
			int val = (int)nbrTileNumber.Value;
			DisplayBasicTiles();

			RefreshTileHex(val);
        }
		private void nbrLargeTileNumber_ValueChanged(object sender, EventArgs e)
		{
			/* *TODO ** GET THIS WORKING
			 * */
			
			
			DisplayLargeTiles();
		}


		private void DrawTilesL()
		{
			int lVal;
			int adjustedLTileSize = (TileSize * SizeFactor);
			largeTileList = new List<Bitmap>();
			Bitmap bmDest = new Bitmap((TileSize * SizeFactor) * 4, (TileSize * SizeFactor) * 4);		// Destination bitmap--drawing surface.
			Bitmap bmpTile = new Bitmap((TileSize * SizeFactor) * 4, (TileSize * SizeFactor) * 4);                                                                              // Bitmap object to store source bitmap.
			Image LgTile;
			Graphics g1;                                                                                // Graphics object for drawing.
			int tileIndex;
			int x = 0;
			int y = 0;
			int i, j;


			g1 = Graphics.FromImage(bmDest);							// Set graphics to draw on bitmap surface.

			for(tileIndex = 0; tileIndex < Tiles.LargeTileNum; tileIndex++)
            {
				x = 0;
				y = 0;
				for(i=0;i<4;i++)
                {
					for (j=0;j<4;j++)
                    {
						lVal = mapTiles.LargeTiles[tileIndex, i, j];
						LgTile = mapTileList.Images[lVal];
						g1.DrawImage(LgTile, x, y, (x + TileSize) * SizeFactor, (y + TileSize) * SizeFactor);
						y += y + adjustedLTileSize;
						string t1 = "Tile # ";
						string t2 = " X Value ";
						string t3 = " Y Value ";
						string full = string.Concat(t1, tileIndex, t2, x, t3, y);


						//MessageBox.Show(full);
                    }
					y = 0;
					x += x + adjustedLTileSize;
                }
				panelLargeTile.DrawToBitmap(bmpTile, new Rectangle(0, 0, bmpTile.Width, bmpTile.Height));
				
				largeTileList.Add(bmpTile);
				pbLargeTile.Image = bmpTile;
				//MessageBox.Show("Pause");
			}







        }





        private void splitContainer1_Panel2_Paint_1(object sender, PaintEventArgs e)
        {
			/*
			 *Paint event for Map Panel. 
			 */


        }

  //      private void panelLargeTile_Paint(object sender, PaintEventArgs e)
  //      {
		//	int t, i, j, k;
		//	int x = 0;
		//	int y = 0;
		//	largeTileList = new List<Bitmap>();
		//	for (t = 0; t < Tiles.LargeTileNum; t++)
		//	{
		//		x = y = 0;
		//		Bitmap bit = new Bitmap(panelLargeTile.Width, panelLargeTile.Height);
		//		int lval;
		//		Graphics g = e.Graphics;
		//		largeTileVals = new int[16];
		//		for (i = 0; i < 4; i++)
		//		{
		//			for (j = 0; j < 4; j++)
		//			{
		//				largeTileVals[(i * 4) + j] = mapTiles.LargeTiles[t, i, j];
		//				lval = largeTileVals[(i * 4) + j];
		//				Image tiImage;
		//				tiImage = mapTileList.Images[lval];
		//				e.Graphics.DrawImage(tiImage, x, y, (x + TileSize)*SizeFactor, (y+TileSize)*SizeFactor );
		//				//Application.DoEvents();


		//				y += (y + TileSize) * SizeFactor;



		//				//MessageBox.Show(lval.ToString(), "Tile Set Value");

		//			}
		//			y = 0;
		//			x += (x + TileSize) * SizeFactor;
		//		}
		//		/*string fname = "mapfile";
		//		string fullName = string.Concat(fname, t, ".dat");
		//		using (var fs = new FileStream(fullName, FileMode.Create, FileAccess.Write))
		//		{
		//			fs.Write(largeTileVals, 0, largeTileVals.Length);
		//		}*/


		//		panelLargeTile.DrawToBitmap(bit, new Rectangle(0, 0, bit.Width, bit.Height));
		//		largeTileList.Add(bit);
		//		//pbLargeTile.Image = largeTileList[t];
		//		//MessageBox.Show(t.ToString(), "Large Tile Completion!");
		//	}


		//	pbLargeTile.Image = largeTileList[1];



		//}
    }//End Panel Paint

}


 
