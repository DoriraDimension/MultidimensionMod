using MultidimensionMod.Biomes;
using Terraria;

namespace MutidimensionMod.Common
{
    public static class ALConditions
    {
        public static Condition InScarletMyceliumForest = new Condition("Mods.MultidimensionMod.OtherConditions.InScarletForest", () => Main.LocalPlayer.InModBiome<ShroomForest>());
        //public static Condition InShroudedMire = new Condition("Mods.MultidimensionMod.OtherConditions.InShroudedMire", () => Main.LocalPlayer.InModBiome<TheShroudedMire>() || Main.LocalPlayer.InModBiome<TheLakeDepths>());
        //public static Condition InDragonsHoard = new Condition("Mods.MultidimensionMod.OtherConditions.InDragonsHoard", () => Main.LocalPlayer.InModBiome<TheDragonHoard>() || Main.LocalPlayer.InModBiome<TheDragonBurrow>());
        //public static Condition InHarmonyCaverns = new Condition("Mods.MultidimensionMod.OtherConditions.InHarmonyCaverns", () => Main.LocalPlayer.InModBiome<TheHarmonyCaverns>());
    }
}