using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Ammo
{
	public class EctoflareArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("EctoflareArrow");
			DisplayName.AddTranslation(GameCulture.German, "Ektoloder Pfeil");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;   
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;      
		}

		public override void SetDefaults()
		{
			projectile.width = 18;               
			projectile.height = 18;             
			projectile.aiStyle = 1;         
			projectile.friendly = true;       
			projectile.hostile = false;        
			projectile.ranged = true;       
			projectile.penetrate = 2;          
			projectile.timeLeft = 600;               
			projectile.light = 0.2f;            
			projectile.ignoreWater = true;        
			projectile.tileCollide = true;          
			projectile.extraUpdates = 1;      
			aiType = ProjectileID.Bullet;           
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Ichor, 300);
			target.AddBuff(BuffID.CursedInferno, 300);
		}

		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
		}
	}
}
