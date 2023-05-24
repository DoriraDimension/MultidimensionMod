using MultidimensionMod.Buffs.Debuffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent;

namespace MultidimensionMod.Projectiles.Ranged
{
	public class ShradesDemise : ModProjectile
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Projectile.width = 60;
			Projectile.height = 60;
			Projectile.alpha = 255;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 100;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.extraUpdates = 2;
		}

		public override void AI()
		{
			Projectile.rotation += 0.2f;
			Projectile.scale += 0.028f;
			if (Projectile.timeLeft > 15)
			{
				Projectile.alpha -= 30;
			}
			else
				Projectile.alpha += 60;
			if (Main.rand.NextBool(15))
			{
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.CrimsonTorch, Projectile.velocity.X * 0.10f, Projectile.velocity.Y * 0.10f, 6);

				if (Main.rand.NextBool(3))
				{
					dust.noGravity = true;
					dust.scale *= 3f;
					dust.velocity.X *= 3f;
					dust.velocity.Y *= 3f;
				}
				dust.scale *= 1.5f;
				dust.velocity *= 1.2f;
			}
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(ModContent.BuffType<BlazingSuffering>(), 180);
		}

		public override void OnHitPlayer(Player target, Player.HurtInfo info)
		{
			target.AddBuff(ModContent.BuffType<BlazingSuffering>(), 180);
		}

		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Vector2 position = Projectile.Center - Main.screenPosition;
			Rectangle rect = new(0, 0, texture.Width, texture.Height);
			Vector2 origin = new(texture.Width / 2f, texture.Height / 2f);

			Main.EntitySpriteDraw(texture, position, new Rectangle?(rect), Projectile.GetAlpha(lightColor), Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0);

			return false;
		}
	}
}