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
			Main.projFrames[projectile.type] = 4;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			aiType = ProjectileID.ZephyrFish;
		}

		public override bool PreAI() {
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false; 
			return true;
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

		}
	}
}