using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Interplay_Editor_2_C_Sharp.Classes
{

    /// <summary>
    /// Archive Class - Provides access to IDX'ed and NDX'ed data files
    /// </summary>

    /***************************************************************************************************
     * ARCHIVE Class  -- Version 2.0 Updated 2/4/2021
     * 
     * Based on archive.h and archive.c C code written by Michal Benes.
     * 
     * Provides access to IDX'ed and NDX'ed data files. Data files hold the data while the NDX and 
     * IDX files index starting addresses for each dataset.
     * 
     * 
     * **************************************************************************************************/

    public class Archive
    {
        public byte[] Data;                    // byte array for data
        public List<int> IndexOffsets;
        public long Size;                           // size of the archive.
        public int IndexSize;                           // size of index.
       
        public struct FileDetails
        {
            public string Filename;
            public string Path;
            public string Suffix;
            public string FullName;
            public int Size;
        }
        // Default class constructor.
        public Archive()
        {

        }

        // Constructor with size of datafile.
        public Archive(int dataSize)
        {
            Data = new byte[dataSize];
            IndexOffsets = new List<int>();

        }

        /*  METHODS
         *  
         *  ArchiveRead                     Reads data from the archive.
         *  IDXOpen                         Loads IDX values for parsing data.
         *  NDXOpen                         Loads NDX values for parsing data.
         *  decompressIDXArchive
         *  decompressNDXArchive
         *  
         *  
         * */


        /// <summary>
        /// Reads data from the archive.
        /// </summary>
        /// <param name="arc"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static byte[] ArchiveRead(Archive arc, int index)
        {
            byte[] result;                                      // byte array for storing data        
            int size = ArchiveDatasize(arc, index);                      // Size of archive data chunk
            int counter = 0;
            if (size == 0)
            {
                MessageBox.Show("lotr: archive datasize is NULL!", "archiveRead NULL Error!");
                return null;
            }
            result = new byte[size];
            int indexValue = arc.IndexOffsets[index];
            for (int a = indexValue; a < indexValue + size; a++)
                result[counter++] = arc.Data[a];
            return result;
        }
        /// <summary>
        /// Returns data size of data from the given index of the archive.
        /// </summary>
        /// <param name="arc"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int ArchiveDatasize(Archive arc, int index)
        {

            if (index < 0 || index >= arc.IndexSize)
                return 0;
            return arc.IndexOffsets[index + 1] - arc.IndexOffsets[index];

        }





        /// <summary>
        /// LOADS IDX VALUES FOR PARSING DATA.  
        /// </summary>
        public static Archive IDXOpen(string datafileName)
        {
            byte[] tmpBytes = new byte[2];
            int i, k, n;
            Config cfg = new Config(true);
            FileDetails dataFile;
            dataFile.Filename = datafileName;
            dataFile.Path = cfg.GameDirectory;
            dataFile.Suffix = Constants.extensions[4];          // Use DAT file extension.
            dataFile.FullName = string.Concat(dataFile.Path, "\\", dataFile.Filename, ".", dataFile.Suffix);
            FileInfo fi = new FileInfo(dataFile.FullName);
            dataFile.Size = (int)fi.Length;
            Archive t_arc = new Archive(dataFile.Size);
            t_arc.Data = File.ReadAllBytes(dataFile.FullName);


            FileDetails idxFile;
            idxFile.Filename = datafileName;
            idxFile.Path = cfg.GameDirectory;//config.ReadConfig();
            idxFile.Suffix = Constants.extensions[6];           // Use IDX file extension.
            idxFile.FullName = string.Concat(idxFile.Path, "\\", idxFile.Filename, ".", idxFile.Suffix);
            FileInfo fi2 = new FileInfo(idxFile.FullName);
            idxFile.Size = (int)fi2.Length;

            n = idxFile.Size;
            n = (n + 1) / 2;

            FileStream f1 = new FileStream(idxFile.FullName, FileMode.Open);
            BinaryReader br1 = new BinaryReader(f1);


            t_arc.IndexOffsets.Add(0);

            for (i = 1; i < n; ++i)
            {
                tmpBytes[0] = br1.ReadByte();
                tmpBytes[1] = br1.ReadByte();

                k = tmpBytes[1] * 0x100 + tmpBytes[0];


                t_arc.IndexOffsets.Add(k);

                if (t_arc.IndexOffsets[i - 1] > k)
                {
                    string message = string.Concat(idxFile.Filename, " seems to not be a valid NDX file!");
                    string caption = "File Error";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return t_arc;
        }
        /// <summary>
        /// NDXOpen - LOADS NDX VALUES FOR PARSING DATA.  
        /// </summary>
        public static Archive NDXOpen(string datafileName)
        {
            byte[] tmpBytes = new byte[4];
            int i, k;                                      // Int variable for loop of index bytes , and for combine index bytes for index values.
            long n;
            Config cfg = new Config(true);
            // Read all data from the datafile.
            FileDetails dataFile;
            dataFile.Filename = datafileName;
            dataFile.Path = cfg.GameDirectory; // config.ReadConfig();
            dataFile.Suffix = Constants.extensions[4];          // Use DAT file extension.
            dataFile.FullName = string.Concat(dataFile.Path, "\\", dataFile.Filename, ".", dataFile.Suffix);
            FileInfo fi = new FileInfo(dataFile.FullName);
            dataFile.Size = (int)fi.Length;
            Archive t_arc = new Archive(dataFile.Size);
            t_arc.Data = File.ReadAllBytes(dataFile.FullName);

            // Read and obtain index values to parse through the large data stored in memory.
            FileDetails ndxFile;
            ndxFile.Filename = datafileName;
            ndxFile.Path = cfg.GameDirectory;
            ndxFile.Suffix = Constants.extensions[5];           // Use NDX file extension.
            ndxFile.FullName = string.Concat(ndxFile.Path, "\\", ndxFile.Filename, ".", ndxFile.Suffix);
            FileInfo fi2 = new FileInfo(ndxFile.FullName);
            ndxFile.Size = (int)fi2.Length;

            n = ndxFile.Size;
            n = (n + 3) / 4;


            FileStream f1 = new FileStream(ndxFile.FullName, FileMode.Open);
            BinaryReader br1 = new BinaryReader(f1);

            if (n < 2 || br1.ReadByte() != 0
                || br1.ReadByte() != 0
                || br1.ReadByte() != 0 || br1.ReadByte() != 0)
            {
                MessageBox.Show("lotr: Expecting four zeroes at the beginning of an NDX file.", "NDX Header Error!");
                Application.ExitThread();

            }

            t_arc.IndexOffsets.Add(0);
            for (i = 1; i < n; ++i)
            {
                tmpBytes[0] = br1.ReadByte();
                tmpBytes[1] = br1.ReadByte();
                tmpBytes[2] = br1.ReadByte();
                tmpBytes[3] = br1.ReadByte();

                k = ((tmpBytes[3] * 0x100 + tmpBytes[2]) * 0x100 +
                tmpBytes[1]) * 0x100 + tmpBytes[0];

                t_arc.IndexOffsets.Add(k);
                //MessageBox.Show(t_arc.index[i].ToString(),"T_Index");
                if (t_arc.IndexOffsets[i - 1] > k)
                {
                    string message = string.Concat(ndxFile.Filename, " seems to not be a valid NDX file!");
                    string caption = "File Error";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            t_arc.IndexOffsets.Add(dataFile.Size);
            t_arc.Size = dataFile.Size;
            t_arc.IndexSize = (int)n;
            f1.Close();
            br1.Close();
            return t_arc;
        }


        /// <summary>
        /// decompress idx file compression.
        /// </summary>
        public static byte[] decompressIDX(byte[] data, int size, ref int resultsize)
        {
            byte[] index = null;
            int indexValue = 0;
            int indexSize;
            int i;
            int dataPosition, bufferPosition;
            int codeSize;
            int runLength;
            byte code;
            byte[] result;

            indexSize = data[0];
            MessageBox.Show(data[0].ToString(), "Value of Data 0 -- indexSize");

            Array.Copy(data, 1, index, 0, indexSize);
            //data[+= 1 + indexSize];

            size -= 1 + indexSize;





            return index;

        }


        /// <summary>
        /// decompressNDX - decompress ndx file compression.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="size"></param>
        /// <param name="resultsize"></param>
        /// <returns></returns>

        public static byte[] decompressNDX(byte[] data, int size, ref int resultsize)
        {
            byte[] result;
            byte[] buffer = new byte[200000];
            int bufpos;
            int datapos;
            int n;
            int pattern = 0;
            int i, j;
            int start, end, len;

            bufpos = datapos = 0;

            n = 0;
            while (datapos < size)
            {

                if (n % 9 == 0)
                {
                    /* every 9-th byte is a pattern for next 8 values */
                    pattern = data[datapos++];
                }
                else
                {
                    if (Convert.ToBoolean(pattern & 1))
                    {
                        /* if the pattern bit == 1 just copy the next byte */
                        buffer[bufpos++] = data[datapos++];
                    }
                    else
                    {
                        /* if the pattern bit == 0 we copy some substring of decoded data */

                        i = data[datapos++];
                        if (!(datapos < size))
                            break;
                        j = data[datapos++];


                        /* next 12 bits are starting position */
                        start = (byte)i + 16 * (byte)(j & 0xf0);
                        /* we add 0x12 (it is part of ndx format) */
                        start = start + 0x12 & 0xfff;

                        /* next 4 bits are length-3 */
                        len = (byte)(j & 0x0f) + 3;


                        if (start > bufpos)
                        {
                            /* it is unclear what to do in this case
                            fprintf( stderr, "lotr: wrongly decoded ndx archive %03x, %03x, %x\n", start, bufpos, len ); */

                            /* this works */

                            start -= 0x1000;
                            while (start < 0 && len > 0)
                            {
                                buffer[bufpos++] = 0x20;
                                ++start;
                                --len;
                            }
                        }

                        /* 12 bits can not encode too much:
                        the real starting position
                        is in the last segment of size 0x1000 */

                        if (start < bufpos % 0x1000)
                            start += bufpos / 0x1000 * 0x1000;
                        else if (bufpos > 0xfff)
                            start += (bufpos / 0x1000 - 1) * 0x1000;

                        end = start + len;

                        for (i = start; i < end; ++i)
                            buffer[bufpos++] = buffer[i];

                    }
                    pattern = pattern >> 1;

                }                       /* if( datapos%9==0 ) */

                ++n;

            }

            resultsize = bufpos;
            result = new byte[resultsize];
            //result = (uint8_t*)lotr_malloc(*resultsize);
            Buffer.BlockCopy(buffer, 0, result, 0, resultsize);
            return result;

        }



        /// <summary>
        /// decompressIDXArchive - reads decompressed data from archive.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="size"></param>
        /// <param name="resultsize"></param>
        /// <returns></returns>
        public static byte[] decompressIDXArchive(byte[] data, int size, ref int resultsize)
        {
            byte[] temp = null;
            return temp;

        }


        /// <summary>
        /// decompressNDXArchive - reads decompressed data from the archive.
        /// </summary>
        /// <param name="ar"></param>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static byte[] decompressNDXArchive(Archive ar, int index, ref int size)
        {
            byte[] result;
            byte[] data;
            data = ArchiveRead(ar, index);
            if (data != null)
            {
                result = decompressNDX(data, ArchiveDatasize(ar, index), ref size);

            }
            else
            {
                string message = "LOTR: Archive decompression failed index ";
                string value = index.ToString();
                string full = string.Concat(message, value);
                string caption = "decompressNDXArchive Archive Error!";
                MessageBox.Show(full, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = null;
            }

            return result;
        }


        public static byte[] getDataByte(string filename, int index, int size)
        {
            byte[] result;
            FileDetails datFile;
            Config cfg = new Config(true);
            datFile.Filename = filename;
            datFile.Path = cfg.GameDirectory; // config.ReadConfig();
            datFile.Suffix = "DAT";
            datFile.FullName = string.Concat(datFile.Path, "\\", datFile.Filename, ".", datFile.Suffix);
            FileInfo fi = new FileInfo(datFile.FullName);
            datFile.Size = (int)fi.Length;

            FileStream f1 = new FileStream(datFile.FullName, FileMode.Open);
            BinaryReader br1 = new BinaryReader(f1);
            br1.BaseStream.Seek(index, SeekOrigin.Begin);
            result = br1.ReadBytes(size);
            return result;
        }









    }
}



