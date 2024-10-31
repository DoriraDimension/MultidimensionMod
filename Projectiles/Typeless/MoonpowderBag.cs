using Microsoft.Xna.Framework;
using MultidimensionMod.Buffs.Debuffs;
using MultidimensionMod.Dusts;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Typeless
{
    internal class MoonpowderBag : ModProjectile
    {

        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Generic;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 20f)
            {
                Projectile.ai[0] = 20f;
                Projectile.velocity.Y = Projectile.velocity.Y + 0.5f;
            }
            if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}
            Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.spriteDirection = Projectile.direction;
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(new("MultidimensionMod/Sounds/NPC/BigFart"), Projectile.position);
            for (int i = 0; i < 25; i++)
            {
                int dustIndex2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<MoonpowderDust>(), 0f, 0f, 100, default(Color), 1f);
                Main.dust[dustIndex2].velocity *= 1.4f;
                Main.dust[dustIndex2].noGravity = true;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!target.HasBuff(ModContent.BuffType<Hazed>()) || !target.HasBuff(ModContent.BuffType<MildBurn>()))
            {
                target.AddBuff(ModContent.BuffType<Hazed>(), 2400);
            }
        }
    }
}