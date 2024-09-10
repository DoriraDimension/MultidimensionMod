using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

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
    }
}