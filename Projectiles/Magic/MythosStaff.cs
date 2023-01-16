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

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brain Rocket");
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
		}

		public override void Kill(int timeLeft)
		{

		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			player.heldProj = player.whoAmI;
			if (!player.channel)
            {
				Projectile.Kill();
            }
			Projectile.rotation += .3f;



			Projectile.spriteDirection = player.direction;
			Projectile.Center = player.Center;
		}
	}
}