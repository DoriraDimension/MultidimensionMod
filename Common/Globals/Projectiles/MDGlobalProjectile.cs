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
using System.Drawing;
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
                SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/Gunshot"), projectile.position);
            }
            base.OnSpawn(projectile, source);
        }

        public override void AI(Projectile projectile)
        {
            if (projectile.owner == Main.myPlayer && projectile.type == Terraria.ID.ProjectileID.PureSpray)
                ConvertMush((int)(projectile.position.X + projectile.width / 2) / 16, (int)(projectile.position.Y + projectile.height / 2) / 16, 2);
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
                    else if (tileType == ModContent.TileType<MushroomBlockPlaced>())
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
    }
}