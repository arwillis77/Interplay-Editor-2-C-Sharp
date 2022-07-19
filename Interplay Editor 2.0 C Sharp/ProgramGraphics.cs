using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interplay_Editor_2_C_Sharp.Classes;


namespace Interplay_Editor_2_C_Sharp
{
    class ProgramGraphics
    {
        

    }
    // Palette Class.
    // Sets up game palettes into separate byte arrays for the various graphic arrays.

    public class ColorPalette
    {
        
        public int Red;
        public int Green;
        public int Blue;

        public ColorPalette(int a, int b, int c)
        {
            this.Red = a;
            this.Green = b;
            this.Blue = c;

        }
        public static ColorPalette[] MakePalette(byte[] PaletteArray, int firstColor, int nColors)
        {
            ColorPalette[] t_pal = new ColorPalette[256];
            int i;
            int r, g, b;
            for (i = 0; i < nColors; ++i)
            {
                r = PaletteArray[(3 * (i + firstColor) + 0)] * 4;
                g = PaletteArray[(3 * (i + firstColor) + 1)] * 4;
                b = PaletteArray[(3 * (i + firstColor) + 2)] * 4;
                t_pal[i] = new ColorPalette(r, g, b);
            }
            return t_pal;

        }



    }

    public class Palette
    {
        public static readonly int paletteColorTotal = 0x100;
        const string PalSuffix = "PAL";

        public byte[] colors;      /* colors in rgb format [768]*/
        public byte[] egacolors;    /* mapping of 16 EGA colors to VGA colors [16] .*/
        public byte[] egamapping;  /* mapping of 256 VGA colors to EGA [256]*/
        public byte[] unknown;
        public byte[] cgamapping;	/* mapping of 256 VGA Colors to CGA colors [256]*/

        // Default class constructor.
        public Palette()
        {
            colors = new byte[0x300];                   // Colors in RGB format.  256 colors.
            egacolors = new byte[0x10];                 // Mapping of 16 EGA colors to VGA colors.
            egamapping = new byte[0x0100];              // Mapping of 256 VGA colors to EGA colors.
            unknown = new byte[2];
            cgamapping = new byte[0x100];               // Mapping of 256 VGA colorsto CGA colors.
            
        }


        // Class constructor using palette byte array data
        
        public static Palette GetPalette(string palType)
        {
            Palette result;
            Config cfg = new Config(true);
            byte[] PalDat;
            Archive.FileDetails pal;
         
            pal.Filename = palType;
            pal.Path = cfg.GameDirectory;  //config.ReadConfig();
            pal.Suffix = PalSuffix;
            pal.FullName = string.Concat(pal.Path, "\\", pal.Filename, ".", pal.Suffix);
            FileInfo p1 = new FileInfo(pal.FullName);
            pal.Size = (int)p1.Length;
            PalDat = File.ReadAllBytes(pal.FullName);

            result = new Palette(PalDat);
            if (pal.Size != PalDat.Length)
            {
                string err1 = "lotr: ";
                string err2 = "is not a valid palette file.";
                string full = string.Concat(err1, PalDat, err2);
                MessageBox.Show(full, "ShapesInit Palette size error!");
            }
            return result;

        }
        
        
        public Palette(byte[] paldata)
        {
            int a;
            int index = 0;
            colors = new byte[0x300];
            for (a = 0; a < 0x300; a++)
            {
                colors[a] = paldata[index++];
            }

            egacolors = new byte[0x10];
            for (a = 0; a < 0x10; a++)
            {
                egacolors[a] = paldata[index++];
            }
            egamapping = new byte[0x0100];
            for (a = 0; a < 0x100; a++)
            {
                egamapping[a] = paldata[index++];
            }

            unknown = new byte[2];
            for (a = 0; a < 2; a++)
            {
                unknown[a] = paldata[index++];
            }

            cgamapping = new byte[0x100];
            for (a = 0; a < 0x100; a++)
            {
                cgamapping[a] = paldata[index++];
            }
        }


        // Sets palette.


        public static void copyPaletteColors(Palette pal, int start, int num, int newstart)
        {
            if (start < 0 || num < 0 || start + num > 0xff || newstart < 0
                || newstart + num > 0xff)
            {
                string message = "LOTR: Wrong palette_reindex parameters!";
                string caption = "Palette File Index Error";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //public static void BlockCopy (Array src, int srcOffset, Array dst, int dstOffset, int count);
            Buffer.BlockCopy(pal.colors, 3 * newstart, pal.colors, 3 * start, (3 * num));
            Buffer.BlockCopy(pal.egamapping, newstart, pal.egamapping, start, num);
            Buffer.BlockCopy(pal.cgamapping, newstart, pal.cgamapping, start, num);
        }


        public byte[] getByteArrayPalette(string filename)
        {
            int i;
            byte[] tempPalette = new byte[paletteColorTotal];
            FileStream f1 = new FileStream(filename, FileMode.Open);
            BinaryReader br1 = new BinaryReader(f1);
            for (i = 0; i < (paletteColorTotal * 3); i++)                           // Cycle through palette values of the palette
                tempPalette[i] = br1.ReadByte();                                    // Load byte-by-byte into palette array
            return tempPalette;
        }

    }

    class PPalette
    {
        public byte[] r;
        public byte[] g;
        public byte[] b;


        public PPalette()
        {
            r = new byte[0x100];
            g = new byte[0x100];
            b = new byte[0x100];
            for (int a = 0; a < 0x100; a++)
                r[a] = 0;
            for (int b = 0; b < 0x100; b++)
                g[b] = 0;
            for (int c = 0; c < 0x100; c++)
                b[c] = 0;

        }

        public static PPalette setMainPalette(byte[] rdata, byte[] gdata, byte[] bdata)
        {
            PPalette result = new PPalette();

            for (int a = 0; a < 0x100; a++)
                result.r[a] = rdata[a];
            for (int b = 0; b < 0x100; b++)
                result.g[b] = gdata[b];
            for (int c = 0; c < 0x100; c++)
                result.b[c] = bdata[c];

            return result;
        }



    }

    public class Pixmap
    {
        public int width;
        public int height;
        public int datasize;
        public byte hasalpha;
        public byte alpha;
        public byte[] data;

        public Pixmap()
        {

        }


        public Pixmap(int w, int h)
        {
            this.width = w;
            this.height = h;
            this.datasize = width * height;
            this.hasalpha = 0;
            this.data = new byte[datasize];

        }

        void PixmapSetAlpha(Pixmap pmap, byte alpha)
        {
            pmap.hasalpha = 1;
            pmap.alpha = alpha;


        }

        public static Pixmap ReadFromNDXArchive(Archive archive, int index, int width = 1)
        {
            Pixmap result;
            byte[] compressed;
            byte[] data;
            int size = 0;

            compressed = Archive.ArchiveRead(archive, index);
            if (compressed == null)
            {
                string err = "lotr: could not find pixmap at index ";
                string err2 = " in the archive!";
                string full = string.Concat(err, index, err2);
                MessageBox.Show(full, "ReadFromNDXArchive Error!");
                return null;
            }
            data = Archive.decompressNDXArchive(archive, index, ref size);
            result = new Pixmap
            {
                width = width,
                height = size / width,
                datasize = size,
                hasalpha = 0,
                data = data
            };



            return result;

        }
        





    }
}




