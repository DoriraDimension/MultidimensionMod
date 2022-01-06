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
			Main.projFrames[projectile.type] = 14;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.width = 32;
			projectile.height = 32;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}

		public override void AI() {
			Player player = Main.player[projectile.owner];
			MDPlayer modPlayer = player.GetModPlayer<MDPlayer>();
			if (player.dead) 
			{
				modPlayer.SmileyJr = false;
			}
			if (modPlayer.SmileyJr) 
			{
				projectile.timeLeft = 2;

			}

			int frameSpeed = 7;
			Player projOwner = Main.player[projectile.owner];
			projectile.frameCounter++;
			if (projOwner.statLife >= projOwner.statLifeMax2 / 4)
			{
				if (projectile.frameCounter > 5)
				{
					projectile.frame++;
					projectile.frameCounter = 0;
				}
				if (projectile.frame > 3)
				{
					projectile.frame = 0;
				}
			}
			else if (projOwner.statLife <= projOwner.statLifeMax2 / 4)
			{
				if (projectile.frameCounter > 5)
				{
					projectile.frame++;
					projectile.frameCounter = 0;
				}
				if (projectile.frame > 7)
				{
					projectile.frame = 4;
				}
			}
			else if (!Main.dayTime)
			{
				if (projectile.frameCounter > 5)
				{
					projectile.frame++;
					projectile.frameCounter = 0;
				}
				if (projectile.frame > 13)
				{
					projectile.frame = 8;
				}
			}


			if (projectile.velocity.X > -0.1)
            {
				projectile.spriteDirection = -1;

			}
			else if (projectile.velocity.X < 0.1)
			{
				projectile.spriteDirection = 1;
			}

			Vector2 idlePosition = player.Center;
			idlePosition.Y -= 38f;

			Vector2 vectorToIdlePosition = idlePosition - projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 1500f)
			{
				projectile.position = idlePosition;
				projectile.velocity *= 0.1f;
				projectile.netUpdate = true;
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
				projectile.velocity = (projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
			}
		}
	}
}