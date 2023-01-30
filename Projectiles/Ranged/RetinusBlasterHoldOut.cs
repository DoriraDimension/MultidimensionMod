using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace MultidimensionMod.Projectiles.Ranged
{
	public class RetinusBlasterHoldOut : ModProjectile
	{
		public int counter;

		public int charge;

		public override void SetDefaults()
		{
			Projectile.width = 80;
			Projectile.height = 38;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.hide = true;
			Projectile.ownerHitCheck = true;
			Projectile.DamageType = DamageClass.Ranged;
		}
	                                                                     
		public override void AI()
		{

			Player player = Main.player[Projectile.owner];
			float num = (float)Math.PI / 2f;
			Vector2 fecktor = player.RotatedRelativePoint(player.MountedCenter);
			Projectile.ai[0] += 1f;
			int num2 = 0;
			if (Projectile.ai[0] >= 30f)
			{
				num2++;
			}
			if (Projectile.ai[0] >= 60f)
			{
				num2++;
			}
			if (Projectile.ai[0] >= 90f)
			{
				num2++;
			}
			int num3 = 24;
			int num4 = 6;
			Projectile.ai[1] += 1f;
			bool kek = false;
			if (Projectile.ai[1] >= (float)(num3 - num4 * num2))
			{
				Projectile.ai[1] = 0f;
				kek = true;
			}
			if (Projectile.ai[1] == 1f && Projectile.ai[0] != 1f)
			{
				Vector2 spinningpoint = Vector2.UnitX * 24f;
				spinningpoint = spinningpoint.RotatedBy(Projectile.rotation + (float)Math.PI / 2f);
				Vector2 value = Projectile.Center + spinningpoint;
				for (int i = 0; i < charge; i++)
				{
					int type = ((this.charge >= 2) ? DustID.RedTorch : DustID.Torch);
					int num5 = Dust.NewDust(value - Vector2.One * 8f, 16, 16, type, Projectile.velocity.X / 2f, Projectile.velocity.Y / 2f, 100);
					Main.dust[num5].position.Y -= 0.3f;
					Main.dust[num5].velocity *= 0.66f;
					Main.dust[num5].noGravity = true;
					Main.dust[num5].scale = 2.0f;
				}
			}
			if (kek && Main.myPlayer == Projectile.owner && player.channel && !player.noItems && !player.CCed)
			{
				float num6 = player.inventory[player.selectedItem].shootSpeed * Projectile.scale;
				Vector2 value2 = fecktor;
				Vector2 value3 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - value2;
				if (player.gravDir == -1f)
				{
					value3.Y = (float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - value2.Y;
				}
				Vector2 velocity = Vector2.Normalize(value3);
				if (float.IsNaN(velocity.X) || float.IsNaN(velocity.Y))
				{
					velocity = -Vector2.UnitY;
				}
				velocity *= num6;
				if (velocity.X != Projectile.velocity.X || velocity.Y != Projectile.velocity.Y)
				{
					Projectile.netUpdate = true;
				}
				Projectile.velocity = velocity;
			}
			if (player.direction == 1)
			{
				Projectile.Center = player.Center + new Vector2(100f, 0f);
			}
			if (player.direction == -1)
			{
				Projectile.Center = player.Center + new Vector2(100f, 0f);
			}
			Projectile.Center = fecktor;
			Projectile.rotation = Projectile.velocity.ToRotation() + num;
			Projectile.spriteDirection = Projectile.direction;
			Projectile.timeLeft = 2;
			player.ChangeDir(Projectile.direction);
			player.heldProj = Projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = (Projectile.velocity * (float)Projectile.direction).ToRotation();

			counter++;
			if (counter >= 120)
			{
				charge = 2;
			}
			else if (counter <= 120)
			{
				charge = 1;
			}
			if (!player.channel)
			{
				Projectile.Kill();
			}
		}

		public override void Kill(int timeLeft)
		{
			Player player = Main.player[Projectile.owner];
			float num = Projectile.damage;
			if (Projectile.owner == Main.myPlayer && charge == 2)
			{
				float num2 = 12f;
				Vector2 focktor = new Vector2(player.position.X + (float)player.width * 0.5f, player.position.Y + (float)player.height * 0.5f);
				float num3 = (float)Main.mouseX + Main.screenPosition.X - focktor.X;
				float num4 = (float)Main.mouseY + Main.screenPosition.Y - focktor.Y;
				if ((double)player.gravDir == -1.0)
				{
					num4 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - focktor.Y;
				}
				float num5 = (float)Math.Sqrt((double)num3 * (double)num3 + (double)num4 * (double)num4);
				float num6;
				if ((float.IsNaN(num3) && float.IsNaN(num4)) || ((double)num3 == 0.0 && (double)num4 == 0.0))
				{
					num3 = player.direction;
					num4 = 0f;
					num6 = num2;
				}
				else
				{
					num6 = num2 / num5;
				}
				float speedX = num3 * num6;
				float speedY = num4 * num6;
				SoundEngine.PlaySound(SoundID.Item96, Projectile.position);
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), focktor.X, focktor.Y, speedX, speedY, ModContent.ProjectileType<RetinusBeam>(), (int)num, 1f, player.whoAmI);
			}
		}

		public override bool PreDraw(ref Color lightColor)
		{
			// SpriteEffects helps to flip texture horizontally and vertically
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (Projectile.spriteDirection == -1)
				spriteEffects = SpriteEffects.FlipHorizontally;

			// Getting texture of projectile
			Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);

			// Calculating frameHeight and current Y pos dependence of frame
			// If the texture is without animation frameHeight is always texture.Height and startY is always 0
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int startY = frameHeight * Projectile.frame;

			// Get this frame on texture
			Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);

			Vector2 origin = sourceRectangle.Size() / 2f;
			float offsetY = 20f;
			float offsetY2 = 20f;
			origin.Y = (float)(Projectile.spriteDirection == 1 ? sourceRectangle.Height - offsetY : offsetY);
			if (Projectile.spriteDirection == -1)
            {
				origin.Y = (float)(Projectile.spriteDirection == -1 ? sourceRectangle.Height - offsetY2 : offsetY2);
            }


			// Applying lighting and draw current frame
			Color drawColor = Projectile.GetAlpha(lightColor);
			Main.EntitySpriteDraw(texture,
				Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
				sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);

			// It's important to return false, otherwise we also draw the original texture.
			return false;
		}

		public override bool? CanDamage()
		{
			return false;
		}
	}
}