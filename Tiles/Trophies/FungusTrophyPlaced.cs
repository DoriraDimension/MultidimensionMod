using MultidimensionMod.Items.Placeables.Trophies;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using System;

namespace MultidimensionMod.Tiles.Trophies
{
    public class FungusTrophyPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.addTile(Type);
            DustType = 7;
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(120, 85, 60), name);
        }
    }
}