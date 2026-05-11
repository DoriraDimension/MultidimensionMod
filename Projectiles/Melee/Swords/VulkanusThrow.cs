using MultidimensionMod.Dusts;
using MultidimensionMod.Buffs.Debuffs;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Swords
{
	internal class VulkanusThrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Projectile.width = 72;
			Projectile.height = 72;
			Projectile.friendly = true;
			Projectile.aiStyle = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.hide = false;
			Projectile.timeLeft = 300;
			Projectile.ownerHitCheck = true;
		}

		public override void OnKill(int timeLeft)
		{
			Player player = Main.player[Projectile.owner];

		}

		public override void AI()
		{
			if (Projectile.timeLeft < 280)
            {
				Projectile.tileCollide = true;
            }
			Player player = Main.player[Projectile.owner];
			player.heldProj = player.whoAmI;
			Projectile.rotation += .3f * Projectile.direction;
			Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;

			for (int i = 0; i < 3; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.CrimsonTorch, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.8f;
				Main.dust[dustIndex].alpha = 50;
			}
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(ModContent.BuffType<BlazingSuffering>(), 360);
			SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/FireExplosion"), Projectile.position);
			int numberProjectiles = 8;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(Projectile.velocity.X / 2, Projectile.velocity.Y / 2).RotatedByRandom(MathHelper.ToRadians(360));
				if (Projectile.owner == Main.myPlayer)
				{
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<VulkanusRock>(), hit.Damage, hit.Knockback, Main.myPlayer);
				}
			}
			for (int i = 0; i < 25; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.CrimsonTorch, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
        {
			SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/FireExplosion"), Projectile.position);
			for (int i = 0; i < 25; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.CrimsonTorch, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			Projectile.Kill();
			return false;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Projectiles/Melee/Swords/VulkanusThrow").Value;
            Texture2D textureGlow = ModContent.Request<Texture2D>("MultidimensionMod/Projectiles/Melee/Swords/VulkanusThrow_Glow").Value;
            Vector2 drawOrigin = new(texture.Width / 2, texture.Height / 2);
            var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(lightColor), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            Main.EntitySpriteDraw(textureGlow, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(Color.White), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            return false;
        }
    }
}