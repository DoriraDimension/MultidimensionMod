using Microsoft.Xna.Framework;
using MultidimensionMod.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Bosses.FeudalFungus
{
    internal class StalkingShot : ModProjectile
    {
        public override string Texture => "MultidimensionMod/Projectiles/NoTexture";
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 1;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 360;
            Projectile.AL().CantHurtDapper = true;
        }

        public int Freeze = 0;

        public override void AI()
        {
            Freeze++;
            if (Freeze >= 30 && Freeze <= 119)
            {
                Projectile.velocity = new Vector2(0, 0);
            }
            else if (Freeze == 120)
            {
                Player player = Main.LocalPlayer;
                Vector2 targetCenter = player.position;
                float ProjSpeed = 14f;
                Vector2 velocity = targetCenter - Projectile.Center;
                velocity.Normalize();
                velocity *= ProjSpeed;
                Projectile.velocity = velocity;
            }
            for (int i = 0; i < 1; i++)
            {
                int index = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.GlowingMushroom, 0f, 0f, 0);

                Main.dust[index].scale *= 1.3f;
                Main.dust[index].fadeIn = 1f;
                Main.dust[index].noGravity = true;
                Main.dust[index].color = Color.SkyBlue;
            }
        }
    }
}