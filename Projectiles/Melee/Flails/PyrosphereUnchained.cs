using MultidimensionMod.Dusts;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using Terraria.Audio;
using ReLogic.Content;

namespace MultidimensionMod.Projectiles.Melee.Flails
{
    internal class PyrosphereUnchained : ModProjectile
    {
        public override string Texture => "MultidimensionMod/Projectiles/Melee/Flails/PyrosphereBall";

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 6;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 360;
        }

        public bool drowning = false;

        public override void AI()
        {
            if (Projectile.wet)
                drowning = true;
            Projectile.rotation += (float)0.2 * Projectile.direction;
            if (!drowning)
            {
                int dusto = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Torch, Projectile.velocity.X * 0.30f, Projectile.velocity.Y * 0.30f, 68, default(Color), 1f);
                Main.dust[dusto].noGravity = true;
            }
            if (Projectile.velocity.X > 0)
            {
                Projectile.direction = 1;
            }
            else
            {
                Projectile.direction = -1;
            }
            Projectile.velocity.Y = Projectile.velocity.Y + 0.1f;
            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (drowning)
                target.AddBuff(BuffID.OnFire, 180);
        }

        public override void OnKill(int timeLeft)
        {
            if (drowning)
                SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            else
                SoundEngine.PlaySound(SoundID.NPCDeath14, Projectile.position);
            if (!drowning)
                if (Main.myPlayer == Projectile.owner)
                    Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, Projectile.velocity, ModContent.ProjectileType<PyrosphereExplosion>(), Projectile.damage, Projectile.knockBack, Main.myPlayer);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            SpriteEffects spriteEffects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Color.White * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                if (!drowning)
                    Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale - k / (float)Projectile.oldPos.Length / 3, spriteEffects, 0f);
            }

            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D textureOff = ModContent.Request<Texture2D>("MultidimensionMod/Projectiles/Melee/Flails/PyrosphereBallExtinguished").Value;
            Vector2 drawOrigine = new(texture.Width / 2, texture.Height / 2);
            var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            if (drowning)
                Main.EntitySpriteDraw(textureOff, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(lightColor), Projectile.rotation, drawOrigine, Projectile.scale, effects, 0);
            else
                Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(Color.White), Projectile.rotation, drawOrigine, Projectile.scale, effects, 0);
            return false;
        }
    }
}