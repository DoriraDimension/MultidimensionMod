using MultidimensionMod.Tiles.Biomes.Inferno;
using MultidimensionMod.Backgrounds;
using MultidimensionMod.Water;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using MultidimensionMod.Walls;
using Terraria.ID;

namespace MultidimensionMod.Biomes
{
    public class TheDragonBurrow : ModBiome
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/DragonBurrow");

        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.GetInstance<DragonHoardBackground>();
        public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.GetInstance<DragonBurrowBackground>();

        public override ModWaterStyle WaterStyle => ModContent.GetInstance<DragonWaterStyle>();

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

        public override string BackgroundPath => "MultidimensionMod/Backgrounds/Map/VolcanoMap";

        public override string BestiaryIcon => "MultidimensionMod/Biomes/VolcanoIcon";
        public override Color? BackgroundColor => base.BackgroundColor;

        //Activates like a normal underground biome depending on height. It also activates when the player steps in front of certain wall types
        public override bool IsBiomeActive(Player player)
        {
            bool b1 = (player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight) && ModContent.GetInstance<DragonBurrowTileCount>().DBCount >= 50 
                || (Framing.GetTileSafely(player.Center.ToTileCoordinates()).WallType == ModContent.WallType<VolcanicRockWallPlaced>() || Framing.GetTileSafely(player.Center.ToTileCoordinates()).WallType == WallID.Lavafall)
                && Framing.GetTileSafely(player.Center.ToTileCoordinates()).WallType != ModContent.WallType<VolcanicRockWall2Placed>() && ModContent.GetInstance<DragonBurrowTileCount>().DBCount >= 50;
            return b1;
        }
    }

    public class DragonBurrowTileCount : ModSystem
    {
        public int DBCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            DBCount = tileCounts[ModContent.TileType<InfernoGrass>()]
                + tileCounts[ModContent.TileType<TorchAshPlaced>()]
                + tileCounts[ModContent.TileType<TorchMoss>()]
                + tileCounts[ModContent.TileType<TorchsandHardenedPlaced>()]
                + tileCounts[ModContent.TileType<TorchsandPlaced>()]
                + tileCounts[ModContent.TileType<TorchsandstonePlaced>()]
                + tileCounts[ModContent.TileType<TorchstonePlaced>()]
                + tileCounts[ModContent.TileType<VolcanicRockPlaced>()];
        }
    }
}