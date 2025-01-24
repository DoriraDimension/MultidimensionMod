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
    }
}