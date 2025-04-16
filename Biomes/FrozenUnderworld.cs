using MultidimensionMod.Tiles.Biomes.FrozenUnderworld;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics.Light;
using Terraria.ID;

namespace MultidimensionMod.Biomes
{
    public class FrozenUnderworld : ModBiome
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;

        public override int Music => (Main.hardMode ? MultidimensionMod.Instance.GetMusicFromMusicMod("FrozenUnderworld2") : MultidimensionMod.Instance.GetMusicFromMusicMod("FrozenUnderworld")) ?? MusicID.Snow;
        public override string MapBackground => BackgroundPath;

        public override string BackgroundPath => "MultidimensionMod/Backgrounds/Map/FUMap";

        public override string BestiaryIcon => "MultidimensionMod/Biomes/FUIcon";

        public override void Load()
        {
            On_TileLightScanner.ApplyHellLight += FUCustomLighting;
        }

        //IL adjusted with Spooky Mod IL code, shoutout to them
        //Adjusts underworld lighting to be darker and white instead of orange
        private void FUCustomLighting(On_TileLightScanner.orig_ApplyHellLight orig, TileLightScanner self, Tile tile, int x, int y, ref Vector3 lightColor)
        {
            if (Main.LocalPlayer.InModBiome(ModContent.GetInstance<FrozenUnderworld>()))
            {
                float Red = 0f;
                float Green = 0f;
                float Blue = 0f;

                float Intensity = 0.20f;

                if ((!tile.HasTile || !Main.tileNoSunLight[tile.TileType] || ((tile.Slope != 0 || tile.IsHalfBlock) && Main.tile[x, y - 1].LiquidAmount == 0 && Main.tile[x, y + 1].LiquidAmount == 0 && Main.tile[x - 1, y].LiquidAmount == 0 && Main.tile[x + 1, y].LiquidAmount == 0)) && lightColor.X < Intensity && (Main.wallLight[tile.WallType] || tile.IsWallInvisible) && tile.LiquidAmount < 200 && (!tile.IsHalfBlock || Main.tile[x, y - 1].LiquidAmount < 200))
                {
                    Red = Intensity;
                    Green = Intensity;
                    Blue = Intensity;
                }
                if ((!tile.HasTile || tile.IsHalfBlock || !Main.tileNoSunLight[tile.TileType]) && tile.LiquidAmount < byte.MaxValue)
                {
                    Red = Intensity;
                    Green = Intensity;
                    Blue = Intensity;

                    //Don't provide lighting behind walls or liquids
                    if (tile.WallType > 0 || tile.LiquidAmount > 0)
                    {
                        Red *= 0f;
                        Green *= 0f;
                        Blue *= 0f;
                    }
                }

                //Set each light color value (Doesn't matter since it's white)
                if (lightColor.X < Red)
                {
                    lightColor.X = Red;
                }
                if (lightColor.Y < Green)
                {
                    lightColor.Y = Green;
                }
                if (lightColor.Z < Blue)
                {
                    lightColor.Z = Blue;
                }

                return;
            }

            orig(self, tile, x, y, ref lightColor);
        }

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
