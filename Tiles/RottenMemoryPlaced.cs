using MultidimensionMod.Items.Placeables;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace MultidimensionMod.Tiles
{
    public class RottenMemoryPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Origin = new Point16(2, 3);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Width = 5;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 18 };
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(47, 54, 88), name);
            DustType = 41;
        }
    }
}