using Microsoft.Xna.Framework;
using Mono.Cecil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace MultidimensionMod.Projectiles.Magic
{
	internal class SaltwaterBolt : ModProjectile
	{

		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.light = 0.8f;
			Projectile.hide = false;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 300;
			AIType = ProjectileID.Bullet;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 3;

        }

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Water, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.8f;
				Main.dust[dustIndex].alpha = 50;
			}
		}

		public override void AI()
		{
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			for (int i = 0; i < 3; i++)
			{
				Player player = Main.LocalPlayer;
				int Damage = Projectile.damage;
				float KnockBack = Projectile.knockBack;
				int type = ProjectileID.WaterStream;
				float speed = 30;
				float num70 = (float)Main.mouseX + Main.screenPosition.X - player.position.X;
				float num71 = (float)Main.mouseY + Main.screenPosition.Y - player.position.Y;
				Vector2 Position = new Vector2(num70 + num71);
                float num72 = (float)Math.Sqrt(num70 * num70 + num71 * num71);
				float ai2 = num71 + Position.Y;
				Position = new Vector2(player.position.X + (float)player.width * 0.5f + (float)(Main.rand.Next(201) * -player.direction) + ((float)Main.mouseX + Main.screenPosition.X - player.position.X), player.MountedCenter.Y - 600f);
				Position.X = (Position.X + player.Center.X) / 2f + (float)Main.rand.Next(-200, 201);
				num70 = (float)Main.mouseX + Main.screenPosition.X - Position.X;
				num71 = (float)Main.mouseY + Main.screenPosition.Y - Position.Y;
				if (num71 < 0f)
				{
					num71 *= -1f;
				}
				if (num71 < 20f)
				{
					num71 = 20f;
				}
				num72 = (float)Math.Sqrt(num70 * num70 + num71 * num71);
				num72 = speed / num72;
				num70 *= num72;
				num71 *= num72;
				float speedX4 = num70 + (float)Main.rand.Next(-40, 41) * 0.02f;
				float speedY5 = num71 + (float)Main.rand.Next(-40, 41) * 0.02f;
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Position.X, Position.Y, speedX4, speedY5, type, Damage, KnockBack, player.whoAmI, 0f, Main.rand.Next(5));
			}
        }
	}
}