using MultidimensionMod.Common.Globals.Items;
using MultidimensionMod.Common.Players;
using MultidimensionMod.Common.Globals.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace MultidimensionMod.Base
{
    public static class BaseExtension
    {
        /// <summary>References the ALPlayer instance.</summary>
        public static MDPlayer AL(this Player player) => player.GetModPlayer<MDPlayer>();
        /// <summary>References the ALNPC instance.</summary>
        public static MDGlobalNPC AL(this NPC npc) => npc.GetGlobalNPC<MDGlobalNPC>();
        /// <summary>References the RedeItem instance.</summary>
        public static MDGlobalItem AL(this Item item) => item.GetGlobalItem<MDGlobalItem>();
        /// <summary>References the RedeProjectile instance.</summary>
        public static MDGlobalProjectile AL(this Projectile proj) => proj.GetGlobalProjectile<MDGlobalProjectile>();
    }
}