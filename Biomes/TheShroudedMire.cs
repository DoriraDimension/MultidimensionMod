using MultidimensionMod.Tiles.Biomes.Mire;
using MultidimensionMod.Backgrounds;
using MultidimensionMod.Water;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;

namespace MultidimensionMod.Biomes
{
    public class TheShroudedMire : ModBiome
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override int Music => Main.dayTime ? MusicLoader.GetMusicSlot(Mod, "Sounds/Music/ShroudedMireDay") : MusicLoader.GetMusicSlot(Mod, "Sounds/Music/ShroudedMireNight");

        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.GetInstance<ShroudedMireBackground>();

        public override ModWaterStyle WaterStyle => ModContent.GetInstance<MireWaterStyle>();

        public override void SpecialVisuals(Player player, bool isActive)
        {
            if (isActive)
            {
                SkyManager.Instance.Activate("ShroudedMireSky");
            }
        }

        public override void OnLeave(Player player)
        {
            SkyManager.Instance.Deactivate("ShroudedMireSky");
        }

        public override string MapBackground => BackgroundPath;

        public override string BackgroundPath => "MultidimensionMod/Backgrounds/Map/MireMap";

        public override string BestiaryIcon => "MultidimensionMod/Biomes/MireIcon";

        public override bool IsBiomeActive(Player player)
        {
            bool b1 = ModContent.GetInstance<ShroudedMireTileCount>().SMCount >= 50;
            return b1;
        }
    }

    public class ShroudedMireTileCount : ModSystem
    {
        public int SMCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            SMCount = tileCounts[ModContent.TileType<MireGrass>()]
                + tileCounts[ModContent.TileType<DepthMoss>()]
                + tileCounts[ModContent.TileType<DepthsandHardenedPlaced>()]
                + tileCounts[ModContent.TileType<DepthsandPlaced>()]
                + tileCounts[ModContent.TileType<DepthsandstonePlaced>()]
                + tileCounts[ModContent.TileType<PermafrostPlaced>()]
                + tileCounts[ModContent.TileType<DepthIce>()]
                + tileCounts[ModContent.TileType<AbyssGrass>()]
                + tileCounts[ModContent.TileType<DarkmudPlaced>()]
                + tileCounts[ModContent.TileType<DankDepthstonePlaced>()]
                + tileCounts[ModContent.TileType<DepthstonePlaced>()];
        }
    }
}