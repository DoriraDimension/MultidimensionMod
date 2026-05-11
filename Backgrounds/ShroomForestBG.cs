using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Utilities;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;
using MultidimensionMod.Biomes;
using System.Collections.Generic;

namespace MultidimensionMod.Backgrounds
{
    public class ShroomForestBackground : ModSurfaceBackgroundStyle
    {
        readonly SporeHaze Fog = new SporeHaze(true);

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

        public override int ChooseFarTexture()
        {
            return -1;
        }

        public override int ChooseMiddleTexture()
        {
            return -1;
        }
        public class Spore
        {
            public Vector2 Position;
            public float Scale = 1f;
            public float Opacity = 0f;
            public int LifeTime = 0;
            public float Rotation = 0f;

            public Spore(Vector2 StartPosition, float scale, float startingRotation)
            {
                Position = StartPosition;
                Scale = scale;
                Rotation = startingRotation;
            }
        }

        public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
        {
            return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/ShroomForestBG1");
        }
        public static List<Spore> Spores { get; internal set; } = new();

        public override bool PreDrawCloseBackground(SpriteBatch spriteBatch)
        {
            if (Main.rand.NextBool(10))
            {
                Spores.Add(new Spore(new Vector2(Main.rand.NextFloat(0f, Main.screenWidth), Main.screenHeight), Main.rand.NextFloat(0.9f, 1.2f), MathHelper.ToRadians(Main.rand.NextFloat(-30f, 30f))));
            }

            for (int i = 0; i < Spores.Count; i++)
            {
                Spores[i].LifeTime++;
                if (Main.dayTime)
                    Spores[i].Opacity -= 0.1f;
                if (Spores[i].LifeTime < 120 && Spores[i].Opacity < 0.5f)
                    Spores[i].Opacity += 0.01f;
                if (Spores[i].LifeTime > 1100)
                    Spores[i].Opacity -= 0.01f;
                Spores[i].Position.X += 1f * (float)Math.Sin((Main.time + Spores[i].Position.X) / 600);
                Spores[i].Position.Y += -2f * (float)Math.Abs(Math.Sin((Main.time + Spores[i].Position.Y) / 540));
                Spores[i].Scale += 0.001f;
            }
            Spores.RemoveAll(spore => spore.LifeTime > 1200);

            float a = 1300f;
            float b = 1750f;
            int[] textureSlots = new int[] {

                BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/ShroomForestBG1"),
            };
            int[] textureSlots2 = new int[] {

                BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/ShroomForestBG2"),
            };
            int[] textureSlots3 = new int[] {
                BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/ShroomForestBG3"),
            };
            int length3 = textureSlots3.Length;
            for (int i = 0; i < textureSlots3.Length; i++)
            {
                float bgParallax = 0.25f + 0.2f - (0.1f * (length3 - i));
                int textureSlot = textureSlots3[i];
                Main.instance.LoadBackground(textureSlot);
                float bgScale = 2.5f;
                int bgW = (int)(Main.backgroundWidth[textureSlot] * bgScale);
                SkyManager.Instance.DrawToDepth(Main.spriteBatch, 1f / bgParallax);
                float screenOff = typeof(Main).GetFieldValue<float>("screenOff", Main.instance);
                float scAdj = typeof(Main).GetFieldValue<float>("scAdj", Main.instance);
                int bgStart = (int)(-Math.IEEERemainder(Main.screenPosition.X * bgParallax, bgW) - (bgW / 2));
                int bgTop = (int)((-Main.screenPosition.Y + screenOff / 2f) / (Main.worldSurface * 16.0) * a + b) + (int)scAdj - ((length3 - i) * 1000);
                Color backColor = typeof(Main).GetFieldValue<Color>("ColorOfSurfaceBackgroundsModified", Main.instance);
                int bgLoops = Main.screenWidth / bgW + 2;
                if (Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                {
                    for (int k = 0; k < bgLoops; k++)
                    {
                        Main.spriteBatch.Draw(TextureAssets.Background[textureSlot].Value,
                            new Vector2(bgStart + bgW * k, bgTop),
                            new Rectangle(0, 0, Main.backgroundWidth[textureSlot], Main.backgroundHeight[textureSlot]),
                            backColor, 0f, default, bgScale, SpriteEffects.None, 0f);
                    }
                }

            }
            int length2 = textureSlots2.Length;
            for (int i = 0; i < textureSlots2.Length; i++)
            {
                float bgParallax = 0.32f + 0.2f - (0.1f * (length2 - i));
                int textureSlot = textureSlots2[i];
                Main.instance.LoadBackground(textureSlot);
                float bgScale = 2.5f;
                int bgW = (int)(Main.backgroundWidth[textureSlot] * bgScale);
                SkyManager.Instance.DrawToDepth(Main.spriteBatch, 1f / bgParallax);
                float screenOff = typeof(Main).GetFieldValue<float>("screenOff", Main.instance);
                float scAdj = typeof(Main).GetFieldValue<float>("scAdj", Main.instance);
                int bgStart = (int)(-Math.IEEERemainder(Main.screenPosition.X * bgParallax, bgW) - (bgW / 2));
                int bgTop = (int)((-Main.screenPosition.Y + screenOff / 2f) / (Main.worldSurface * 16.0) * a + b) + (int)scAdj - ((length2 - i) * 760);
                Color backColor = typeof(Main).GetFieldValue<Color>("ColorOfSurfaceBackgroundsModified", Main.instance);
                int bgLoops = Main.screenWidth / bgW + 2;
                if (Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                {
                    for (int k = 0; k < bgLoops; k++)
                    {
                        Main.spriteBatch.Draw(TextureAssets.Background[textureSlot].Value,
                            new Vector2(bgStart + bgW * k, bgTop),
                            new Rectangle(0, 0, Main.backgroundWidth[textureSlot], Main.backgroundHeight[textureSlot]),
                            backColor, 0f, default, bgScale, SpriteEffects.None, 0f);
                    }
                }

            }
            if(!Main.dayTime && Main.hardMode){
                Color DefaultFog = new Color(46, 0, 217);
                Fog.Update(ModContent.Request<Texture2D>("MultidimensionMod/Backgrounds/FogTexture").Value);
                Fog.Draw(ModContent.Request<Texture2D>("MultidimensionMod/Backgrounds/FogTexture").Value, true, DefaultFog);
            }

            int length = textureSlots.Length;
            for (int i = 0; i < textureSlots.Length; i++)
            {
                float bgParallax = 0.37f + 0.2f - (0.1f * (length - i));
                int textureSlot = textureSlots[i];
                Main.instance.LoadBackground(textureSlot);
                float bgScale = 2.5f;
                int bgW = (int)(Main.backgroundWidth[textureSlot] * bgScale);
                SkyManager.Instance.DrawToDepth(Main.spriteBatch, 1f / bgParallax);
                float screenOff = typeof(Main).GetFieldValue<float>("screenOff", Main.instance);
                float scAdj = typeof(Main).GetFieldValue<float>("scAdj", Main.instance);
                int bgStart = (int)(-Math.IEEERemainder(Main.screenPosition.X * bgParallax, bgW) - (bgW / 2));
                int bgTop = (int)((-Main.screenPosition.Y + screenOff / 2f) / (Main.worldSurface * 16.0) * a + b) + (int)scAdj - ((length - i) * 850);
                Color backColor = typeof(Main).GetFieldValue<Color>("ColorOfSurfaceBackgroundsModified", Main.instance);
                int bgLoops = Main.screenWidth / bgW + 2;
                if (Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                {
                    for (int k = 0; k < bgLoops; k++)
                    {
                        Main.spriteBatch.Draw(TextureAssets.Background[textureSlot].Value,
                            new Vector2(bgStart + bgW * k, bgTop),
                            new Rectangle(0, 0, Main.backgroundWidth[textureSlot], Main.backgroundHeight[textureSlot]),
                            backColor, 0f, default, bgScale, SpriteEffects.None, 0f);
                    }
                }

            }

            Texture2D sporeTexture = ModContent.Request<Texture2D>("MultidimensionMod/Backgrounds/Spore").Value;
            for (int i = 0; i < Spores.Count; i++)
            {
                Vector2 drawCenter =Main.LocalPlayer.Center;//Main.screenPosition + new Vector2(Main.screenWidth * 0.5f, Main.screenHeight * 0.5f);
                spriteBatch.Draw(sporeTexture, Spores[i].Position, null, (Main.hardMode ? new Color(214, 185, 252) : new Color(255, 80, 80)) * Spores[i].Opacity * 0.3f, 1f * ((float)(Main.time + Spores[i].Position.Y) / 900), sporeTexture.Size() * 0.5f, Spores[i].Scale, 0, 0f);
            }


            return false;
        }
    }
}