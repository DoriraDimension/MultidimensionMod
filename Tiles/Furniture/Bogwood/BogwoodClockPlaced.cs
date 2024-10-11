using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles.Furniture.Bogwood
{
    public class BogwoodClockPlaced : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Height = 5;
			TileObjectData.newTile.CoordinateHeights = new int[] {16, 16, 16, 16, 16};
			TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(12, 62, 205), name);
			DustType = ModContent.DustType<Dusts.BogwoodDust>();
			AdjTiles = new int[] { TileID.GrandfatherClocks };
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

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
    }
}