using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using MultidimensionMod.Items.Weapons.Magic.Tomes;

namespace MultidimensionMod.Projectiles.Magic
{
    public class AncientSwordArtHeld : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
            ProjectileID.Sets.HeldProjDoesNotUsePlayerGfxOffY[Projectile.type] = true;
        }
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 22;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.aiStyle = -1;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 1;
            Projectile.alpha = 0;
        }
        public override void AI()
        {
            
            Player player = Main.player[Projectile.owner];
            Projectile.Center = player.Center;
            if (player.ItemAnimationActive)
            {
                Projectile.timeLeft = 2;
                
            }
            if (player.direction == 1)
            {
                Projectile.spriteDirection = 1;
                Projectile.Center += new Vector2(15, -2 + player.gfxOffY);
            }
            player.heldProj = Projectile.whoAmI;
            if (player.direction == -1)
            {
                Projectile.spriteDirection = -1;
                Projectile.Center += new Vector2(-15, -2 + player.gfxOffY);
            }
            Lighting.AddLight(Projectile.Center, TorchID.Rainbow);
            if ((++Projectile.ai[0] % 3 == 1))
            {
                if (++Projectile.frameCounter >= 4)
                {
                    Projectile.frameCounter = 0;
                    if (++Projectile.frame >= 4)
                    {
                        Projectile.frame = 0;
                    }
                }
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Projectiles/Magic/AncientSwordArtHeld").Value;
            Texture2D glow = ModContent.Request<Texture2D>("MultidimensionMod/Projectiles/Magic/AncientSwordArtHeld_Glow").Value;
            var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            int height = texture.Height / 4;
            int y = height * Projectile.frame;
            Rectangle rect = new(0, y, texture.Width, height);
            Vector2 drawOrigin = new(texture.Width / 2, Projectile.height / 2);

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, new Rectangle?(rect), lightColor, Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            Main.EntitySpriteDraw(glow, Projectile.Center - Main.screenPosition, new Rectangle?(rect), Color.White, Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            return false;
        }
    }
}
