﻿using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles.Furniture.RedMush
{
    public class RedMushSofaPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.addTile(Type);

            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(120, 90, 0), name);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
            AdjTiles = new int[] { TileID.Benches };
            DustType = ModContent.DustType<MushroomDust>();
        }
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
    }
}