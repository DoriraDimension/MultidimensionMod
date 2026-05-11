using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace MultidimensionMod.Tiles.Furniture.RedMush
{
    public class RedMushWorkBenchPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileTable[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.IgnoredByNpcStepUp[Type] = true;
            DustType = ModContent.DustType<MushroomDust>();
            AdjTiles = new int[] { TileID.WorkBenches };
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.Origin = new Point16(1, 0);
            TileObjectData.newTile.CoordinateHeights = new[] { 18 };
            TileObjectData.addTile(Type);

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            AddMapEntry(new Color(120, 90, 0));
        }

        public override void NumDust(int x, int y, bool fail, ref int num) => num = fail ? 1 : 3;
    }
}