using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Biomes;
using Terraria.Graphics.Shaders;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria;
using Terraria.Initializers;
using System;
using ReLogic.Content.Sources;
using System.Linq;

namespace MultidimensionMod.Backgrounds
{
    public class ShroudedMireBackground : ModSurfaceBackgroundStyle
    {
        readonly MireFog Fog = new MireFog(true);

        // Use this to keep far Backgrounds like the mountains.
        public override void ModifyFarFades(float[] fades, float transitionSpeed)
        {
            for (int i = 0; i < fades.Length; i++)
            {
                if (i == Slot)
                {
                    fades[i] += transitionSpeed;
                    if (fades[i] > 1f)
                    {
                        fades[i] = 1f;
                    }
                }
                else
                {
                    fades[i] -= transitionSpeed;
                    if (fades[i] < 0f)
                    {
                        fades[i] = 0f;
                    }
                }
            }
        }

        /* public override int ChooseFarTexture()
         {
             return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/ShroomForestBG3");
         }*/

        private static int SurfaceFrameCounter;
        private static int SurfaceFrame;
        /* public override int ChooseMiddleTexture()
         {
             return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/ShroomForestBG1");
         }*/

        public override int ChooseFarTexture()
        {
            return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/MireBG");
        }

        public override bool PreDrawCloseBackground(SpriteBatch spriteBatch)
		{
            Color DefaultFog = new Color(120, 120, 200);
            Fog.Update(ModContent.Request<Texture2D>("MultidimensionMod/Backgrounds/FogTexture").Value);
            Fog.Draw(ModContent.Request<Texture2D>("MultidimensionMod/Backgrounds/FogTexture").Value, true, DefaultFog);


            return true;
		}
    }
}