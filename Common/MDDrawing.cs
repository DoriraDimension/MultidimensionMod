using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Projectiles;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Common
{
    public static class MDDrawing
    {
        //Code was adapted from Mod of Redemption
        public static void DrawAura(Vector2 center, Color color, float scale = 1, Entity target = null)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                int aura = Projectile.NewProjectile(null, center, Vector2.Zero, ModContent.ProjectileType<Aura>(), 0, 0,
                    Main.myPlayer, scale);
                (Main.projectile[aura].ModProjectile as Aura).color = color;
                (Main.projectile[aura].ModProjectile as Aura).entityTarget = target;
            }
        }
    }
}