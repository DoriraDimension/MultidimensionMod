using MultidimensionMod.NPCs.Bosses.FeudalFungus;
using MultidimensionMod.NPCs.MushBiomes;
using System.Collections.Generic;
using Terraria.ModLoader;
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
                ProjectileID.SaucerDeathray,
                ProjectileID.PhantasmalDeathray,

                ModContent.ProjectileType<IlluminaRing>(),
                ModContent.ProjectileType<RadiantIlluminaRing>(),
                ModContent.ProjectileType<PufferFart>(),
            };
        }

        public static void UnloadLists()
        {
            ReflectionExceptions = null;
        }
    }
}
