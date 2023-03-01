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
	internal class MythosRing : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Mythos Light Ring");
		}

		public override void SetDefaults()
		{
			Projectile.width = 134;
			Projectile.height = 134;
			Projectile.friendly = true;
			Projectile.aiStyle = -1;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.hide = false;
			Projectile.alpha = 255;
			Projectile.localNPCHitCooldown = 20;
		}

		public override void AI()
		{
			Projectile.alpha -= 5;
			if (Projectile.alpha < 100)
			{
				Projectile.alpha = 100;
			}
			Player player = Main.player[Projectile.owner];
			player.heldProj = player.whoAmI;
			if (!player.channel)
			{
				Projectile.Kill();
			}
			Projectile.rotation += .3f * player.direction;
			Projectile.spriteDirection = player.direction;
			Projectile.Center = player.Center;
		}
	}
}