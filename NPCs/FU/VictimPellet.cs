using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;

namespace MultidimensionMod.NPCs.FU
{
    public class VictimPellet : ModProjectile
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Projectile.width = 12;
            Projectile.height = 12;
            Projectile.hostile = true;
            Projectile.extraUpdates = 1;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 180;
        }

        public override void AI()
        {

        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}