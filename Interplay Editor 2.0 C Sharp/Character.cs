using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interplay_Editor_2_C_Sharp
{
	public class Character
	{
		//public int x, y;
		//public int next_x, next_y;
		public enum SHAPE_SETS
		{
			CHARACTER_UP, 
			CHARACTER_RIGHT, 
			CHARACTER_DOWN, 
			CHARACTER_LEFT,
			CHARACTER_ATTACK,
			CHARACTER_STAY
		}

		public int map;
		//public int display_x, display_y;
		public int direction;

		public int action;
		public int state;
		public int shape_id;
		public Shape [] shapes;
		public int horse_shape_id;
		public int weapon_shape_id;
		public int portrait;

		public int dexterity;
		public int endurance;
		public int life;
		public int strength;
		public int luck;
		public int will;
		public int ap;
		
		public int silver;
		int last_eat;
		int x, y;
		int id;
		int map_id;
		int party_id;
		int willing_join;
		int ring_mode;
		int activated;
		public int[] skills;
		public int[] magic;
		public int[] items;


		public string strDirection;
		public struct SaveSummary
        {
			public int num;
			public string CName;
			public int offset;

        }

		public static string GetDirection(int value)
		{
			string result;
			switch (value)
			{
				case 1:
					result = "NORTH";
					break;
				case 2:
					result = "EAST";
					break;
				case 4:
					result = "SOUTH";
					break;
				case 8:
					result = "WEST";
					break;
				default:
					result = "SOUTH";
					break;

			}
			return result;

		}

		public static class Constants
		{
			public static int Save_Start = 2276;
			public static int Save_Increment = 256;
			public static int SaveBlock_Begin = 2221;
			public static int SaveCharEntries = 20;

		}

		public static SaveSummary ReadSaveFile(string filename, int index)
		{
			SaveSummary ss1;
			
			int a = index;
			using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
			{
					int filpost = Constants.Save_Start + (Constants.Save_Increment * a);
					reader.BaseStream.Position = filpost;
					byte[] dataArray = reader.ReadBytes(20);
					string name = Encoding.Default.GetString(dataArray);
					ss1.num = a;
					ss1.CName = name;
				ss1.offset = filpost;
				string str = Convert.ToString(ss1.offset);
			

			
			}
			return ss1;
        }

		public string Get_Item(int index)
		{
			string[] Game_Items = {
				"silver pennies",
				"Illuminate",
				"Unlock",
				"Firefinger",
				"Firestorm",
				"Knowledge",
				"Animal Speak",
				"Vine Crush",
				"Persuasion",
				"Black Breath",
				"Healing Hand",
				"Winterchill",
				"Sleeper",
				"Countermagic",
				"Blank",
				"Blank",
				"!Help Help",
				"!Elbereth",
				"!Bombadil",
				"!Angmar",
				"!Luthien",
				"!Beren",
				"!Yavanna",
				"!Mellon",
				"!Thorondor",
				"!Durin",
				"!Orome",
				"!Melian",
				"!Khazad",
				"!Sign of Seven",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Brawl",
				"Swords",
				"Axes",
				"Maces",
				"Flails",
				"Bows",
				"Dodge",
				"Hide",
				"Climb",
				"Swim",
				"Jump",
				"Perception",
				"Ride",
				"Picklock",
				"Sneak",
				"Read",
				"Charisma",
				"Detect Traps",
				"Devices",
				"Bravado",
				"Ironmind",
				"Boat",
				"Numenorean Lore",
				"Dwarf Lore",
				"Orc Lore",
				"Hobbit Lore",
				"Elven Lore",
				"Herb Lore",
				"Ranger Lore",
				"Wizard Lore",
				"Dark Lore",
				"Blank",
				"Blank",
				"Sting",
				"Barrow Dagger",
				"Anduril",
				"Glamdring",
				"Spider Sword",
				"Magic Bow",
				"Troll Slayer",
				"Durin's Axe",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Dagger",
				"Sword",
				"Staff",
				"Axe",
				"Mace",
				"Club",
				"Flail",
				"Bow",
				"Torch",
				"Knife",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Cloth Armor",
				"Leather Armor",
				"Chain Mail",
				"Magic Mail",
				"Mithril Mail",
				"Skin",
				"Hide",
				"Scales",
				"Shield",
				"Magic Shield",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"The Ring",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Rations",
				"Herb",
				"Prybar",
				"Bag End Key",
				"Star Key",
				"Ghost Ruby",
				"Athelas",
				"Bladepart",
				"Ale",
				"Gatekey",
				"Signet Ring",
				"Pipe",
				"Pipeweed",
				"Shovel",
				"Rope",
				"White Hand",
				"Pick",
				"Hot Food",
				"Token",
				"Dwarfwort",
				"Red Beans",
				"Bottle",
				"Light Gem",
				"Spring Stone",
				"Red Acorn",
				"Lilies",
				"Elf Draught",
				"Leaf Belt",
				"Black Key",
				"Rusty Key",
				"Black Book",
				"Gold Wheel",
				"Green Skull",
				"Balin Map",
				"Fundin Map",
				"Letter",
				"Golden Torc",
				"Arwen Token",
				"Black Cloak",
				"Miruvor",
				"reforge-ring",
				"wine bottle",
				"bronze key",
				"wight key",
				"silver horn",
				"elfstone",
				"starlight",
				"scabbard",
				"elven cape",
				"red key",
				"magic glass",
				"malach-key",
				"runerock",
				"elanor crown",
				"warm clothes",
				"spiritcharm",
				"gold ring",
				"Galadr-key",
				"beryl",
				"Smith's ring",
				"pony",
				"mushrooms",
				"Rose's token",
				"Broken wing",
				"Tinalin's cape",
				"White Wings",
				"Amulet",
				"Ice staff",
				"Gold Anvil",
				"Gold Chisel",
				"Gold Hammer",
				"Lady Token",
				"red fungus",
				"Durin's pick",
				"jewelry",
				"stone bLock",
				"mithril",
				"gem",
				"bag of gold",
				"wizard staff",
				"Eagle Gem",
				"lembas",
				"Horn of Gondor",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank",
				"Blank"
			};
			string result = Game_Items[index];
			return result;
		}
		string Get_Direction(int value)
        {
			string result = "";

			switch (value)
			{
				case '1':
					result = "NORTH";
					break;
				case '2':
					result = "EAST";
					break;
				case '4':
					result = "SOUTH";
					break;
				case '8':
					result = "WEST";
					break;
			}
			return result;
        }

	}

	public class FileSummary
    {
		public int ItemNumber;
		public string ItemName;
		public int ItemOffset;
    }

}

