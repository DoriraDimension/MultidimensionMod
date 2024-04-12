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
    public class RazewoodTablePlaced : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.IgnoredByNpcStepUp[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.Origin = new Point16(1, 1);
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(Type);
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
			LocalizedText name = CreateMapEntryName();
			//name.SetDefault("Razewood Table");
            AddMapEntry(new Color(205, 62, 12), name);
            DustType = ModContent.DustType<Dusts.RazewoodDust>();
            AdjTiles = new int[] { TileID.Tables };

        }

		
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}
