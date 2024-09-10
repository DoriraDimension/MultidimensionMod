using MultidimensionMod.Common.Systems;
using MultidimensionMod.Items.Placeables;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.GameContent.Animations.IL_Actions.Sprites;

namespace MultidimensionMod.Items.Souls
{
    public class FungusDie : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 5;
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

        public int Decaying = 0;
        public bool WillDieNow = false;

        public override void AI()
        {
            Projectile.velocity.Y = 0.5f;
            if (++Projectile.frameCounter >= 34)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= 4)
                {
                    WillDieNow = true;
                    Projectile.frame = 4;
                }
            }
            if (WillDieNow)
            {
                Decaying++;
            }
            if (Decaying == 120)
            {
                Item.NewItem(Projectile.GetSource_FromThis(), Projectile.position, Projectile.Size, ModContent.ItemType<RottenMemory>(), 1);
                Projectile.Kill();
            }
        }
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.DD2_WitherBeastAuraPulse, Projectile.position);
            MemorySystem.seenMemory = true;
            int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.GlowingMushroom, 0f, 0f, 69, default(Color), 2f);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D shrem = ModContent.Request<Texture2D>(Projectile.ModProjectile.Texture).Value;
            Texture2D glow = ModContent.Request<Texture2D>(Projectile.ModProjectile.Texture + "_Glow").Value;
            int height = shrem.Height / 5;
            int y = height * Projectile.frame;
            Rectangle rect = new(0, y, shrem.Width, height);
            Vector2 drawOrigin = new(shrem.Width / 2, Projectile.height / 2);
            Main.EntitySpriteDraw(shrem, Projectile.Center - Main.screenPosition, new Rectangle?(rect), lightColor, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            Main.EntitySpriteDraw(glow, Projectile.Center - Main.screenPosition, new Rectangle?(rect), Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}