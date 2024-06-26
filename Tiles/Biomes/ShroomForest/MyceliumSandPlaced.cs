﻿using MultidimensionMod.Items.Placeables.Biomes.ShroomForest;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.DataStructures;
using Terraria.Audio;

namespace MultidimensionMod.Tiles.Biomes.ShroomForest
{
    public class MyceliumSandPlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<Mycelium>()] = true;
            Main.tileMerge[ModContent.TileType<Mycelium>()][Type] = true;
            Main.tileMerge[Type][ModContent.TileType<MyceliumSandstonePlaced>()] = true;
            Main.tileMerge[ModContent.TileType<MyceliumSandstonePlaced>()][Type] = true;
            Main.tileMerge[Type][ModContent.TileType<MyceliumHardsandPlaced>()] = true;
            Main.tileMerge[ModContent.TileType<MyceliumHardsandPlaced>()][Type] = true;
            Main.tileMerge[Type][TileID.Sand] = true;
            Main.tileMerge[TileID.Sand][Type] = true;
            Main.tileMerge[Type][TileID.Ebonsand] = true;
            Main.tileMerge[TileID.Ebonsand][Type] = true;
            Main.tileMerge[Type][TileID.Crimsand] = true;
            Main.tileMerge[TileID.Crimsand][Type] = true;
            Main.tileMerge[Type][TileID.Pearlsand] = true;
            Main.tileMerge[TileID.Pearlsand][Type] = true;
            Main.tileBlendAll[Type] = true;
            Main.tileSand[Type] = true;
            TileID.Sets.Suffocate[Type] = true;
            TileID.Sets.isDesertBiomeSand[Type] = true;
            TileID.Sets.Conversion.Sand[Type] = true;
            TileID.Sets.ForAdvancedCollision.ForSandshark[Type] = true;
            TileID.Sets.Falling[Type] = true;
            TileID.Sets.FallingBlockProjectile[Type] = new TileID.Sets.FallingBlockProjectileInfo(ModContent.ProjectileType<MyceliumSandBall>(), 10);
            TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;
            TileID.Sets.CanBeDugByShovel[Type] = true;
            TileID.Sets.GeneralPlacementTiles[Type] = false;
            TileID.Sets.ChecksForMerge[Type] = true;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(195, 125, 56));
            DustType = DustID.Sand;
        }

        public override bool HasWalkDust()
        {
            return Main.rand.NextBool(3);
        }

        public override void WalkDust(ref int dustType, ref bool makeDust, ref Color color)
        {
            dustType = DustID.Sand;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void RandomUpdate(int i, int j)
        {
            WorldGen.SpreadGrass(i + Main.rand.Next(-1, 1), j + Main.rand.Next(-1, 1), TileID.Dirt, Type, false);
            if (Main.rand.NextBool(60))
            {
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<AridMushroom>(), mute: true, style: Main.rand.Next(5));
                NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<AridMushroom>(), Main.rand.Next(5), 0, -1, -1);
            }
            if (Main.rand.NextBool(2500))
            {
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<KingsCapPlaced>(), mute: true);
                NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<KingsCapPlaced>(), Main.rand.Next(5), 0, -1, -1);
            }
        }
    }
    public class MyceliumSandBall : ModProjectile
    {
        protected bool falling = true;
        protected int tileType;
        protected int dustType;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.ForcePlateDetection[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.knockBack = 6f;
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            tileType = ModContent.TileType<MyceliumSandPlaced>();
            dustType = DustID.Sand;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(5))
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustType);
                Main.dust[dust].velocity.X *= 0.4f;
            }

            Projectile.tileCollide = true;
            Projectile.localAI[1] = 0f;

            if (Projectile.ai[0] == 1f)
            {
                if (!falling)
                {
                    Projectile.ai[1] += 1f;

                    if (Projectile.ai[1] >= 60f)
                    {
                        Projectile.ai[1] = 60f;
                        Projectile.velocity.Y += 0.2f;
                    }
                }
                else
                    Projectile.velocity.Y += 0.41f;
            }
            else if (Projectile.ai[0] == 2f)
            {
                Projectile.velocity.Y += 0.2f;

                if (Projectile.velocity.X < -0.04f)
                    Projectile.velocity.X += 0.04f;
                else if (Projectile.velocity.X > 0.04f)
                    Projectile.velocity.X -= 0.04f;
                else
                    Projectile.velocity.X = 0f;
            }

            Projectile.rotation += 0.1f;

            if (Projectile.velocity.Y > 10f)
                Projectile.velocity.Y = 10f;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hithoxCenterFrac)
        {
            if (falling)
                Projectile.velocity = Collision.AnyCollision(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height, true);
            else
                Projectile.velocity = Collision.TileCollision(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height, fallThrough, fallThrough, 1);

            return false;
        }

        public override void OnKill(int timeLeft)
        {
            if (Projectile.owner == Main.myPlayer && !Projectile.noDropItem)
            {
                int tileX = (int)(Projectile.position.X + Projectile.width / 2) / 16;
                int tileY = (int)(Projectile.position.Y + Projectile.width / 2) / 16;

                Tile tile = Framing.GetTileSafely(tileX, tileY);
                Tile tileBelow = Main.tile[tileX, tileY + 1];

                if (tile.IsHalfBlock && Projectile.velocity.Y > 0f && Math.Abs(Projectile.velocity.Y) > Math.Abs(Projectile.velocity.X))
                    tileY--;

                if (!tile.HasTile)
                {
                    bool onMinecartTrack = tileY < Main.maxTilesY - 2 && tileBelow != null && tileBelow.HasTile && tileBelow.TileType == TileID.MinecartTrack;

                    if (!onMinecartTrack)
                    {
                        WorldGen.PlaceTile(tileX, tileY, tileType, false, true);
                    }
                    else
                    {
                        Item.NewItem(Projectile.GetSource_DropAsItem(), (int)Projectile.position.X, (int)Projectile.position.Y, Projectile.width, Projectile.height, ModContent.ItemType<MyceliumSand>());
                    }

                    if (!onMinecartTrack && tile.HasTile && tile.TileType == tileType)
                    {
                        if (tileBelow.IsHalfBlock || tileBelow.Slope != 0)
                        {
                            WorldGen.SlopeTile(tileX, tileY + 1, 0);

                            if (Main.netMode == NetmodeID.Server)
                                NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 14, tileX, tileY + 1);
                        }

                        if (Main.netMode != NetmodeID.SinglePlayer)
                            NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, tileX, tileY, tileType);
                    }
                }
                else
                {
                    Item.NewItem(Projectile.GetSource_DropAsItem(), (int)Projectile.position.X, (int)Projectile.position.Y, Projectile.width, Projectile.height, ModContent.ItemType<MyceliumSand>());
                }
            }
        }
    }
}