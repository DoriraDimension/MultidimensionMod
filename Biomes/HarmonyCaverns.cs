using MultidimensionMod.Tiles.Biomes.Mire;
using MultidimensionMod.Backgrounds;
using MultidimensionMod.Water;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using MultidimensionMod.Walls;
using Terraria.ID;
using MultidimensionMod.Tiles.Biomes.Harmony;

namespace MultidimensionMod.Biomes
{
    public class HarmonyCaverns : ModBiome
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override int Music => MultidimensionMod.Instance.GetMusicFromMusicMod("Harmony") ?? MusicID.Shimmer;
        //public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.GetInstance<HarmonyBackground>();
        public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.GetInstance<HarmonyUGBG>();

        public override ModWaterStyle WaterStyle => ModContent.GetInstance<TerraWaterStyle>();

        public override void SpecialVisuals(Player player, bool isActive)
        {

        }

        public override void OnLeave(Player player)
        {

        }

        public override string MapBackground => BackgroundPath;

        public override string BackgroundPath => "MultidimensionMod/Backgrounds/Map/HarmonyMap";

        public override string BestiaryIcon => "MultidimensionMod/Biomes/HarmonyIcon";
        public override Color? BackgroundColor => base.BackgroundColor;

        //Activates like a normal underground biome depending on height. It also activates when the player steps in front of certain wall types
        public override bool IsBiomeActive(Player player)
        {
            bool b1 = ModContent.GetInstance<HarmonyTileCount>().HCount >= 50;
            return b1;
        }
    }

    public class HarmonyTileCount : ModSystem
    {
        public int HCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            HCount = tileCounts[ModContent.TileType<TerraCrystalPlaced>()]
                + tileCounts[ModContent.TileType<PurestonePlaced>()];
        }
    }
}