using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.Localization;

namespace MultidimensionMod.Tiles.Furniture.Razewood
{
    public class RazewoodPianoPlaced : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.Origin = new Point16(1, 1);
			TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.addTile(Type);
			LocalizedText name = CreateMapEntryName();
			//name.SetDefault("Razewood Piano");
            AddMapEntry(new Color(205, 62, 12), name);
            DustType = ModContent.DustType<Dusts.RazewoodDust>();
            AdjTiles = new int[] { TileID.Pianos };
        }

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}
