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

        public override int Music => Main.hardMode ? MusicLoader.GetMusicSlot(Mod, "Sounds/Music/FrozenUnderworld2") : MusicLoader.GetMusicSlot(Mod, "Sounds/Music/FrozenUnderworld");
        public override string MapBackground => BackgroundPath;

        public override string BackgroundPath => "MultidimensionMod/Backgrounds/Map/FUMap";

        public override string BestiaryIcon => "MultidimensionMod/Biomes/FUIcon";

        public override void SpecialVisuals(Player player, bool isActive)
        {
            if (isActive)
            {
                if (Main.UseStormEffects)
                {
                    player.ManageSpecialBiomeVisuals("Blizzard", true);
                }
            }
        }

        public override bool IsBiomeActive(Player player)
        {
            bool b1 = ModContent.GetInstance<FrozenUnderworldTileCount>().FUCount >= 150;

            bool b2 = player.ZoneUnderworldHeight;
            return b1 && b2;
        }
    }

    public class FrozenUnderworldTileCount : ModSystem
    {
        public int FUCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            FUCount = tileCounts[ModContent.TileType<ColdAsh>()]
            + tileCounts[ModContent.TileType<AbyssalHellstonePlaced>()]
            + tileCounts[ModContent.TileType<GlazedObsidianPlaced>()]
            + tileCounts[ModContent.TileType<ColdAshGrass>()];
        }
    }
}
