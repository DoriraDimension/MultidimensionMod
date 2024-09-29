using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace MultidimensionMod.Projectiles.Magic
{
    public class ArtSword : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            Projectile.width = 64;
            Projectile.height = 64;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.aiStyle = -1;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 15;
            Projectile.alpha = 0;
        }
        public override bool PreDraw(ref Color lightColor)
        {

            Main.instance.LoadProjectile(Projectile.type);
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D Overlay = (Texture2D)ModContent.Request<Texture2D>("MultidimensionMod/Projectiles/Magic/ArtSword_Glow");
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Color.AliceBlue;
                Color color2 = Color.AliceBlue;
                if (Projectile.ai[0] == 1)
                {
                    color = new Color(new Vector3(0.75f, 0.85f, 0.9f)) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                    color2 = new Color(new Vector3(1f, 1f, 1f)) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                }
                if (Projectile.ai[0] == 2)
                {
                    color = new Color(new Vector3(1f, 0.7f, 0.20f)) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                    color2 = new Color(new Vector3(1f, 0.85f, 0.30f)) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                }
                if (Projectile.ai[0] == 3)
                {
                    color = new Color(new Vector3(0.9f, 0.3f, 0.32f)) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                    color2 = new Color(new Vector3(1f, 0.38f, 0.40f)) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                }
                if (Projectile.ai[0] == 4)
                {
                    color = new Color(new Vector3(0.2f, 0.9f, 0.27f)) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                    color2 = new Color(new Vector3(0.35f, 1f, 0.40f)) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                }
                if (Projectile.ai[0] == 5)
                {
                    color = new Color(new Vector3(0.20f, 0.28f, 0.9f)) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                    color2 = new Color(new Vector3(0.32f, 0.42f, 1f)) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                }
                if (Projectile.ai[0] == 5)
                {
                    color = new Color(new Vector3(0.20f, 0.28f, 0.9f)) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                    color2 = new Color(new Vector3(0.32f, 0.42f, 1f)) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                }
                if (Projectile.ai[0] == 6)
                {
                    color = new Color(new Vector3(0.82f, 0.82f, 0.25f)) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                    color2 = new Color(new Vector3(0.96f, 0.96f, 0.39f)) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                }
                if (Projectile.ai[0] == 7)
                {
                    color = new Color(new Vector3(00.82f, 0.25f, 0.82f)) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                    color2 = new Color(new Vector3(0.96f, 0.39f, 0.96f)) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                }
                color.A = 0;
                color2.A = 0;
                Main.EntitySpriteDraw(texture, drawPos, null, color * 0.5f, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
                Main.EntitySpriteDraw(Overlay, drawPos, null, color2 * 0.925f, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            return false;

        }
        private int dir = 0;
        private Vector2 anchor = Vector2.Zero;
        public override void AI()
        {
            if (Projectile.timeLeft == 15)
            {
                Projectile.ai[0] = Main.rand.Next(1, 7);
                if (Projectile.ai[0] == 1)
                {
                    Projectile.ai[1] = DustID.WhiteTorch;
                }
                if (Projectile.ai[0] == 2)
                {
                    Projectile.ai[1] = DustID.OrangeTorch;
                }
                if (Projectile.ai[0] == 3)
                {
                    Projectile.ai[1] = DustID.RedTorch;
                }
                if (Projectile.ai[0] == 4)
                {
                    Projectile.ai[1] = DustID.GreenTorch;
                }
                if (Projectile.ai[0] == 5)
                {
                    Projectile.ai[1] = DustID.BlueTorch;
                }
                if (Projectile.ai[0] == 6)
                {
                    Projectile.ai[1] = DustID.YellowTorch;
                }
                if (Projectile.ai[0] == 7)
                {
                    Projectile.ai[1] = DustID.PurpleTorch;
                }
                Projectile.rotation = Projectile.velocity.ToRotation();
                Projectile.velocity = Vector2.Zero;
            }
            if (Projectile.ai[0] == 1)
            {
                Lighting.AddLight(Projectile.Center, new Vector3(0.75f, 0.85f, 0.9f));
            }
            if (Projectile.ai[0] == 2)
            {
                Lighting.AddLight(Projectile.Center, new Vector3(1f, 0.7f, 0.05f));
            }
            if (Projectile.ai[0] == 3)
            {
                Lighting.AddLight(Projectile.Center, new Vector3(0.9f, 0.01f, 0.02f));
            }
            if (Projectile.ai[0] == 4)
            {
                Lighting.AddLight(Projectile.Center, new Vector3(0.01f, 0.9f, 0.05f));
            }
            if (Projectile.ai[0] == 5)
            {
                Lighting.AddLight(Projectile.Center, new Vector3(0.03f, 0.06f, 0.9f));
            }
            if (Projectile.ai[0] == 6)
            {
                Lighting.AddLight(Projectile.Center, new Vector3(0.77f, 0.77f, 0.05f));
            }
            if (Projectile.ai[0] == 7)
            {
                Lighting.AddLight(Projectile.Center, new Vector3(0.77f, 0.05f, 0.77f));
            }
            if (Projectile.timeLeft == 15 & Main.player[Projectile.owner].direction == 1)
            {
                Projectile.rotation -= MathHelper.ToRadians(45);
                dir = 1;
                anchor = Projectile.position;
                for (int k = 0; k < 64; k++)
                {
                    int j = Dust.NewDust(Projectile.Center + ((Projectile.rotation - MathHelper.ToRadians(45)).ToRotationVector2() * k), 0, 0, (int)Projectile.ai[1], -Projectile.velocity.X / 7, -Projectile.velocity.Y / 7);
                    Main.dust[j].noGravity = true;
                }
            }
            if (Projectile.timeLeft == 15 & Main.player[Projectile.owner].direction == -1)
            {
                Projectile.rotation += MathHelper.ToRadians(120);
                dir = -1;
                anchor = Projectile.position;
                for (int k = 0; k < 64; k++)
                {
                    int j = Dust.NewDust(Projectile.Center + ((Projectile.rotation - MathHelper.ToRadians(45)).ToRotationVector2() * k), 0, 0, (int)Projectile.ai[1], -Projectile.velocity.X / 7, -Projectile.velocity.Y / 7);
                    Main.dust[j].noGravity = true;
                }
            }
            if (dir == 1)
            {
                Projectile.rotation += 0.18f;
            }
            if (dir == -1)
            {
                Projectile.rotation += -0.18f;
            }
            Projectile.position = anchor + ((Projectile.rotation - MathHelper.ToRadians(45)).ToRotationVector2() * 32f);
            int j1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, (int)Projectile.ai[1], -Projectile.velocity.X / 7, -Projectile.velocity.Y / 7);
            Main.dust[j1].noGravity = true;
            if (Projectile.timeLeft == 1)
            {
                for (int k = 0; k < 64; k++)
                {
                    int j = Dust.NewDust(Projectile.Center + ((Projectile.rotation - MathHelper.ToRadians(45)).ToRotationVector2() * (k - 32)), 0, 0, (int)Projectile.ai[1], -Projectile.velocity.X / 7, -Projectile.velocity.Y / 7);
                    Main.dust[j].noGravity = true;
                }
            }
        }

    }
}
