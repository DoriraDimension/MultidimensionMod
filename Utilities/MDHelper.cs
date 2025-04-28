using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Base;
using MultidimensionMod.Common.Globals.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.Player;

namespace MultidimensionMod.Utilities
{
    public static class MDHelper
    {
        public static Vector2 GetOrigin(Texture2D tex, int frames = 1)
        {
            return new(tex.Width / 2f, tex.Height / frames / 2);
        }

        public static Vector2 GetOrigin(Rectangle rect, int frames = 1)
        {
            return new(rect.Width / 2f, rect.Height / frames / 2f);
        }

        public static bool AnyProjectiles(int projectileID)
        {
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile p = Main.projectile[i];
                if (p.type != projectileID || !p.active)
                    continue;

                return true;
            }

            return false;
        }

        //Adapted from Calamity
        /// <summary>
        /// A simple to use helper method to create rain projectiles similar to the Star Cloak stars or Daedalus Stormbow
        /// </summary>
        /// <param name="source">The source of the projectile</param>
        /// <param name="targetPos">Position of the targeted entity</param>
        /// <param name="xLimit">Horizontal range limit of the projectiles</param>
        /// <param name="xVariance">Horizontal range variation of the pojectiles</param>
        /// <param name="yLimitLower">Vertical lower height limit. Determines the lowest possible spawn location</param>
        /// <param name="yLimitUpper">Vertical upper height limit. Determines the highest possible spawn location</param>
        /// <param name="projSpeed">The speed of the projectile</param>
        /// <param name="projType">Which projectile to use</param>
        /// <param name="damage">Damage of the projectile</param>
        /// <param name="knockback">Knockback of the projectile</param>
        /// <param name="owner">Owner of the projectile</param>
        /// <returns></returns>
        public static Projectile ProjectileRain(IEntitySource source, Vector2 targetPos, float xLimit, float xVariance, float yLimitLower, float yLimitUpper, float projSpeed, int projType, int damage, float knockback, int owner)
        {
            float x = targetPos.X + Main.rand.NextFloat(-xLimit, xLimit);
            float y = targetPos.Y - Main.rand.NextFloat(yLimitLower, yLimitUpper);
            Vector2 spawnPosition = new Vector2(x, y);
            Vector2 velocity = targetPos - spawnPosition;
            velocity.X += Main.rand.NextFloat(-xVariance, xVariance);
            float speed = projSpeed;
            float targetDist = velocity.Length();
            targetDist = speed / targetDist;
            velocity.X *= targetDist;
            velocity.Y *= targetDist;
            return Projectile.NewProjectileDirect(source, spawnPosition, velocity, projType, damage, knockback, owner);


        }

        //Adapted from Calamity
        /// <summary>
        /// Retrieves the currently strongest class boost the player has. Can be used to grant certain projectiles damage boosts from the player's class specific accessories and buffs.
        /// </summary>
        /// <param name="player">The owner of the damage source to be boosted</param>
        /// <returns></returns>
        public static StatModifier GetBestClassDamage(this Player player)
        {
            StatModifier ret = StatModifier.Default;
            StatModifier classless = player.GetTotalDamage<GenericDamageClass>();

            // Atypical damage stats are copied from "classless", like Avenger Emblem. This prevents stacking flat damage effects repeatedly.
            ret.Base = classless.Base;
            ret *= classless.Multiplicative;
            ret.Flat = classless.Flat;

            // Check all four classes to see which one is the strongest, and use that for the typical damage stat.
            float best = 1f;

            float melee = player.GetTotalDamage<MeleeDamageClass>().Additive;
            if (melee > best) best = melee;
            float ranged = player.GetTotalDamage<RangedDamageClass>().Additive;
            if (ranged > best) best = ranged;
            float magic = player.GetTotalDamage<MagicDamageClass>().Additive;
            if (magic > best) best = magic;

            // Summoner intentionally has a reduction. As the only class with no crit, it tends to have higher raw damage than other classes.
            float summon = player.GetTotalDamage<SummonDamageClass>().Additive /** BalancingConstants.SummonAllClassScalingFactor*/;
            if (summon > best) best = summon;
            // We intentionally don't check whip class, because it inherits 100% from Summon

            // Add the best typical damage stat, then return the full modifier.
            ret += best - 1f;
            return ret;
        }

        /// <summary>
        /// Checks if the player's inventory contains the specified item
        /// </summary>
        /// <param name="player"></param>
        /// <param name="items">The desired item</param>
        /// <returns></returns>
        public static bool HasInInventory(this Player player, params int[] items)
        {
            return player.inventory.Any(item => items.Contains(item.type));
        }

        //Fishing condition for Shimmer (does nothing)
        public static bool InShimmer(this FishingAttempt attempt)
        {
            for (int e = 0; e < Main.maxProjectiles; e++)
            {
                Projectile projectile = Main.projectile[e];
                if (projectile.bobber && projectile.shimmerWet)
                    continue;

                return true;
            }
            return false;
        }

        public static object GetFieldValue(this Type type, string fieldName, object obj = null, BindingFlags? flags = null)
        {
            if (flags == null)
            {
                flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;
            }
            FieldInfo field = type.GetField(fieldName, flags.Value);
            return field.GetValue(obj);
        }

        public static T GetFieldValue<T>(this Type type, string fieldName, object obj = null, BindingFlags? flags = null)
        {
            if (flags == null)
            {
                flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;
            }
            FieldInfo field = type.GetField(fieldName, flags.Value);
            return (T)field.GetValue(obj);
        }

        //Some uh AA stuff here
        public static int GetFirstTileFloor(int x, int startY, bool solid = true)
        {
            if (!WorldGen.InWorld(x, startY)) return startY;
            for (int y = startY; y < Main.maxTilesY - 10; y++)
            {
                Tile tile = Framing.GetTileSafely(x, y);
                if (tile is { HasTile: true } && (!solid || Main.tileSolid[tile.TileType])) { return y; }
            }
            return Main.maxTilesY - 10;
        }

        public static Vector2 FindGroundVector(this Terraria.NPC npc, Vector2 vector, int distFromVector, Func<int, int, bool> canTeleportTo = null)
        {
            int vectorX = (int)vector.X / 16;
            int vectorY = (int)vector.Y / 16;
            int tileX = (int)npc.position.X / 16;
            int tileY = (int)npc.position.Y / 16;
            int teleportCheckCount = 0;

            while (teleportCheckCount < 1000)
            {
                teleportCheckCount++;
                int tpTileX = Main.rand.Next(vectorX - distFromVector, vectorX + distFromVector);
                int tpTileY = Main.rand.Next(vectorY - distFromVector, vectorY + distFromVector);
                for (int tpY = tpTileY; tpY < vectorY + distFromVector; tpY++)
                {
                    if ((tpY < vectorY - 4 || tpY > vectorY + 4 || tpTileX < vectorX - 4 || tpTileX > vectorX + 4) &&
                        (tpY < tileY - 1 || tpY > tileY + 1 || tpTileX < tileX - 1 || tpTileX > tileX + 1) &&
                        Framing.GetTileSafely(tpTileX, tpY).HasUnactuatedTile)
                    {
                        if (canTeleportTo != null && canTeleportTo(tpTileX, tpY) ||
                            Main.tile[tpTileX, tpY - 1].LiquidType != 2 &&
                            (Main.tileSolid[Framing.GetTileSafely(tpTileX, tpY).TileType] || Main.tileSolidTop[Framing.GetTileSafely(tpTileX, tpY).TileType]) &&
                            !Collision.SolidTiles(tpTileX - 1, tpTileX + 1, tpY - 4, tpY - 1))
                        {
                            return new Vector2(tpTileX, tpY) * 16;
                        }
                    }
                }
            }
            return new Vector2(npc.Center.X, npc.Center.Y);
        }

        //Adapted from Calamity
        /// <summary>
        /// Checks if the given npc is a boss
        /// </summary>
        /// <param name="npc"></param>
        /// <returns></returns>
        public static bool IsABoss(this NPC npc)
        {
            if (npc is null || !npc.active)
                return false;
            if (npc.boss && npc.type != NPCID.MartianSaucerCore)
                return true;
            return npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsTail;
        }

        //Adapted from Calamity
        /// <summary>
        /// Detects nearby hostile NPCs from a given point. Used for homing projectiles and similar
        /// </summary>
        /// <param name="origin">The position where we wish to check for nearby NPCs</param>
        /// <param name="maxDistanceToCheck">Maximum amount of pixels to check around the origin</param>
        /// <param name="ignoreTiles">Whether to ignore tiles when finding a target or not</param>
        /// <param name="bossPriority">Whether bosses should be prioritized in targetting or not</param>
        public static NPC ClosestNPCAt(this Vector2 origin, float maxDistanceToCheck, bool ignoreTiles = true, bool bossPriority = false)
        {
            NPC closestTarget = null;
            float distance = maxDistanceToCheck;
            if (bossPriority)
            {
                bool bossFound = false;
                for (int index = 0; index < Main.npc.Length; index++)
                {
                    // If we've found a valid boss target, ignore ALL targets which aren't bosses.
                    if (bossFound && !(Main.npc[index].boss || Main.npc[index].type == NPCID.WallofFleshEye))
                        continue;

                    if (Main.npc[index].CanBeChasedBy(null, false))
                    {
                        float extraDistance = (Main.npc[index].width / 2) + (Main.npc[index].height / 2);

                        bool canHit = true;
                        if (extraDistance < distance && !ignoreTiles)
                            canHit = Collision.CanHit(origin, 1, 1, Main.npc[index].Center, 1, 1);

                        if (Vector2.Distance(origin, Main.npc[index].Center) < distance && canHit)
                        {
                            if (Main.npc[index].boss || Main.npc[index].type == NPCID.WallofFleshEye)
                                bossFound = true;

                            distance = Vector2.Distance(origin, Main.npc[index].Center);
                            closestTarget = Main.npc[index];
                        }
                    }
                }
            }
            else
            {
                for (int index = 0; index < Main.npc.Length; index++)
                {
                    if (Main.npc[index].CanBeChasedBy(null, false))
                    {
                        float extraDistance = (Main.npc[index].width / 2) + (Main.npc[index].height / 2);

                        bool canHit = true;
                        if (extraDistance < distance && !ignoreTiles)
                            canHit = Collision.CanHit(origin, 1, 1, Main.npc[index].Center, 1, 1);

                        if (Vector2.Distance(origin, Main.npc[index].Center) < distance && canHit)
                        {
                            distance = Vector2.Distance(origin, Main.npc[index].Center);
                            closestTarget = Main.npc[index];
                        }
                    }
                }
            }
            return closestTarget;
        }

        public static bool WithinBounds(this int index, int cap) => index >= 0 && index < cap;

    }
}