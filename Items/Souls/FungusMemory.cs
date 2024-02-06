using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ID;

namespace MultidimensionMod.Items.Souls
{
    public class FungusMemory : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 12;
        }
        public override void SetDefaults()
        {
            Projectile.damage = 24;
            Projectile.width = 58;
            Projectile.height = 126;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 9000;
        }

        public override bool? CanDamage() => false;

        public int DEATH = 0;
        private int LegFrame;
        public int E = 0;

        public override void AI()
        {
            DEATH++;
            Projectile.velocity.X = 0;
            Projectile.velocity.Y = 0;
            if (DEATH >= 240)
            {
                if (++Projectile.frameCounter >= 6)
                {
                    Projectile.frameCounter = 0;
                    if (++Projectile.frame >= 11)
                    {
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0f, 0f, ModContent.ProjectileType<FungusDie>(), 0, 0f);
                        Projectile.Kill();
                    }
                }
            }
            else
                Projectile.frame = 0;
            if (++E >= 8)
            {
                E = 0;
                LegFrame++;
                if (LegFrame > 3)
                    LegFrame = 0;
            }
            if (Projectile.frame == 7)
            {
                SoundEngine.PlaySound(SoundID.DD2_LightningBugHurt, Projectile.position);
                SoundEngine.PlaySound(SoundID.NPCHit1 with { Volume = -0.50f }, Projectile.position);
            }
        }

        public override void OnKill(int timeLeft)
        {
            Gore.NewGore(Projectile.GetSource_FromThis(), new Vector2(Projectile.Center.X - 15, Projectile.Center.Y), Projectile.velocity, ModContent.Find<ModGore>("MultidimensionMod/FungusDieGore1").Type, 1);
            Gore.NewGore(Projectile.GetSource_FromThis(), new Vector2(Projectile.Center.X + 15, Projectile.Center.Y), Projectile.velocity, ModContent.Find<ModGore>("MultidimensionMod/FungusDieGore2").Type, 1);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D shrem = ModContent.Request<Texture2D>(Projectile.ModProjectile.Texture).Value;
            Texture2D glow = ModContent.Request<Texture2D>(Projectile.ModProjectile.Texture + "_Glow").Value;
            int height = shrem.Height / 12;
            int y = height * Projectile.frame;
            Rectangle rect = new(0, y, shrem.Width, height);
            Vector2 drawOrigin = new(shrem.Width / 2, Projectile.height / 2);
            Main.EntitySpriteDraw(shrem, Projectile.Center - Main.screenPosition, new Rectangle?(rect), lightColor, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            Main.EntitySpriteDraw(glow, Projectile.Center - Main.screenPosition, new Rectangle?(rect), Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }

        public override void PostDraw(Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Souls/FungusLegs").Value;
            int height = texture.Height / 4;
            int y = height * LegFrame;
            Rectangle rect = new(0, y, texture.Width, height);
            Vector2 drawOrigin = new(texture.Width / 2, height / 2);

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, new Rectangle?(rect), Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
        }
    }
}