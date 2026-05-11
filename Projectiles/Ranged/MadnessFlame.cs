using MultidimensionMod.Buffs.Debuffs;
using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;

namespace MultidimensionMod.Projectiles.Ranged
{
	public class MadnessFlame : ModProjectile
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Projectile.width = 25;
			Projectile.height = 25;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 60;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.extraUpdates = 2;
			Projectile.alpha = 255;
			Projectile.scale = 0.5f;
		}

		public override void AI()
		{
			Projectile.tileCollide = true;
			Projectile.rotation += 2 + Main.rand.Next(4);
			Projectile.scale += 0.028f;
			if (Projectile.timeLeft > 15)
			{
				Projectile.alpha -= 30;
			}
			if (Projectile.alpha <= 25)
            {
				Projectile.alpha = 25;
            }
			if (Main.rand.NextBool(15))
			{
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<MadnessY>(), Projectile.velocity.X * 0.6f, Projectile.velocity.Y * 0.6f, 75);

				if (Main.rand.NextBool(3))
				{
					dust.noGravity = true;
					dust.scale *= 3f;
					dust.velocity.X *= 2f;
					dust.velocity.Y *= 2f;
				}
				dust.scale *= 1.5f;
				dust.velocity *= 1.2f;
			}
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(ModContent.BuffType<Madness>(), 180);
		}

		public override void OnHitPlayer(Player target, Player.HurtInfo info)
		{
			target.AddBuff(ModContent.BuffType<Madness>(), 180, false);
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }

        public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
			Vector2 position = Projectile.Center - Main.screenPosition;
			Rectangle rect = new(0, 0, texture.Width, texture.Height);
			Vector2 origin = new(texture.Width / 2f, texture.Height / 2f);

			Main.EntitySpriteDraw(texture, position, new Rectangle?(rect), Projectile.GetAlpha(Color.Yellow), Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0);

			return false;
		}
	}
}
