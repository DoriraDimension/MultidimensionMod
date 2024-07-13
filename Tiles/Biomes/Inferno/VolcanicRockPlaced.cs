﻿using MultidimensionMod.Tiles.Ores;
using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using Terraria.Audio;

namespace MultidimensionMod.Tiles.Biomes.Inferno
{
    public class VolcanicRockPlaced : ModTile
    {
        public static readonly SoundStyle MineSound = new SoundStyle("MultidimensionMod/Sounds/Tiles/VolcanoHit", 3);
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<IncineriteOre>()] = true;
            Main.tileMerge[Type][ModContent.TileType<VolcanicRockDensePlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<TorchstonePlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<AwakenedRockPlaced>()] = true;
            Main.tileMerge[Type][ModContent.TileType<PagodaColumnPlaced>()] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            TileID.Sets.GeneralPlacementTiles[Type] = false;
            HitSound = VolcanicRockPlaced.MineSound;
            DustType = ModContent.DustType<RazewoodDust>();
            AddMapEntry(new Color(50, 25, 12));
            MinPick = 210;
        }

        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}