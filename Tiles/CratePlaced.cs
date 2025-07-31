
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles
{
    internal class CratePlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            // Properties
            Main.tileFrameImportant[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileTable[Type] = true;

            // Placement
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = [16, 18];
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);

            // Etc
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.Banner"));
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            return false;
        }
    }
}