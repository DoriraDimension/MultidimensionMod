using MultidimensionMod.Common.Players;
using MultidimensionMod.Buffs.Pets;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Pets
{
	public class IgnaenHead : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Ignaen's Head");
			Main.projFrames[Projectile.type] = 6;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetDefaults() {
			Projectile.width = 46;
			Projectile.height = 46;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
		}

		public override bool PreDraw(ref Color lightColor)
        {
			Texture2D glowMask = ModContent.Request<Texture2D>("MultidimensionMod/Projectiles/Pets/IgnaenHead_Glow").Value;
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			MDPlayer modPlayer = player.GetModPlayer<MDPlayer>();
			if (!player.dead && player.HasBuff(ModContent.BuffType<IgnaenHeadBuff>()))
			{
				Projectile.timeLeft = 2;
			}

			int frameSpeed = 8;
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= frameSpeed)
			{
				Projectile.frameCounter = 0;
				Projectile.frame++;
				if (Projectile.frame >= Main.projFrames[Projectile.type])
				{
					Projectile.frame = 0;
				}
			}

			if (Projectile.velocity.X > -0.1)
			{
				Projectile.spriteDirection = -1;

			}
			else if (Projectile.velocity.X < 0.1)
			{
				Projectile.spriteDirection = 1;
			}

			Vector2 idlePosition = player.Center;
			idlePosition.Y -= 48f;

			Vector2 vectorToIdlePosition = idlePosition - Projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 1500f)
			{
				Projectile.position = idlePosition;
				Projectile.velocity *= 0.1f;
				Projectile.netUpdate = true;
			}

			float speed = 8f;
			float inertia = 20f;

			if (distanceToIdlePosition > 300f)
			{
				speed = 18f;
				inertia = 60f;
			}
			else
			{
				speed = 4f;
				inertia = 80f;
			}
			if (distanceToIdlePosition > 20f)
			{
				vectorToIdlePosition.Normalize();
				vectorToIdlePosition *= speed;
				Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
			}
		}
	}
}