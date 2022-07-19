using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interplay_Editor_2_C_Sharp.Classes;



namespace Interplay_Editor_2_C_Sharp
{
	public class Portrait
	{	
		public static readonly int PORTRAITS_NUM = 46;
		public static readonly int TTT_PORTRAITS = 67;
		public int width;
		public int height;
		public int datasize;
		public byte[] data;
		public byte[] palette;
		

		//Default portrait constructor.
		public Portrait(int dsize)
        {
			this.width = 68;
            this.height = 54;
			this.datasize = 3672;
			this.data = new byte[dsize];
			this.palette = new byte[1298];

		}
		

		public static List<Portrait>  initPortraits()
		{
			// Initializes character portraits and adds each portrait to list.

			Archive pArchive;
			//Portrait t_portrait = new Portrait();
			List<Portrait> portraitsCache = new List<Portrait>();
			byte[] pData;
			int size=0;
			pArchive = Archive.NDXOpen("PORTRAIT");
			//MessageBox.Show("ndxOpen Complete!  pArchive populated.","initPortraits() Status");

			if (pArchive.IndexSize != PORTRAITS_NUM)
            {
				string message = "lotr: Quantity of portraits not matched.  Expecting ";
				string m2 = " portraits (";
				string m3 = " found.)";
				string val = PORTRAITS_NUM.ToString();
				string val2 = pArchive.Size.ToString();
				string errormsg=string.Concat(message, val, m2, val2, m3);
				MessageBox.Show(errormsg, "initPortraits Error");
				System.Windows.Forms.Application.ExitThread();
            }
			for (int i = 0; i < PORTRAITS_NUM;i++)
            {
				if (i == 35)
					i = 36;
				pData = Archive.decompressNDXArchive(pArchive, i, ref size);
				Portrait t_portrait = new Portrait(size);


				if (size == 4970 || size == 3768)
				{
					t_portrait.data = pData;
					int start = (t_portrait.datasize);
			        // Initialize palette array.  R.G,B for 256 bytes (786).
					if (size == 4970)
					{
						//MessageBox.Show(size.ToString(),"Portrait Size!");
						int palsize = pData.Length - pData[t_portrait.datasize];
						// Portrait palette starts at byte 0x60(96).  Loads zero values for first 96 colors.
						for (int j = 0; j < (96 * 3); j++)
						{
							t_portrait.palette[j] = 0;
						}

						// Populate palette from bytes 96-128.
						for (int k = (96*3); k < (128*3); k++)
						{
							// Adds first 32 colors for palette to 96th slot in portrait palette.
							t_portrait.palette[k] = pData[start++];
						}
						
						//Populate palette from 128-256.
						for (int l = (128*3); l < (256*3); l++)
                        {
							t_portrait.palette[l] = 0;
						}
						

					}
					else
					{
						//MessageBox.Show(size.ToString(), "Portrait Size!");
						//memcpy(void *dest, const void src, # of bytes copied)

						// fill palette at (0x60 * 3), from data pointer from dataszize position for 0x60 bytes.


						int palsize = pData.Length - pData[t_portrait.datasize];
						// Portrait palette starts at byte 0x60(96).  
						

					}

				}
				portraitsCache.Add(t_portrait);
			}
			return portraitsCache;
	}







	}
}
