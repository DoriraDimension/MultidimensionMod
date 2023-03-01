using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Swords
{
    public class ImpactZone : ModProjectile
    {
		public override string Texture => "MultidimensionMod/Projectiles/NoTexture";
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Void Matter Impact");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 4;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.height = 120;
			Projectile.width = 70;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.timeLeft = 90;
		}
		public override void AI()
        {
			Player player = Main.player[Projectile.owner];
			Projectile.Center = player.Center + Projectile.velocity * 10f;

        }
    }
}