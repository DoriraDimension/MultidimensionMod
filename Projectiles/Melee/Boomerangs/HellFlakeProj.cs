using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.CodeAnalysis;
using MultidimensionMod.Base;

namespace MultidimensionMod.Projectiles.Melee.Boomerangs
{
    internal class HellFlakeProj : ModProjectile
    {
        public override string Texture => "MultidimensionMod/Items/Weapons/Melee/Boomerangs/HellFlake";
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.aiStyle = -1;
            Projectile.width = 35;
            Projectile.height = 35;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 180;
        }

        public override void Kill(int timeLeft)
        {
        }

        public override void AI()
        {
            Player p = Main.player[Projectile.owner];
            BaseAI.AIBoomerang(Projectile, ref Projectile.ai, p.position, p.width, p.height, true, 20f, 30, Projectile.ai[0] == 0 ? 0.8f : 1.2f, .3f, false);
        }
    }
}