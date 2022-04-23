using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Ammo
{
	public class EctoflareArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("EctoflareArrow");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;   
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;      
		}

		public override void SetDefaults()
		{
			Projectile.width = 18;               
			Projectile.height = 18;             
			Projectile.aiStyle = 1;         
			Projectile.friendly = true;       
			Projectile.hostile = false;        
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = 2;          
			Projectile.timeLeft = 600;               
			Projectile.light = 0.2f;            
			Projectile.ignoreWater = true;        
			Projectile.tileCollide = true;          
			Projectile.extraUpdates = 1;      
			AIType = ProjectileID.Bullet;           
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Ichor, 300);
			target.AddBuff(BuffID.CursedInferno, 300);
		}

		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}
	}
}
