using MultidimensionMod.Tiles.Biomes.Mire;
using MultidimensionMod.Backgrounds;
using MultidimensionMod.Water;
using MultidimensionMod.Base;
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
                SkyManager.Instance.Activate("ShroudedMireDaySky");
            }
        }

        public override void OnLeave(Player player)
        {
            SkyManager.Instance.Deactivate("ShroudedMireSky");
            SkyManager.Instance.Deactivate("ShroudedMireDaySky");

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
    public class ShroudedMireLighting : ModSystem
    {
        public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor)
        {
            if (ModContent.GetInstance<ShroudedMireTileCount>().SMCount >= 50&&Main.dayTime)
            {
                float strength = ModContent.GetInstance<ShroudedMireTileCount>().SMCount / 50f;
                strength = Math.Min(strength, 1f);

                strength *= 1f - Main.lightning;

                int sunR = backgroundColor.R;
                int sunG = backgroundColor.G;
                int sunB = backgroundColor.B;

                sunR -= (int)(242f * strength * (backgroundColor.R / 255f));
                sunG -= (int)(238f * strength * (backgroundColor.G / 255f));
                sunB -= (int)(214f * strength * (backgroundColor.B / 255f));

                sunR = (int)MathHelper.Clamp(sunR, 1, 255);
                sunG = (int)MathHelper.Clamp(sunG, 1, 255);
                sunB = (int)MathHelper.Clamp(sunB, 1, 255);

                Main.ColorOfTheSkies.R = (byte)sunR;
                Main.ColorOfTheSkies.G = (byte)sunG;
                Main.ColorOfTheSkies.B = (byte)sunB;

                tileColor.R = (byte)((Main.ColorOfTheSkies.R + Main.ColorOfTheSkies.G + Main.ColorOfTheSkies.B + Main.ColorOfTheSkies.R * 8) / 10);
                tileColor.G = (byte)((Main.ColorOfTheSkies.R + Main.ColorOfTheSkies.G + Main.ColorOfTheSkies.B + Main.ColorOfTheSkies.G * 8) / 10);
                tileColor.B = (byte)((Main.ColorOfTheSkies.R + Main.ColorOfTheSkies.G + Main.ColorOfTheSkies.B + Main.ColorOfTheSkies.B * 8) / 10);
            }
            if (ModContent.GetInstance<ShroudedMireTileCount>().SMCount >= 50&&!Main.dayTime)
            {
                float strength = ModContent.GetInstance<ShroudedMireTileCount>().SMCount / 50f;
                strength = Math.Min(strength, 0.3f);

                strength *= 0.3f - Main.lightning;

                int sunR = backgroundColor.R;
                int sunG = backgroundColor.G;
                int sunB = backgroundColor.B;

                sunR -= (int)(32f * strength * (backgroundColor.R / 255f));
                sunG -= (int)(215f * strength * (backgroundColor.G / 255f));
                sunB -= (int)(156f * strength * (backgroundColor.B / 255f));

                sunR = (int)MathHelper.Clamp(sunR, 1, 255);
                sunG = (int)MathHelper.Clamp(sunG, 1, 255);
                sunB = (int)MathHelper.Clamp(sunB, 1, 255);

                Main.ColorOfTheSkies.R = (byte)sunR;
                Main.ColorOfTheSkies.G = (byte)sunG;
                Main.ColorOfTheSkies.B = (byte)sunB;

                tileColor.R = (byte)((Main.ColorOfTheSkies.R + Main.ColorOfTheSkies.G + Main.ColorOfTheSkies.B + Main.ColorOfTheSkies.R * 8) / 10);
                tileColor.G = (byte)((Main.ColorOfTheSkies.R + Main.ColorOfTheSkies.G + Main.ColorOfTheSkies.B + Main.ColorOfTheSkies.G * 8) / 10);
                tileColor.B = (byte)((Main.ColorOfTheSkies.R + Main.ColorOfTheSkies.G + Main.ColorOfTheSkies.B + Main.ColorOfTheSkies.B * 8) / 10);
            }
        }
    }
}