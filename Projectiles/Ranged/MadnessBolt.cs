using MultidimensionMod.Buffs.Debuffs;
using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Projectiles.Ranged
{
	internal class MadnessBolt : ModProjectile
	{
		public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

		public int AntiShitLookingDustInt;

		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = 3;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.IchorTorch, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
				Main.dust[dustIndex].noGravity = true;
			}
		}

		public override void AI()
		{
			AntiShitLookingDustInt++;
			if (AntiShitLookingDustInt >= 3)
			{
				for (int A = 0; A < 4; A++)
				{
					Vector2 victor = Projectile.position;
					victor -= Projectile.velocity * (A * 0.25f);
					Projectile.alpha = 255;
					int num448 = Dust.NewDust(victor, 1, 1, ModContent.DustType<MadnessY>());
					Main.dust[num448].noGravity = true;
					Main.dust[num448].position = victor;
					Main.dust[num448].scale *= (float)Main.rand.Next(40, 60) * 0.040f;
					Dust obj = Main.dust[num448];
					obj.velocity *= 0.2f;
				}
			}


            Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
			Projectile.rotation = Projectile.velocity.ToRotation();
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}
			if (Projectile.spriteDirection == -1)
			{
				Projectile.rotation += MathHelper.Pi;
			}
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(ModContent.BuffType<Madness>(), 120);
		}
	}
}