using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Localization;

namespace MultidimensionMod.Tiles.Furniture.Razewood
{
    public class RazewoodSinkPlaced : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true; 
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			//name.SetDefault("Razewood Sink");
            AddMapEntry(new Color(205, 62, 12), name);
            DustType = ModContent.DustType<Dusts.RazewoodDust>();
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}