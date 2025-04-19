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
    }
}