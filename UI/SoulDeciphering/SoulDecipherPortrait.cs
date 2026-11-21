using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace MultidimensionMod.UI.SoulDeciphering
{
    public class SoulDecipherPortrait : UIElement
    {
        private const int FrameWidth = 52;
        private const int FrameHeight = 82;
        private const int FrameCount = 5;
        private double idleTimer;
        private double nextBlinkTime;
        private bool idleBlinking;

        private enum PortraitAnimation
        {
            Talking,
            Idle,
            Studying,
            Finishing
        }

        private PortraitAnimation currentAnimation = PortraitAnimation.Talking;

        private int currentFrame;
        private double frameTimer;

        private double FrameDuration
        {
            get
            {
                return currentAnimation switch
                {
                    PortraitAnimation.Talking => 100,
                    PortraitAnimation.Idle => 300,
                    PortraitAnimation.Studying => 350,
                    PortraitAnimation.Finishing => 150,
                    _ => 300
                };
            }
        }

        private int AnimationColumn
        {
            get
            {
                return (int)currentAnimation;
            }
        }

        private bool IsLooping => currentAnimation == PortraitAnimation.Idle || currentAnimation == PortraitAnimation.Studying;

        public SoulDecipherPortrait()
        {
            Width.Set(FrameWidth, 0f);
            Height.Set(FrameHeight, 0f);
        }

        public void PlayTalking()
        {
            SetAnimation(PortraitAnimation.Talking);
        }

        public void PlayIdle()
        {
            SetAnimation(PortraitAnimation.Idle);
        }

        public void PlayStudying()
        {
            SetAnimation(PortraitAnimation.Studying);
        }

        public void PlayFinishing()
        {
            SetAnimation(PortraitAnimation.Finishing);
        }

        private void SetAnimation(PortraitAnimation animation)
        {
            if (currentAnimation == animation)
                return;

            currentAnimation = animation;
            currentFrame = 0;
            frameTimer = 0;

            idleTimer = 0;
            idleBlinking = false;

            if (animation == PortraitAnimation.Idle)
                nextBlinkTime = Main.rand.Next(2500, 5001);
        }

        private void UpdateIdleBlink(GameTime gameTime)
        {
            double elapsed = gameTime.ElapsedGameTime.TotalMilliseconds;

            if (!idleBlinking)
            {
                idleTimer += elapsed;

                if (idleTimer >= nextBlinkTime)
                {
                    idleBlinking = true;
                    currentFrame = 1;
                    frameTimer = 0;
                }

                return;
            }

            frameTimer += elapsed;

            while (frameTimer >= 80)
            {
                frameTimer -= 80;
                currentFrame++;

                if (currentFrame >= FrameCount)
                {
                    currentFrame = 0;
                    idleBlinking = false;
                    idleTimer = 0;
                    nextBlinkTime = Main.rand.Next(2500, 5001);
                    break;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (currentAnimation == PortraitAnimation.Idle)
            {
                UpdateIdleBlink(gameTime);
                return;
            }

            frameTimer += gameTime.ElapsedGameTime.TotalMilliseconds;

            while (frameTimer >= FrameDuration)
            {
                frameTimer -= FrameDuration;

                if (currentFrame < FrameCount - 1)
                {
                    currentFrame++;
                }
                else if (IsLooping)
                {
                    currentFrame = 0;
                }
                else
                {
                    // One-shot animation finished.
                    SetAnimation(PortraitAnimation.Idle);
                    break;
                }
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle dimensions = GetDimensions();

            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/UI/SoulDeciphering/SimaPortrait").Value;
            //Texture2D shimmerTexture = ModContent.Request<Texture2D>("MultidimensionMod/UI/SoulDeciphering/SimaPortrait2").Value;

            Rectangle sourceRectangle = new Rectangle(AnimationColumn * FrameWidth, currentFrame * FrameHeight, FrameWidth, FrameHeight);

            Rectangle destinationRectangle = new Rectangle((int)dimensions.X, (int)dimensions.Y, (int)dimensions.Width, (int)dimensions.Height);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    public class SoulSynchBackground : UIElement
    {
        private Texture2D texture;

        public SoulSynchBackground()
        {
            texture = ModContent.Request<Texture2D>("MultidimensionMod/UI/SoulDeciphering/SoulSynchUIPanel", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;

            Width.Set(texture.Width, 0f);
            Height.Set(texture.Height, 0f);

            IgnoresMouseInteraction = true;
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle dimensions = GetDimensions();
            spriteBatch.Draw(texture, new Vector2(dimensions.X, dimensions.Y), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}