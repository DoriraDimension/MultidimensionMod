using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Biomes
{
    public class MushStoryBiome : ModBiome
    {
        public override string BestiaryIcon => "MultidimensionMod/Biomes/PrayIcon";
        public override bool IsBiomeActive(Player player) => false;
    }
    public class SinStoryBiome : ModBiome
    {
        public override string BestiaryIcon => "MultidimensionMod/Biomes/SinnerIcon";
        public override bool IsBiomeActive(Player player) => false;
    }
    public class ChaosValorStoryBiome : ModBiome
    {
        public override string BestiaryIcon => "MultidimensionMod/Biomes/ChaosValorIcon";
        public override bool IsBiomeActive(Player player) => false;
    }
    public class OrderStoryBiome : ModBiome
    {
        public override string BestiaryIcon => "MultidimensionMod/Biomes/OrderIcon";
        public override bool IsBiomeActive(Player player) => false;
    }
    public class OblivionStoryBiome : ModBiome
    {
        public override string BestiaryIcon => "MultidimensionMod/Biomes/OblivionIcon";
        public override bool IsBiomeActive(Player player) => false;
    }
    public class CthulhuStoryBiome : ModBiome
    {
        public override string BestiaryIcon => "MultidimensionMod/Biomes/CthulhuIcon";
        public override bool IsBiomeActive(Player player) => false;
    }

    public class GreaterOneFilterBiome : ModBiome
    {
        public override string BestiaryIcon => "MultidimensionMod/Biomes/GreaterOneIcon";
        public override bool IsBiomeActive(Player player) => false;
    }
    public class SubspeciesFilterBiome : ModBiome
    {
        public override string BestiaryIcon => "MultidimensionMod/Biomes/SubspeciesIcon";
        public override bool IsBiomeActive(Player player) => false;
    }
}