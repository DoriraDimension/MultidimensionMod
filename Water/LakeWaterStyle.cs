using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MultidimensionMod.Water
{
    public class LakeWaterStyle : ModWaterStyle
    {
        public override int ChooseWaterfallStyle()
        {
            return ModContent.GetInstance<LakeWaterfallStyle>().Slot;
        }

        public override int GetSplashDust()
        {
            return ModContent.DustType<LakeWaterSplash>();
        }

        public override int GetDropletGore()
        {
            return ModContent.Find<ModGore>("MultidimensionMod/LakeDroplet").Type;
        }

        /*public override Asset<Texture2D> GetRainTexture()
        {
            return Request<Texture2D>("MultidimensionMod/Water/DragonRain");
        }*/

        public override void LightColorMultiplier(ref float r, ref float g, ref float b)
        {
            r = 1f;
            g = 1f;
            b = 1f;
        }

        public override Color BiomeHairColor()
        {
            return Color.DarkBlue;
        }
    }
}