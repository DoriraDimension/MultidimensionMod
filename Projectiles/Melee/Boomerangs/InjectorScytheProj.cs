using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Boomerangs
{
	public class InjectorScytheProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Injector");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.LightDisc);
			AIType = ProjectileID.LightDisc;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.Ichor, 180);
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.LightDisc;
			return true;
		}
	}
}