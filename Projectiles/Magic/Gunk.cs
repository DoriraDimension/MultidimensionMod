using Microsoft.Xna.Framework;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria.GameContent;

namespace MultidimensionMod.Projectiles.Magic
{
    public class Gunk : ModProjectile
    {
        public int MaxDamage;
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Gunk");
        }
        public override void SetDefaults()
        {
            Projectile.penetrate = 1;  
            Projectile.width = 28;
            Projectile.height = 28;
			Projectile.friendly = true;
			Projectile.hostile = false;
            Projectile.timeLeft = 300;
            Projectile.aiStyle = -1;
            Projectile.alpha = 70;
            Projectile.DamageType = DamageClass.Magic;
        }

        public override void AI()
        {
            Projectile.ai[1] += 1f;
            Projectile.rotation = 1 + Main.rand.Next(4);
            if (Projectile.ai[1] < 180)
            {
                Projectile.scale += 0.018f;
                Projectile.height += (int)(double)0.018f;
                Projectile.width += (int)(double)0.018f;
                if (Projectile.ai[1] % 30 == 0)
                    Projectile.damage = Projectile.damage += Projectile.damage / 8;
            }
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {

        }

        public override void OnKill(int timeleft)
        {
            for (int num468 = 0; num468 < 20; num468++)
            {
                int num469 = Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<Dusts.AcidDust>(), -Projectile.velocity.X * 0.2f,
                    -Projectile.velocity.Y * 0.2f, 46, new Color(0, 255, 217), 1.184211f);
                Main.dust[num469].noGravity = true;
                Main.dust[num469].velocity *= 2f;
                num469 = Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<Dusts.AcidDust>(), -Projectile.velocity.X * 0.2f,
                    -Projectile.velocity.Y * 0.2f, 46, new Color(0, 255, 217), 1.184211f);
                Main.dust[num469].velocity *= 2f;
            }
        }


        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 position = Projectile.Center - Main.screenPosition;
            Rectangle rect = new(0, 0, texture.Width, texture.Height);
            Vector2 origin = new(texture.Width / 2f, texture.Height / 2f);

            Main.EntitySpriteDraw(texture, position, new Rectangle?(rect), lightColor, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0);

            return false;
        }
    }
}
