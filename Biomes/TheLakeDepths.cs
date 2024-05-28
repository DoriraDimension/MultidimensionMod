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
    public class TheLakeDepths : ModBiome
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/LakeDepths");
        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.GetInstance<ShroudedMireBackground>();
        public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.GetInstance<LakeDepthsBackground>();

        //public override ModWaterStyle WaterStyle => ModContent.GetInstance<MireWaterStyle>();

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

        public override string BackgroundPath => "MultidimensionMod/Backgrounds/Map/MireUGMap";

        public override string BestiaryIcon => "MultidimensionMod/Biomes/MireUGIcon";
        public override Color? BackgroundColor => base.BackgroundColor;


        public override bool IsBiomeActive(Player player)
        {
            bool b1 = (player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight) && ModContent.GetInstance<LakeDepthsTileCount>().LDCount >= 50;
            return b1;
        }
    }

    public class LakeDepthsTileCount : ModSystem
    {
        public int LDCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            LDCount = tileCounts[ModContent.TileType<MireGrass>()]
                //+ tileCounts[ModContent.TileType<TorchAshPlaced>()]
                + tileCounts[ModContent.TileType<DepthMoss>()]
                + tileCounts[ModContent.TileType<DepthsandHardenedPlaced>()]
                + tileCounts[ModContent.TileType<DepthsandPlaced>()]
                + tileCounts[ModContent.TileType<DepthsandstonePlaced>()]
                + tileCounts[ModContent.TileType<DepthstonePlaced>()];
        }
    }
}