using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Ranged
{
	internal class SunrayBrickThrown : ModProjectile
	{

		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Projectile.width = 30;
			Projectile.height = 30;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.hide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
		}

		public override void AI()
		{
			Projectile.rotation += 0.2f * (float)Projectile.direction;
		}

		public override void OnKill(int timeLeft)
		{

			if (Main.hardMode && Main.rand.NextFloat() < .0500f)
			{
				SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/TheExplosion"), Projectile.position);
			}
			else
				SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/FireExplosion"), Projectile.position);
			Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y + 0f, 0f, 0f, ModContent.ProjectileType<CompletelyOutOfPlaceExplosionGif>(), (int)((double)((float)Projectile.damage) * 0.5), 0f, Main.myPlayer);
		}
	}
}
