using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Yoyos
{
    public class GlimmerstarProj : ModProjectile
    {

        public override void SetDefaults()
        {
            Projectile.width = 28;
            Projectile.height = 28;
            Projectile.aiStyle = ProjAIStyleID.Yoyo;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
        }

        public int StarEmit = 0;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 7f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 250f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 13f;
        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.position, 0.5f, 0f, 0.2f);
            Player player = Main.player[Projectile.owner];
            StarEmit++;
            if (StarEmit % 60 == 0)
            {
                for (float i = 0; i < 5; i++)
                {
                    float angle = MathHelper.TwoPi / 5f * i;
                    Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, angle.ToRotationVector2() * 5f, ModContent.ProjectileType<GlimmerStar>(), Projectile.damage / 2, 0, player.whoAmI, angle, 0f);
                }
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 drawOrigin = new(texture.Width / 2, texture.Height / 2);
            var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(Color.White), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            return false;
        }
    }
}