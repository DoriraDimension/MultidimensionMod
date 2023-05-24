using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles
{
	public class DimensionalForge : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.Width = 3;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
			TileID.Sets.DisableSmartCursor[Type] = true;
			TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(35, 189, 236), name);
			DustType = ModContent.DustType<DimensionDust1>();
			AnimationFrameHeight = 38;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 5;
		}

		public override void AnimateTile(ref int frame, ref int frameCounter)
		{

			frameCounter++;
			if (frameCounter > 6) 
			{
				frameCounter = 0;
				frame++;
				if (frame > 5)
				{
					frame = 0;
				}
			}
		}
	}
}