using MultidimensionMod.Buffs.Debuffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Others
{
	public class DataMinerProj : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 26;
			Projectile.height = 30;
			Projectile.aiStyle = 20;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.hide = true;
			Projectile.ownerHitCheck = true;
			Projectile.DamageType = DamageClass.Melee;
		}

		public override void AI()
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Electric, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 0.3f);
			Main.dust[dust].noGravity = true;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			{
				target.AddBuff(ModContent.BuffType<DimensionalShock>(), 60000);
			}
		}
	}
}