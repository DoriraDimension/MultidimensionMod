﻿using MultidimensionMod.Common.Globals;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent;
using Terraria.Graphics.Effects;
using Terraria.ID;

namespace MultidimensionMod.Biomes
{
    public class ShroudedMireDaySky : CustomSky
    {
        public static bool Open = false;
        public override void Deactivate(params object[] args)
        {
            skyActive = false;
        }
        public override Color OnTileColor(Color inColor)
        {
            Vector4 value = inColor.ToVector4();
            return new Color(Vector4.Lerp(value, Vector4.One, opacity * skyLight * 0.25f));
        }

        public override void Reset()
        {
            skyActive = false;
        }

        public override bool IsActive()
        {
            return skyActive || opacity > 0f;
        }

       

        public override void Activate(Vector2 position, params object[] args)
        {
            skyActive = true;
        }

        private float sunAlpha = 0;
        public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
        {
            Player player = Main.LocalPlayer;
            if (maxDepth >= 3E+38f && minDepth < 3E+38f)
            {
                string skyTexture = "MireDaySky";
                string sunTexture = "Sun";
                if (Main.dayTime && player.InModBiome<TheShroudedMire>())
                {
                    skyTexture = "MireDaySky";
                    spriteBatch.Draw(ModContent.Request<Texture2D>("MultidimensionMod/Backgrounds/" + skyTexture).Value, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), new Color(30, 30, 50, opacity));
                }
            }
        }
        public override void Update(GameTime gameTime)
        {
            if (skyActive)
            {
                if (opacity < 1f)
                    opacity += 0.02f;
                if (opacity > 1f)
                    opacity = 1f;

                if (Main.dayTime)
                    skyLight = Math.Min(1f, 0.005f + skyLight);
                if (!Main.dayTime)
                    skyLight = Math.Max(0f, skyLight - 0.005f);
            }
            else
            {
                if (opacity > 0f)
                    opacity -= 0.02f;
                if (opacity < 0f)
                    opacity = 0f;
            }
        }
        public override float GetCloudAlpha()
        {
            return (1f - opacity) * 0.97f + 0.03f;
        }

        private bool skyActive;

        private float opacity;
        private float skyLight;
    }

}