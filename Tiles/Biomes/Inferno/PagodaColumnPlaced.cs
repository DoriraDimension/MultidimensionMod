﻿using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Tiles.Biomes.Inferno
{
    public class PagodaColumnPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<VolcanicRockPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<PagodaBrickPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<PagodaFloorPlaced>()] = true;
            Main.tileBlendAll[Type] = false;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(153, 100, 0));
            MinPick = 210;
        }

        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}