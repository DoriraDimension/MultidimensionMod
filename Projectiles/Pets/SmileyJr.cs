using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Pets
{
	public class SmileyJr : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Smiley Jr");
			Main.projFrames[Projectile.type] = 14;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetDefaults() {
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
		}

		public override void AI() {
			Player player = Main.player[Projectile.owner];
			MDPlayer modPlayer = player.GetModPlayer<MDPlayer>();
			if (player.dead) 
			{
				modPlayer.SmileyJr = false;
			}
			if (modPlayer.SmileyJr) 
			{
				Projectile.timeLeft = 2;

			}

			int frameSpeed = 7;
			Player projOwner = Main.player[Projectile.owner];
			Projectile.frameCounter++;
			if (projOwner.statLife >= projOwner.statLifeMax2 / 4)
			{
				if (Projectile.frameCounter > 5)
				{
					Projectile.frame++;
					Projectile.frameCounter = 0;
				}
				if (Projectile.frame > 3)
				{
					Projectile.frame = 0;
				}
			}
			else if (projOwner.statLife <= projOwner.statLifeMax2 / 4)
			{
				if (Projectile.frameCounter > 5)
				{
					Projectile.frame++;
					Projectile.frameCounter = 0;
				}
				if (Projectile.frame > 7)
				{
					Projectile.frame = 4;
				}
			}
			else if (!Main.dayTime)
			{
				if (Projectile.frameCounter > 5)
				{
					Projectile.frame++;
					Projectile.frameCounter = 0;
				}
				if (Projectile.frame > 13)
				{
					Projectile.frame = 8;
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
			idlePosition.Y -= 38f;

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
				// Speed up the minion if it's away from the player
				speed = 18f;
				inertia = 60f;
			}
			else
			{
				// Slow down the minion if closer to the player
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