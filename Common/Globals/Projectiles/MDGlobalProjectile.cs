using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Common.Players;

namespace MultidimensionMod.Common.Globals.Projectiles
{
    public class MDGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;

        public int FungusVomit;

        public override void AI(Projectile projectile)
        {

        }
    }
}