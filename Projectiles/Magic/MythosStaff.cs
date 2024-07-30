using MultidimensionMod.Dusts;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Magic
{
	internal class MythosStaff : ModProjectile
	{
		public int ringTimer = 0;
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Projectile.width = 94;
			Projectile.height = 94;
			Projectile.friendly = true;
			Projectile.aiStyle = -1;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.hide = false;
			Projectile.localNPCHitCooldown = 20;
		}

		public override void OnKill(int timeLeft)
		{
			Player player = Main.player[Projectile.owner];
			if (ringTimer > 420)
			{
				player.statLife += 10;
                SoundEngine.PlaySound(SoundID.Item30, Projectile.position);
            }
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			player.heldProj = player.whoAmI;
			if (!player.channel)
            {
				Projectile.Kill();
            }
			Projectile.rotation += .3f * player.direction;
			Projectile.spriteDirection = player.direction;
			Projectile.Center = player.Center;

			if (player.channel)
            {
				ringTimer++;
            }
			if (ringTimer == 240)
			{
				if (Projectile.owner == Main.myPlayer)
				{
					SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/HallowedCry"), Projectile.position);
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), player.Center.X, player.Center.Y, 0f, 0f, ModContent.ProjectileType<MythosRing>(), (int)((double)((float)Projectile.damage) * 0.7), 0f, Main.myPlayer);
                    Projectile.netUpdate = true;
                }
			}
			if (ringTimer == 420)
			{
				if (Projectile.owner == Main.myPlayer)
				{
					SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/HallowedCry"), Projectile.position);
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), player.Center.X, player.Center.Y, 0f, 0f, ModContent.ProjectileType<MythosRing2>(), (int)((double)((float)Projectile.damage) * 0.5), 0f, Main.myPlayer);
                    Projectile.netUpdate = true;
                }
			}
			if (ringTimer > 421)
            {
				ringTimer = 421;
            }
		}
	}
}