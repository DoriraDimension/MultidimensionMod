using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.MushBiomes
{
    public class FungusBubble : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Fungus Bubble");
		}
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.aiStyle = 0;
            Projectile.hostile = true;
            Projectile.alpha = 255;
            Projectile.timeLeft = 300;
            Projectile.noEnchantments = true;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void AI()
        {
            Projectile.alpha -= 5;
            Projectile.velocity *= 0.98f;
        }

        public override void OnKill(int timeLeft)
        {
            for (int dust = 0; dust <= 5; dust++)
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.GlowingMushroom, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
            }
        }
    }
}