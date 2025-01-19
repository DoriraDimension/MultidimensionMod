using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.Graphics.Renderers;
using Microsoft.Xna.Framework.Graphics;

namespace MultidimensionMod.Projectiles.Ranged
{
    public class RetinusBeam : ModProjectile
    {
        public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 7;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 3;
            // base.DisplayName.SetDefault("Retinus Beam");
        }

        public override void SetDefaults()
        {
            Projectile.width = 15;
            Projectile.height = 15;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.tileCollide = true;
            Projectile.penetrate = 10;
            Projectile.extraUpdates = 0;
            Projectile.timeLeft = 100;
        }

        public override void AI()
        {
            Projectile.velocity *= 1.05f;
            Projectile.rotation = Projectile.velocity.ToRotation();
            Lighting.AddLight(Projectile.Center, 0.3f, 0.05f, 0.05f);
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Main.instance.LoadProjectile(ProjectileID.PiercingStarlight);
            Texture2D texture = TextureAssets.Projectile[ProjectileID.PiercingStarlight].Value;
            Rectangle frame = texture.Frame();
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Color j = new Color(255 - (Projectile.alpha / 24), 66 - (Projectile.alpha / 24), 66 - (Projectile.alpha / 24), Projectile.alpha) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length) * 2.0f;
                Rectangle scaledk = new Rectangle((int)Projectile.oldPos[k].X - (int)Main.screenPosition.X, (int)Projectile.oldPos[k].Y - (int)Main.screenPosition.Y, 30, 10);
                Main.EntitySpriteDraw(texture, Projectile.oldPos[k] + new Vector2(7.5f, 7.5f) - Main.screenPosition - new Vector2(30, 10).RotatedBy(Projectile.rotation), frame, j, Projectile.rotation, Projectile.getRect().Size(), scaledk.Size() / 30, SpriteEffects.None);
            }
            return false;

        }
        public override void OnKill(int timeLeft)
        {
            SoundEngine.SoundPlayer.Play(SoundID.DD2_LightningAuraZap, Projectile.Center);
            FadingParticle j2 = new FadingParticle();
            j2.SetBasicInfo(TextureAssets.Projectile[ProjectileID.StardustTowerMark], new Rectangle?(), Vector2.Zero, Projectile.Center);
            j2.SetTypeInfo(10);
            j2.FadeInNormalizedTime = 0.1f;
            j2.FadeOutNormalizedTime = 0.1f;
            j2.ColorTint = new Color(1.0f, 0.15f, 0.15f);
            j2.Scale = new Vector2(0.3f, 0.3f);
            j2.ScaleVelocity = new Vector2(0.4f, 0.4f);
            j2.ScaleAcceleration = new Vector2(-0.1f, -0.1f);
            Main.ParticleSystem_World_OverPlayers.Add(j2);
            FadingParticle j = new FadingParticle();
            j.SetBasicInfo(TextureAssets.Projectile[ProjectileID.StardustTowerMark], new Rectangle?(), Vector2.Zero, Projectile.Center);
            j.SetTypeInfo(10);
            j.FadeInNormalizedTime = 0.1f;
            j.FadeOutNormalizedTime = 0.1f;
            j.ColorTint = new Color(1.0f, 1f, 1f);
            j.Scale = new Vector2(0.1f, 0.1f);
            j.ScaleVelocity = new Vector2(0.4f, 0.4f);
            j.ScaleAcceleration = new Vector2(-0.1f, -0.1f);
            Main.ParticleSystem_World_OverPlayers.Add(j);
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.immune[Projectile.owner] = 5;
        }
    }
}