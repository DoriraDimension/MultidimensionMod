using MultidimensionMod.Tiles.Biomes.FrozenUnderworld;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Biomes
{
    public class FrozenUnderworld : ModBiome
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        //public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.GetInstance<DepthsUnderworldBackground?>();

        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/FrozenUnderworld");
        public override string MapBackground => BackgroundPath;

        public override string BackgroundPath => "TheDepths/Biomes/DepthsMapBackground";

        public override string BestiaryIcon => "TheDepths/Biomes/DepthsBestiaryIcon";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Underworld");
        }

        public override bool IsBiomeActive(Player player)
        {
            bool b1 = ModContent.GetInstance<FrozenUnderworldTileCount>().FUCount >= 60;

            bool b2 = player.ZoneUnderworldHeight;
            return b1 && b2;
        }
    }

    public class FrozenUnderworldTileCount : ModSystem
    {
        public int FUCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            FUCount = tileCounts[ModContent.TileType<ColdAsh>()];
            FUCount = tileCounts[ModContent.TileType<AbyssalHellstonePlaced>()];
            FUCount = tileCounts[ModContent.TileType<GlazedObsidianPlaced>()];
        }
    }
}
