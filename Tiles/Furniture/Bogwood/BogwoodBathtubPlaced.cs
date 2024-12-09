using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles.Furniture.Bogwood
{
    public class BogwoodBathtubPlaced : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
            TileObjectData.newTile.Origin = new Point16(2, 1);
            TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 18 };
			TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			//name.SetDefault("Bogwood Bathtub");
            AddMapEntry(new Color(12, 62, 205), name);
            DustType = ModContent.DustType<Dusts.BogwoodDust>();
		}

		
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 1;
		}
	}
}