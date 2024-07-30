using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Buffs.Pets;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Pets
{
    public class Flash : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 8;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.CharacterPreviewAnimations[Projectile.type] = ProjectileID.Sets.SimpleLoop(0, 0).WithOffset(-20, 4).WithSpriteDirection(-1);
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.BabyDino);
            Projectile.width = 50;
            Projectile.height = 54;
            AIType = ProjectileID.BabyDino;
        }

        private int FrameY;
        private int FrameCounter;
        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner];
            player.dino = false;
            CheckActive(player);

            if (Projectile.ai[0] == 1)
            {
                if (FrameY < 4)
                    FrameY = 4;
                if (++FrameCounter >= 10)
                {
                    FrameCounter = 0;
                    if (++FrameY >= 7)
                        FrameY = 4;
                }
            }
            else
            {
                if (Projectile.velocity.X > -1 && Projectile.velocity.X < 1)
                    FrameY = 0;
                else
                {
                    if (FrameY < 1)
                        FrameY = 1;

                    FrameCounter += (int)(Projectile.velocity.X * 0.5f);
                    if (FrameCounter >= 2 || FrameCounter <= -2)
                    {
                        FrameCounter = 0;
                        if (++FrameY >= 3)
                            FrameY = 0;
                    }
                }
            }
            return true;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            int height = texture.Height / 8;
            int y = height * FrameY;
            Rectangle rect = new(0, y, texture.Width, height);
            Vector2 drawOrigin = new(texture.Width / 2, height / 2);
            var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            Main.EntitySpriteDraw(texture, Projectile.Center + new Vector2(0, 2) - Main.screenPosition, new Rectangle?(rect), Projectile.GetAlpha(lightColor), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            return false;
        }

        public override void AI()
        {

        }
        private void CheckActive(Player player)
        {
            if (!player.dead && player.HasBuff(ModContent.BuffType<TheFlash>()))
                Projectile.timeLeft = 2;
        }
    }
}