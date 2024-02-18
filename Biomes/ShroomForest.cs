using MultidimensionMod.Tiles.Biomes.ShroomForest;
using MultidimensionMod.Backgrounds;
using MultidimensionMod.Water;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Biomes
{
    public class ShroomForest : ModBiome
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Shroom");

        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.GetInstance<ShroomForestBackground>();

        public override ModWaterStyle WaterStyle => ModContent.GetInstance<MushroomWaterStyle>();

        public override string MapBackground => BackgroundPath;

        public override string BackgroundPath => "MultidimensionMod/Backgrounds/Map/ShroomForestMap";

        public override string BestiaryIcon => "MultidimensionMod/Biomes/ShroomForestIcon";

        public override void SpecialVisuals(Player player, bool isActive)
        {

        }

        public override bool IsBiomeActive(Player player)
        {
            bool b1 = ModContent.GetInstance<ShroomForestTileCount>().SFCount >= 50;
            return b1;
        }
    }

    public class ShroomForestTileCount : ModSystem
    {
        public int SFCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            SFCount = tileCounts[ModContent.TileType<Mycelium>()]
                + tileCounts[ModContent.TileType<MyceliumSandPlaced>()]
                + tileCounts[ModContent.TileType<MyceliumSandstonePlaced>()]
                + tileCounts[ModContent.TileType<MyceliumHardsandPlaced>()];
        }
    }
}