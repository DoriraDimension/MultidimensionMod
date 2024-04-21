using MultidimensionMod.Tiles.Biomes.Inferno;
using MultidimensionMod.Backgrounds;
using MultidimensionMod.Water;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;

namespace MultidimensionMod.Biomes
{
    public class TheDragonHoard : ModBiome
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override int Music => Main.dayTime ? MusicLoader.GetMusicSlot("Sounds/Music/DragonHoardDay") : MusicLoader.GetMusicSlot("DragonHoardNight");

        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.GetInstance<DragonHoardBackground>();

        //public override ModWaterStyle WaterStyle => ModContent.GetInstance<HoardStyle>();

        public override void SpecialVisuals(Player player, bool isActive)
        {
            if (isActive)
            {
                SkyManager.Instance.Activate("DragonHoardSky");
            }
            if (Main.UseHeatDistortion)
            {
                player.ManageSpecialBiomeVisuals("HeatDistortion", player.InModBiome(ModContent.GetInstance<TheDragonHoard>()));
            }
        }

        public override void OnLeave(Player player)
        {
            SkyManager.Instance.Deactivate("DragonHoardSky");
            player.ManageSpecialBiomeVisuals("HeatDistortion", false);
        }

        public override string MapBackground => BackgroundPath;

        public override string BackgroundPath => "MultidimensionMod/Backgrounds/Map/InfernoMap";

        public override string BestiaryIcon => "MultidimensionMod/Biomes/InfernoIcon";

        public override bool IsBiomeActive(Player player)
        {
            bool b1 = ModContent.GetInstance<DragonHoardTileCount>().DHCount >= 50;
            return b1;
        }
    }

    public class DragonHoardTileCount : ModSystem
    {
        public int DHCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            DHCount = tileCounts[ModContent.TileType<InfernoGrass>()]
                + tileCounts[ModContent.TileType<TorchAshPlaced>()]
                + tileCounts[ModContent.TileType<TorchMoss>()]
                + tileCounts[ModContent.TileType<TorchsandHardenedPlaced>()]
                + tileCounts[ModContent.TileType<TorchsandPlaced>()]
                + tileCounts[ModContent.TileType<TorchsandstonePlaced>()]
                + tileCounts[ModContent.TileType<TorchstonePlaced>()];
        }
    }
}