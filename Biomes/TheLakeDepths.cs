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

namespace MultidimensionMod.Biomes
{
    public class TheLakeDepths : ModBiome
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/LakeDepths");
        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.GetInstance<ShroudedMireBackground>();
        public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.GetInstance<LakeDepthsBackground>();

        public override ModWaterStyle WaterStyle => ModContent.GetInstance<LakeWaterStyle>();

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

        //Activates like a normal underground biome depending on height. It also activates when the player steps in front of certain wall types
        public override bool IsBiomeActive(Player player)
        {
            bool b1 = (player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight) && ModContent.GetInstance<LakeDepthsTileCount>().LDCount >= 50 
                || (Framing.GetTileSafely(player.Center.ToTileCoordinates()).WallType == ModContent.WallType<DankDepthstoneWallPlaced>() || Framing.GetTileSafely(player.Center.ToTileCoordinates()).WallType == WallID.Waterfall) 
                && Framing.GetTileSafely(player.Center.ToTileCoordinates()).WallType != ModContent.WallType<DankDepthstoneWall2Placed>() && ModContent.GetInstance<LakeDepthsTileCount>().LDCount >= 50;
            return b1;
        }
    }

    public class LakeDepthsTileCount : ModSystem
    {
        public int LDCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            LDCount = tileCounts[ModContent.TileType<MireGrass>()]
                + tileCounts[ModContent.TileType<PermafrostPlaced>()]
                + tileCounts[ModContent.TileType<DepthIce>()]
                + tileCounts[ModContent.TileType<DepthMoss>()]
                + tileCounts[ModContent.TileType<DepthsandHardenedPlaced>()]
                + tileCounts[ModContent.TileType<DepthsandPlaced>()]
                + tileCounts[ModContent.TileType<DepthsandstonePlaced>()]
                + tileCounts[ModContent.TileType<DepthMoss>()]
                + tileCounts[ModContent.TileType<DankDepthstonePlaced>()]
                + tileCounts[ModContent.TileType<DepthstonePlaced>()];
        }
    }
}