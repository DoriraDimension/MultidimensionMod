using MultidimensionMod.Tiles.Ores;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace MultidimensionMod
{
	public class MDWorld : ModWorld
	{
		public static bool downedSmiley;

		public override void Initialize()
		{
			downedSmiley = false;
		}
		public override TagCompound Save()
		{
			var downed = new List<string>();
			if (downedSmiley)
			{
				downed.Add("smiley");
			}

			return new TagCompound
			{
				["downed"] = downed
			};
		}
		public override void Load(TagCompound tag)
		{
			var downed = tag.GetList<string>("downed");
			downedSmiley = downed.Contains("smiley");
		}
		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				downedSmiley = flags[0];
			}
			else
			{
				ErrorLogger.Log("Multidimension Mod: Unknown loadVersion: " + loadVersion);
			}
		}
		public override void NetSend(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags[0] = downedSmiley;
			writer.Write(flags);
		}
		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			downedSmiley = flags[0];
		}

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			// Because world generation is like layering several images ontop of each other, we need to do some steps between the original world generation steps.

			// The first step is an Ore. Most vanilla ores are generated in a step called "Shinies", so for maximum compatibility, we will also do this.
			// First, we find out which step "Shinies" is.
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex != -1)
			{
				// Next, we insert our step directly after the original "Shinies" step. 
				// ExampleModOres is a method seen below.
				tasks.Insert(ShiniesIndex + 1, new PassLegacy("Dimension Travelling Leftovers", MDOres));
			}
		}

		private void MDOres(GenerationProgress progress)
		{
			// progress.Message is the message shown to the user while the following code is running. Try to make your message clear. You can be a little bit clever, but make sure it is descriptive enough for troubleshooting purposes. 
			progress.Message = "Dimension Travelling Leftovers";

			// Ores are quite simple, we simply use a for loop and the WorldGen.TileRunner to place splotches of the specified Tile in the world.
			// "6E-05" is "scientific notation". It simply means 0.00006 but in some ways is easier to read.
			for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00006); k++)
			{
				// The inside of this for loop corresponds to one single splotch of our Ore.
				// First, we randomly choose any coordinate in the world by choosing a random x and y value.
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.

				// Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place. Feel free to experiment with strength and step to see the shape they generate.
				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<Dimensium>());
			}
		}
	}
}