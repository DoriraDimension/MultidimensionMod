using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Common.Players;
using Terraria.DataStructures;
using Terraria.Audio;
using MultidimensionMod.NPCs.TownNPCs;
using MultidimensionMod.Tiles.Biomes.FrozenUnderworld;
using System;
using MultidimensionMod.Tiles.Biomes.ShroomForest;
using MultidimensionMod.Walls;

namespace MultidimensionMod.Common.Globals.Projectiles
{
    public class MDGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public bool CantHurtDapper;

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (source is EntitySource_Parent parent && parent.Entity is NPC npc && npc.type == ModContent.NPCType<MushroomHeir>())
            {
                SoundEngine.PlaySound(Sounds.CustomSounds.Gunshot with { Volume = 0.70f }, projectile.position);
            }
            base.OnSpawn(projectile, source);
        }

        public override bool PreAI(Projectile projectile)
        {
            if (projectile.owner == Main.myPlayer && (projectile.aiStyle == 61 || projectile.bobber) && projectile.shimmerWet)
            {
                Player player = Main.player[projectile.owner];
                MDPlayer modPlayer = player.GetModPlayer<MDPlayer>();
                if (modPlayer.shimmerProofHook)
                {
                    player.buffImmune[BuffID.Shimmer] = true;
                    modPlayer.currentlyShimmerFishing = true;
                }
            }
            return base.PreAI(projectile);
        }

        public override void AI(Projectile projectile)
        {
            Player player = Main.LocalPlayer;
            MDPlayer mdPlayer = Main.player[projectile.owner].GetModPlayer<MDPlayer>();
            if (projectile.owner == Main.myPlayer && projectile.type == Terraria.ID.ProjectileID.PureSpray)
                ConvertMush((int)(projectile.position.X + projectile.width / 2) / 16, (int)(projectile.position.Y + projectile.height / 2) / 16, 2);
            if (projectile.owner == Main.myPlayer && projectile.type == Terraria.ID.ProjectileID.MushroomSpray)
                ConvertMushDB((int)(projectile.position.X + projectile.width / 2) / 16, (int)(projectile.position.Y + projectile.height / 2) / 16, 2);
            if (projectile.aiStyle == 7)
            {
                if (player.GetModPlayer<MDPlayer>().chaosClaw)
                {
                    Rectangle rectangle = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
                    for (int e = 0; e < Main.maxNPCs; e++)
                    {
                        NPC npc = Main.npc[e];
                        if (rectangle.Intersects(npc.Hitbox))
                        {
                            npc.AddBuff(BuffID.OnFire, 360);
                            npc.AddBuff(BuffID.Poisoned, 360);
                        }
                    }
                }
            }
            if (mdPlayer.shimmerProofHook && (projectile.aiStyle == 61 || projectile.bobber) && projectile.shimmerWet && projectile.ai[1] < 0f)
            {
                if (Math.Abs(projectile.velocity.Y) <= 0.01f)
                {
                    projectile.velocity.Y = (float)Main.rand.Next(100, 500) * 0.015f;
                    projectile.velocity.X = (float)Main.rand.Next(-100, 101) * 0.015f;
                    projectile.wet = false;
                    projectile.lavaWet = false;
                    projectile.honeyWet = false;
                    projectile.shimmerWet = false;
                    projectile.netUpdate = true;
                }
                projectile.ai[1] += Main.rand.Next(1, 5);
                if (projectile.ai[1] >= 0f)
                {
                    projectile.ai[1] = 0f;
                    projectile.localAI[1] = 0f;
                    projectile.netUpdate = true;
                }
            }
        }

        public void ConvertMushDB(int i, int j, int size = 4)
        {
            for (int k = i - size; k <= i + size; k++)
            {
                for (int l = j - size; l <= j + size; l++)
                {
                    if (!WorldGen.InWorld(k, l, 1) || !(Math.Abs(l - j) < Math.Sqrt(size * size + size * size)))
                    {
                        continue;
                    }

                    int tileType = Main.tile[k, l].TileType;
                    if (tileType == ModContent.TileType<MushroomBlockPlaced>())
                    {
                        Main.tile[k, l].TileType = TileID.MushroomBlock;
                        WorldGen.SquareTileFrame(k, l, true);
                        NetMessage.SendTileSquare(-1, k, l, 1);
                        break;
                    }

                    int wallType = Main.tile[k, l].WallType;
                    if (wallType == ModContent.WallType<MushroomBlockWallPlaced>())
                    {
                        Main.tile[k, l].WallType = WallID.Mushroom;
                        WorldGen.SquareWallFrame(k, l, true);
                        NetMessage.SendTileSquare(-1, k, l, 1);
                        break;
                    }
                }
            }
        }

        public void ConvertMush(int i, int j, int size = 4)
        {
            for (int k = i - size; k <= i + size; k++)
            {
                for (int l = j - size; l <= j + size; l++)
                {
                    if (!WorldGen.InWorld(k, l, 1) || !(Math.Abs(l - j) < Math.Sqrt(size * size + size * size)))
                    {
                        continue;
                    }

                    int tileType = Main.tile[k, l].TileType;

                    if (tileType == ModContent.TileType<Mycelium>())
                    {
                        Main.tile[k, l].TileType = TileID.Grass;
                        WorldGen.SquareTileFrame(k, l, true);
                        NetMessage.SendTileSquare(-1, k, l, 1);
                        break;
                    }
                    else if (tileType == ModContent.TileType<SporeStonePlaced>())
                    {
                        Main.tile[k, l].TileType = TileID.Stone;
                        WorldGen.SquareTileFrame(k, l, true);
                        NetMessage.SendTileSquare(-1, k, l, 1);
                        break;
                    }
                }
            }
        }

        public override void GrapplePullSpeed(Projectile projectile, Player player, ref float speed)
        {
            if (player.GetModPlayer<MDPlayer>().chaosClaw)
            {
                speed *= 1.3f;
            }
        }
    }
}