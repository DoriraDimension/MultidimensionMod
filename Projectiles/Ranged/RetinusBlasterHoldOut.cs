using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace MultidimensionMod.Projectiles.Ranged
{
    public class RetinusBlasterHoldOut : ModProjectile
    {
        public int counter;

        public int charge;

        public override void SetDefaults()
        {
            Projectile.width = 80;
            Projectile.height = 38;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.hide = true;
            Projectile.ownerHitCheck = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 5;
            Projectile.ai[1] = 60;
        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, 0.3f, 0.05f, 0.05f);
            Projectile.ai[0]++;
            Player player = Main.player[Projectile.owner];
            if (player.direction == 1)
            {
                if (Projectile.timeLeft == 5)
                {
                    Projectile.ai[1] = 60;
                    SoundEngine.SoundPlayer.Play(SoundID.DD2_WitherBeastCrystalImpact, Projectile.Center);
                    Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(120);
                }
                Projectile.direction = 1;
            }
            if (player.direction == -1)
            {
                if (Projectile.timeLeft == 5)
                {
                    Projectile.ai[1] = 60;
                    SoundEngine.SoundPlayer.Play(SoundID.DD2_WitherBeastCrystalImpact, Projectile.Center);
                    Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90);
                }
                Projectile.direction = -1;
            }

            Projectile.spriteDirection = Projectile.direction;
            Projectile.timeLeft = 2;
            Projectile.Center = player.Center;
            Projectile.velocity = Vector2.Zero;
            player.ChangeDir(Projectile.direction);
            player.heldProj = Projectile.whoAmI;
            Projectile.rotation = player.Center.AngleTo(Main.MouseWorld) + MathHelper.ToRadians(90);
            Projectile.Center = player.Center + (Projectile.rotation - MathHelper.ToRadians(90)).ToRotationVector2() * -20 + (Projectile.rotation).ToRotationVector2() * (-5 * Projectile.direction);
            player.itemTime = 1;
            player.itemAnimation = 1;
            player.itemRotation = (Projectile.rotation.ToRotationVector2() * (float)Projectile.direction).ToRotation();
            if (!player.channel)
            {
                Projectile.Kill();
            }
            if (Projectile.ai[0] % Projectile.ai[1] == Projectile.ai[1] - 1)
            {
                if (Projectile.ai[1] != 15)
                {
                    Projectile.ai[1] -= 15;
                }
                SoundStyle laser = SoundID.Item33;
                laser.Volume = 0.5f;
                SoundEngine.SoundPlayer.Play(laser, Projectile.Center);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center + (Projectile.rotation - MathHelper.ToRadians(90)).ToRotationVector2() * 50, (Projectile.rotation - MathHelper.ToRadians(90)).ToRotationVector2() * 10, ModContent.ProjectileType<RetinusBeam>(), Projectile.damage, 0);
            }
        }

        public override void OnKill(int timeLeft)
        {
        }

        public override bool PreDraw(ref Color lightColor)
        {
            // SpriteEffects helps to flip texture horizontally and vertically
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
                spriteEffects = SpriteEffects.FlipHorizontally;

            // Getting texture of projectile
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);
            Texture2D texture_glow = (Texture2D)ModContent.Request<Texture2D>("MultidimensionMod/Projectiles/Ranged/RetinusBlasterHoldOut_Glow");
            // Calculating frameHeight and current Y pos dependence of frame
            // If the texture is without animation frameHeight is always texture.Height and startY is always 0
            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            int startY = frameHeight * Projectile.frame;

            // Get this frame on texture
            Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);

            Vector2 origin = sourceRectangle.Size() / 2f;
            float offsetY = -20f;
            float offsetY2 = -20f;
            origin.Y = (float)(Projectile.spriteDirection == 1 ? sourceRectangle.Height - offsetY : offsetY);
            if (Projectile.spriteDirection == -1)
            {
                origin.Y = (float)(Projectile.spriteDirection == -1 ? sourceRectangle.Height - offsetY2 : offsetY2);
            }


            // Applying lighting and draw current frame
            Color drawColor = Projectile.GetAlpha(lightColor);
            Main.EntitySpriteDraw(texture,
                Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
                sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);
            Main.EntitySpriteDraw(texture_glow,
                Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
                sourceRectangle, Color.White, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);

            // It's important to return false, otherwise we also draw the original texture.
            return false;
        }

        public override bool? CanDamage()
        {
            return false;
        }
    }
}