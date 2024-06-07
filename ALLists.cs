using MultidimensionMod.NPCs.Bosses.FeudalFungus;
using MultidimensionMod.NPCs.MushBiomes;
using System.Collections.Generic;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace MultidimensionMod
{
    public class ALLists
    {
        public static List<int> ReflectionExceptions;

        public static void LoadLists()
        {
            ReflectionExceptions = new List<int>()
            {
                // Some hostile boss projectiles
                ProjectileID.SaucerDeathray,
                ProjectileID.PhantasmalDeathray,

                ProjectileType<IlluminaRing>(),
                ProjectileType<RadiantIlluminaRing>(),
                ProjectileType<PufferFart>(),
            };
        }
    }
}
