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
    public class VoidsEdge : ModBiome
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override int Music => (MultidimensionMod.Instance.GetMusicFromMusicMod("VoidsEdge")) ?? MusicID.Space;

        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.GetInstance<VoidBG>();

        public override ModWaterStyle WaterStyle => ModContent.GetInstance<VoidWaterStyle>();

        public override void SpecialVisuals(Player player, bool isActive)
        {

        }

        public override void OnLeave(Player player)
        {

        }

        public override string MapBackground => BackgroundPath;

        public override string BackgroundPath => "MultidimensionMod/Backgrounds/Map/VoidMap";

        public override string BestiaryIcon => "MultidimensionMod/Biomes/VoidIcon";

        public override bool IsBiomeActive(Player player)
        {
            bool b1 = ModContent.GetInstance<VoidTileCount>().VCount >= 50;
            return b1;
        }
    }

    public class VoidTileCount : ModSystem
    {
        public int VCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            VCount = tileCounts[ModContent.TileType<Doomgrass>()]
                + tileCounts[ModContent.TileType<WarpsandHardenedPlaced>()]
                + tileCounts[ModContent.TileType<WarpsandPlaced>()]
                + tileCounts[ModContent.TileType<WarpsandstonePlaced>()]
                + tileCounts[ModContent.TileType<DustSnowPlaced>()]
                + tileCounts[ModContent.TileType<BlackIcePlaced>()]
                + tileCounts[ModContent.TileType<DoomstonePlaced>()]
                + tileCounts[ModContent.TileType<DoomstoneBPlaced>()];
        }
    }
}