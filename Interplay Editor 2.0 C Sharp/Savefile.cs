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
    public partial class Savefile : UserControl
    {
        // Savefile
        // Handles savegame files for Interplay LOTR and TTT.
        //
        public static bool PortraitLoaded;
        public static bool ShapeLoaded;
        public static bool DecreaseFlag = false;

        public string FullFilename;
        public int value;

        public Character lc;
        public ColorPalette[] PortraitPalette;
        public Palette ShapesPalette;
        public Shape SelectedShape;

        List<Portrait> portraitCache;
        public List<Shape> shapeCache;
        public List<Bitmap> ShapeSprites;

        public byte[] SGPBuffer;
        public byte[] SGSBuffer;

        

        public Savefile()
        {
            InitializeComponent();
        }
        public Savefile(FileSummary fileSummary, string fileName)
        {
            InitializeComponent();
            Config cfg = new Config(true);
            this.Text = fileSummary.ItemName;
            this.value = fileSummary.ItemNumber;
            PortraitLoaded = false;
            ShapeLoaded = false;
            string path = cfg.GameDirectory;
            FullFilename = path + "\\" + fileName;
            MessageBox.Show("Opening Save File " + FullFilename);

        }


        private void Savefile_Load(object sender, EventArgs e)
        {
            Populate_Character();
        }
        private void Populate_Character()
        {
            int bytePointer;
            lc = new Character();
            byte[] header = null;
            byte[] buffer = null;
            lc.items = new int[10];
            lc.skills = new int[10];
            lc.magic = new int[10];
            header = new byte[16];
            int shapeIndex = (int)Character.SHAPE_SETS.CHARACTER_STAY + 1;
            lc.shapes = new Shape[shapeIndex];
            header = GetHeader(FullFilename);

            int filpost = Character.Constants.SaveBlock_Begin + (Character.Constants.Save_Increment * value);


            buffer = new byte[256];
            buffer = GetCharData(FullFilename, filpost);

            lc.silver = GetSilver(header);
            txtSilver.Text = lc.silver.ToString();
            bytePointer = 7;
            lc.shape_id = buffer[bytePointer];
            nbrShape.Value = lc.shape_id;
            
            bytePointer = 11;
            lc.direction = buffer[bytePointer++];
            lc.strDirection = Character.GetDirection(lc.direction);
            txtDirection.Text = lc.strDirection;
            bytePointer = 17;
            lc.dexterity = buffer[bytePointer++];
            TXTDex.Text = lc.dexterity.ToString();
            lc.life = buffer[bytePointer++];
            txtLife.Text = lc.life.ToString();
            lc.strength = buffer[bytePointer++];
            TxtStr.Text = lc.strength.ToString();
            lc.will = buffer[bytePointer++];
            txtWill.Text = lc.will.ToString();
            lc.luck = buffer[bytePointer++];
            txtLuck.Text = lc.luck.ToString();
            lc.endurance = buffer[bytePointer++];
            txtEnd.Text = lc.endurance.ToString();
            bytePointer = 25;
            for (int a = 0; a < 10; a++)
            {
                string t_items = "";
                lc.items[a] = buffer[bytePointer++];
                if (lc.items[a] == 255)
                {
                    t_items = "BLANK";
                }
                else
                {
                    t_items = lc.Get_Item(lc.items[a]);
                }

                ListboxItems.Items.Add(t_items);
            }
            for (int a = 0; a < 10; a++)
            {
                string t_skill = "";
                lc.skills[a] = buffer[bytePointer++];
                if (lc.skills[a] == 255)
                {
                    t_skill = "BLANK";
                }
                else
                {
                    t_skill = lc.Get_Item(lc.skills[a]);
                }

                listSkills.Items.Add(t_skill);
            }
            for (int a = 0; a < 10; a++)
            {
                string t_magic = "";
                lc.magic[a] = buffer[bytePointer++];
                if (lc.magic[a] == 255)
                {
                    t_magic = "BLANK";
                }
                else
                {
                    t_magic = lc.Get_Item(lc.magic[a]);
                }

                listMagic.Items.Add(t_magic);
            }
            lc.portrait = buffer[81];
            NbrPortrait.Value = lc.portrait;
            portraitCache = new List<Portrait>();
            portraitCache = Portrait.initPortraits();
            loadPortrait(portraitCache[lc.portrait]);
            PortraitPalette = ColorPalette.MakePalette(portraitCache[lc.portrait].palette, 0, 256);
            PortraitLoaded = true;
            FillPortraitPalette();
            PBPortrait.Refresh();
            shapeCache = Shape.ShapeInit();
            ShapesPalette = Shape.GetShapePalette();
            FillShapePalette(ShapesPalette);
            for (int j=0; j < 5; j++)
                lc.shapes[j] = Shape.Get_Shape(6 * lc.shape_id + j);
            loadSprite();
        }




        void loadSprite()
        {
            ShapeSprites = new List<Bitmap>();
            int p_index = lc.shape_id;
            int shapeIndex = (p_index * 6);
            SelectedShape = Shape.Get_Shape(shapeIndex);
            if (SelectedShape == null)
            {
                MessageBox.Show("SelectedShape is NULL");
                do
                {
                    if (DecreaseFlag == true)
                        p_index--;
                    else
                        p_index++;
                    shapeIndex = (6 * p_index);
                    nbrShape.Value = p_index;
                } while (SelectedShape == null);
            }
            else
            {
                for (int g = 0; g < 6; g++)
                {
                    SelectedShape = Shape.Get_Shape(shapeIndex + g);
                    txtSpriteHeight.Text = SelectedShape.h.ToString();
                    txtSpriteWidth.Text = SelectedShape.w.ToString();
                    SGSBuffer = SelectedShape.shapePixmap;
                    ShapeLoaded = true;
                    PaintSprite(g);
                    pnlSprite.Refresh();
                }
            }
        }

        private void PaintSprite(int ind)

        {
            if (ShapeLoaded != true)
                return;

            Bitmap TempBitmap;

            int w, h;
            int shapeChunkSize;
            w = SelectedShape.w;
            h = SelectedShape.h;
            int multiplier = 2;
            byte b = new byte();
            if (PanelSpare.BackgroundImage == null)
                PanelSpare.BackgroundImage = new Bitmap(320, 200);
            Graphics gr = Graphics.FromImage(PanelSpare.BackgroundImage);
            gr.Clear(PanelSpare.BackColor);
            int index = 0;
            shapeChunkSize = SelectedShape.shapePixmap.Length / SelectedShape.w;

            for (int i = 0; i < SelectedShape.pixmaps_num; i++)
            {
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        b = SGSBuffer[index];
                        Color pixelColor = Color.FromArgb(ShapesPalette.colors[3 * b] * 4, ShapesPalette.colors[3 * b + 1] * 4, ShapesPalette.colors[3 * b + 2] * 4);

                        Rectangle pixelRectangle = GetDrawingRectangle(x, y);
                        SolidBrush brush = new SolidBrush(pixelColor);
                        Pen pen = new Pen(Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B));
                        gr.DrawRectangle(pen, pixelRectangle.X, pixelRectangle.Y, pixelRectangle.Width, pixelRectangle.Height);
                        gr.FillRectangle(brush, pixelRectangle.X, pixelRectangle.Y, pixelRectangle.Width, pixelRectangle.Height);

                        index++;
                    }
                }

                System.Windows.Forms.Application.DoEvents();
                PanelSpare.Refresh();
                Rectangle rect = new Rectangle(0, 0, w * multiplier, h * multiplier);
                TempBitmap = new Bitmap(w * multiplier, h * multiplier);
                PanelSpare.DrawToBitmap(TempBitmap, rect);
                //TempBitmap = CaptureBitmap(PanelSpare, w, h, multiplier);
                ShapeSprites.Add(TempBitmap);
            }
            //MessageBox.Show(ShapeSprites.Count.ToString(), "Running number of Sprites!");
            gr.Dispose();
        }
        private int GetSilver(byte[] buf)
        {
            int silver = buf[10];
            return silver;
        }
        public byte[] GetHeader(string saveFilename)
        {
            byte[] temp = null;
            using (FileStream fs = new FileStream(saveFilename, FileMode.Open, FileAccess.Read))
            {
                temp = new byte[16];
                fs.Read(temp, 0, 16);
            }
            return temp;
        }
        public byte[] GetCharData(string filename, int fptr)
        {
            byte[] temp = null;
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                fs.Seek(fptr, SeekOrigin.Begin);
                temp = new byte[256];
                fs.Read(temp, 0, 256);
            }
            return temp;
        }

        public void loadPortrait(Portrait port)
        {
            int dSize;
            dSize = port.datasize;
            SGPBuffer = new byte[dSize];
            SGPBuffer = port.data;

        }
        private void FillPortraitPalette()
        {
            int PRed, PGreen, PBlue;
            int g, v;
            g = v = 0;
            int PaletteSize = PortraitPalette.Length;
            GridViewPortraitPalette.Rows.Clear();
            //MessageBox.Show(PaletteSize.ToString(), "Palette Size");
            for (g = 0; g < PaletteSize; g++)
            {
                PRed = PortraitPalette[g].Red;
                PGreen = PortraitPalette[g].Green;
                PBlue = PortraitPalette[g].Blue;

                GridViewPortraitPalette.Rows.Add(v, "", PRed, PGreen, PBlue);
                GridViewPortraitPalette.Rows[v].Cells[1].Style.BackColor = Color.FromArgb(PRed, PGreen, PBlue);
                v++;
            }
        }
        private void NbrPortrait_ValueChanged(object sender, EventArgs e)
        {
            if (portraitCache == null)
                return;

            int value = (int)NbrPortrait.Value;
            loadPortrait(portraitCache[value]);
            PortraitPalette = ColorPalette.MakePalette(portraitCache[value].palette, 0, 256);
            FillPortraitPalette();
            PBPortrait.Refresh();

        }
        private void PBPortrait_Paint(object sender, PaintEventArgs e)
        {
            if (PortraitLoaded != true)
                return;
            if (SGPBuffer == null)
                return;
            int x, y;
            int z = 0;
            byte b;
            Graphics g = e.Graphics;
            for (y = 0; y < 54; y++)
            {
                for (x = 0; x < 68; x++)
                {
                    b = SGPBuffer[z];
                    Color pixelColor = Color.FromArgb(PortraitPalette[b].Red, PortraitPalette[b].Green, PortraitPalette[b].Blue);
                    Rectangle pixelRectangle = new Rectangle();
                    pixelRectangle.X = (x * Constants.sizeFactor);
                    pixelRectangle.Y = (y * Constants.sizeFactor);
                    pixelRectangle.Width = Constants.sizeFactor;
                    pixelRectangle.Height = Constants.sizeFactor;
                    SolidBrush brush = new SolidBrush(pixelColor);
                    Pen pen = new Pen(Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B));
                    g.DrawRectangle(pen, pixelRectangle.X, pixelRectangle.Y, pixelRectangle.Width, pixelRectangle.Height);
                    g.FillRectangle(brush, pixelRectangle.X, pixelRectangle.Y, pixelRectangle.Width, pixelRectangle.Height);
                    z++;
                }
            }




        }

        private void FillShapePalette(Palette transfer)
        {
            byte SRed, SGreen, SBlue;
            int g;

            int PaletteSize = transfer.colors.Length;
            GridViewShapesPalette.Rows.Clear();
            //MessageBox.Show(PaletteSize.ToString(), "Palette Size for Shapes");

            int ind = 0;
            for (g = 0; g < (PaletteSize / 3); g++)
            {
                SRed = transfer.colors[ind++];
                SGreen = transfer.colors[ind++];
                SBlue = transfer.colors[ind++];
                SRed *= 4;
                SGreen *= 4;
                SBlue *= 4;

                GridViewShapesPalette.Rows.Add(g, "", SRed, SGreen, SBlue);
                GridViewShapesPalette.Rows[g].Cells[1].Style.BackColor = Color.FromArgb(SRed, SGreen, SBlue);

            }

        }



        private void NbrShape_ValueChanged(object sender, EventArgs e)
        {

            if (lc.shape_id > nbrShape.Value)
                DecreaseFlag = true;
            int value = (int)nbrShape.Value;
            lc.shape_id = value;
            loadSprite();

        }
       

        private void PanelSpare_Paint(object sender, PaintEventArgs e)
        {

        }

        private Rectangle GetDrawingRectangle(int x, int y)
        {
            Rectangle result = new Rectangle();
            result.X = x * 2;
            result.Y = y * 2;
            result.Width = 2;
            result.Height = 2;
            return result;
        }


        private void pnlSprite_Paint(object sender, PaintEventArgs e)
        {
            if (ShapeLoaded != true)
                return;

            int dest_x, dest_y;
            dest_x = dest_y = 0;
            Image p_image;
            int p_YOffset = 0;
            int p_panelwidth, p_panelheight;

            if (ShapeSprites.Count <= 0)
            {
                MessageBox.Show("Sprites List empty!", "pnlSprite_Paint Error!");
                return;

            }
            for (int x = 0; x < ShapeSprites.Count; x++)
            {
                p_image = ShapeSprites[x];
                e.Graphics.DrawImage(p_image, dest_x, dest_y + p_YOffset, p_image.Width, p_image.Height);
                p_YOffset += p_image.Height;
                if ((dest_y + p_YOffset) >= ((dest_y + p_image.Height) * 4))
                {
                    dest_x += p_image.Width;
                    dest_y = p_YOffset = 0;
                }
            }

            p_panelwidth = ShapeSprites[0].Width* 6;
            p_panelheight = ShapeSprites[0].Height * SelectedShape.pixmaps_num;
            pnlSprite.Size = new Size(p_panelwidth, p_panelheight);

            //ShapeLoad = false;
        }

    }
}

