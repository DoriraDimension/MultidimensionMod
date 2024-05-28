using System;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using MultidimensionMod.Projectiles;

namespace MultidimensionMod.Tiles.Biomes.Mire
{
    class DepthsandPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileBlendAll[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileSand[Type] = true;
            Main.tileMerge[Type][TileID.Sand] = true;
            Main.tileMerge[TileID.Sand][Type] = true;
            TileID.Sets.Suffocate[Type] = true;
            TileID.Sets.isDesertBiomeSand[Type] = true;
            TileID.Sets.Conversion.Sand[Type] = true;
            TileID.Sets.ForAdvancedCollision.ForSandshark[Type] = true;
            TileID.Sets.Falling[Type] = true;
            TileID.Sets.FallingBlockProjectile[Type] = new TileID.Sets.FallingBlockProjectileInfo(ModContent.ProjectileType<DepthsandBall>(), 10);
            TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;
            TileID.Sets.CanBeDugByShovel[Type] = true;
            TileID.Sets.GeneralPlacementTiles[Type] = false;
            TileID.Sets.ChecksForMerge[Type] = true;
            AddMapEntry(new Color(37, 33, 50));
            TileID.Sets.Conversion.Sand[Type] = true;
            DustType = ModContent.DustType<Dusts.BogwoodDust>();
        }

        public override void WalkDust(ref int dustType, ref bool makeDust, ref Color color)
        {
            dustType = ModContent.DustType<Dusts.BogwoodDust>();
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}