using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Boomerangs
{
	public class InjectorScytheProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Injector");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.LightDisc);
			aiType = ProjectileID.LightDisc;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Ichor, 180);
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.LightDisc;
			return true;
		}
	}
}