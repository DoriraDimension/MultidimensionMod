using MultidimensionMod.Tiles.Biomes.Inferno;
using MultidimensionMod.Backgrounds;
using MultidimensionMod.Water;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Terraria.ID;
using MultidimensionMod.Tiles.Biomes.Void;

namespace MultidimensionMod.Biomes
{
    public class Scrapyard : ModBiome
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override int Music => (MultidimensionMod.Instance.GetMusicFromMusicMod("Scrapyard")) ?? MusicID.SpaceDay;

        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.GetInstance<ScrapyardBackground>();

        public override ModWaterStyle WaterStyle => ModContent.GetInstance<VoidWaterStyle>();

        public override void SpecialVisuals(Player player, bool isActive)
        {

        }

        public override void OnLeave(Player player)
        {

        }

        public override string MapBackground => BackgroundPath;

        public override string BackgroundPath => "MultidimensionMod/Backgrounds/Map/ScrapyardMap";

        public override string BestiaryIcon => "MultidimensionMod/Biomes/ScrapyardIcon";

        public override bool IsBiomeActive(Player player)
        {
            bool b1 = ModContent.GetInstance<ScrapyardTileCount>().SYCount >= 50;
            return b1;
        }
    }

    public class ScrapyardTileCount : ModSystem
    {
        public int SYCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            SYCount = tileCounts[ModContent.TileType<MetallicSandPlaced>()];
        }
    }
}