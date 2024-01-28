using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace MultidimensionMod.Projectiles.Ranged
{
    public class Vulcan : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Flare of Evil");
		}

		public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.light = 0.8f;
            Projectile.DamageType = DamageClass.Ranged;
        }

        public override bool OnTileCollide(Vector2 velocity)
        {
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
            Projectile.Kill();
            return false;
        }

        public override void AI()
        {
            Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.spriteDirection = Projectile.direction;
            Projectile.ai[1] += 1f;

			if (Projectile.ai[1] >= 16f)
			{
				Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
			}

            if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
				return;
			}
            if (Projectile.ai[1] >= 1)
            {
                int lava = Dust.NewDust(new Vector2(Projectile.position.X + Projectile.velocity.X, Projectile.position.Y + Projectile.velocity.Y), Projectile.width, Projectile.height, DustID.Torch, Projectile.velocity.X, Projectile.velocity.Y, 100, default, 3f * Projectile.scale);
                Main.dust[lava].noGravity = true;
                Main.dust[lava].scale *= 0.05f;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.OnFire, 420, false);
        }

        public override void OnKill(int timeleft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, Projectile.velocity.X, Projectile.velocity.Y, ModContent.ProjectileType<VulcanExplosion>(), Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
            int DustType = DustID.Torch;
            for (int num583 = 0; num583 < 20; num583++)
            {
                int num584 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustType, -Projectile.velocity.X * 0.2f, -Projectile.velocity.Y * 0.2f, 100, default, 2f * Projectile.scale);
                Main.dust[num584].noGravity = true;
                Main.dust[num584].velocity *= 2f;
                num584 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustType, -Projectile.velocity.X * 0.2f, -Projectile.velocity.Y * 0.2f, 100, default, 1f * Projectile.scale);
                Main.dust[num584].velocity *= 2f;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 drawOrigin = new(texture.Width / 2, texture.Height / 2);
            var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(Color.White), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            return false;
        }
    }
}
