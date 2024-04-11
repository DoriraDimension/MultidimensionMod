using MultidimensionMod.Base;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;


namespace MultidimensionMod.Projectiles.Melee.Boomerangs
{
    public class MusharangProj : ModProjectile
	{

        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.aiStyle = 3;
            Projectile.timeLeft = 3600;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Melee;
        }

		public override void AI()
		{
            Player player = Main.player[Projectile.owner];
			BaseAI.AIBoomerang(Projectile, ref Projectile.ai, player.position, player.width, player.height, true, 15f, 35, .6f, 0.2f);
		}

		public override bool OnTileCollide(Vector2 value2)
		{
			if (Main.netMode != 2)
			{
				Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
				SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			}
			Projectile.netUpdate = true;
			BaseAI.TileCollideBoomerang(Projectile, ref value2, true);
			return false;
		}
	}
}