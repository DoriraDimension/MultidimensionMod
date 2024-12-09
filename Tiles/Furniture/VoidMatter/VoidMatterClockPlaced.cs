using MultidimensionMod.Items.Placeables.Furniture.VoidMatter;
using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles.Furniture.VoidMatter
{
	public class VoidMatterClockPlaced : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Origin = new Point16(1, 4);
            TileObjectData.newTile.Height = 5;
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 16, 18 };
			TileID.Sets.DisableSmartCursor[Type] = true;
			TileID.Sets.Clock[Type] = true;
			TileID.Sets.HasOutlines[Type] = true;
			AdjTiles = new int[] { TileID.GrandfatherClocks };
			TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Void Matter Clock");
			AddMapEntry(new Color(25, 19, 39), name);
			DustType = ModContent.DustType<DarkDust>();
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 1;
		}

		public override bool RightClick(int i, int j)
		{
			string text = "AM";

			double time = Main.time;

			if (!Main.dayTime)
			{
				time += 54000.0;
			}

			time = time / 86400.0 * 24.0;
			time = time - 7.5 - 12.0;

			if (time < 0.0)
			{
				time += 24.0;
			}
			else if (time >= 12.0)
			{
				text = "PM";
			}

			int intTime = (int)time;

			double deltaTime = time - intTime;

			deltaTime = (int)(deltaTime * 60.0);

			string text2 = string.Concat(deltaTime);

			if (deltaTime < 10.0)
			{
				text2 = "0" + text2;
			}

			if (intTime > 12)
			{
				intTime -= 12;
			}
			else if (intTime == 0)
			{
				intTime = 12;
			}

			var newText = string.Concat("Time: ", intTime, ":", text2, " ", text);

			Main.NewText(newText, new Color(255, 240, 20));

			return true;
		}
	}
}