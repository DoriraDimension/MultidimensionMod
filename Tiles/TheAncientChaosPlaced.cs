using MultidimensionMod.Items.Placeables;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using System;

namespace MultidimensionMod.Tiles
{
    public class TheAncientChaosPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Origin = new Point16(2, 2);
            TileObjectData.newTile.Height = 5;
            TileObjectData.newTile.Width = 5;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 16, 16 };
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(99, 22, 112), name);
            DustType = -1;
        }
    }
}