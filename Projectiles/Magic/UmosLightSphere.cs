using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil;
using MultidimensionMod.NPCs.Bosses.FeudalFungus;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Magic
{
    internal class UmosLightSphere : ModProjectile
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.width = 80;
            Projectile.height = 80;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.localNPCHitCooldown = 30;
            Projectile.ownerHitCheck = true;
            Projectile.alpha = 190;
        }

        public override bool? CanDamage() => false;

        public int Freeze = 0;

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Freeze++;
            if (Freeze >= 20 && Freeze <= 89)
            {
                Projectile.velocity = new Vector2(0, 0);
            }
            else if (Freeze >= 90 && Freeze <= 139)
            {
                Vector2 targetCenter = Main.MouseWorld;
                float ProjSpeed = 40f;
                Vector2 velocity = targetCenter - Projectile.Center;
                velocity.Normalize();
                velocity *= ProjSpeed;
                Projectile.velocity = velocity;
            }
            else if (Freeze >= 140)
            {
                if (Projectile.owner == Main.myPlayer)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Main.MouseWorld.X, Main.MouseWorld.Y, 0f, 0f, ModContent.ProjectileType<LightSphereMouse>(), Projectile.damage, 0, player.whoAmI);
                    Freeze = 140;
                    Projectile.Kill();
                }
            }
            if (!player.channel || player.statMana <= 0)
            {
                Projectile.Kill();
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 position = Projectile.Center - Main.screenPosition;
            Rectangle rect = new(0, 0, texture.Width, texture.Height);
            Vector2 origin = new(texture.Width / 2f, texture.Height / 2f);

            Main.EntitySpriteDraw(texture, position, new Rectangle?(rect), Color.White, Projectile.rotation, origin, 0.4f, SpriteEffects.None, 0);

            return false;
        }
    }

    public class LightSphereMouse : ModProjectile
    {
        public override string Texture => "MultidimensionMod/Projectiles/Magic/UmosLightSphere";
        public override void SetDefaults()
        {
            Projectile.width = 80;
            Projectile.height = 80;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.localNPCHitCooldown = 30;
            Projectile.ownerHitCheck = true;
            Projectile.alpha = 190;
        }

        public override bool? CanDamage() => false;

        public int Freeze = 0;

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.Center = Main.MouseWorld;
            if (!player.channel || player.statMana <= 0)
            {
                Projectile.Kill();
            }
            float distanceToPlayer = Vector2.Distance(player.Center, Projectile.Center);
            if (distanceToPlayer >= 50)
            {
                Projectile.localAI[0]++;
            }
            else if (distanceToPlayer <= 50 && Projectile.Center == Main.MouseWorld)
            {
                player.lifeRegen += 6;
            }
            if (Projectile.localAI[0] > 55 && distanceToPlayer >= 50)
            {
                player.statMana -= 25;
                Projectile.netUpdate = true;
                for (int i = 0; i < 8; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(player.velocity.X / 2, -20).RotatedByRandom(MathHelper.ToRadians(60));
                    if (Projectile.owner == Main.myPlayer)
                    {
                        Projectile.NewProjectile(player.GetSource_FromThis(), Main.MouseWorld, perturbedSpeed, ModContent.ProjectileType<PureRadianceShotFriendly>(), Projectile.damage, 0);
                    }
                    SoundEngine.PlaySound(Sounds.CustomSounds.RadianceShot with { Volume = 0.70f }, player.position);
                }
                Projectile.localAI[0] = 0;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 position = Projectile.Center - Main.screenPosition;
            Rectangle rect = new(0, 0, texture.Width, texture.Height);
            Vector2 origin = new(texture.Width / 2f, texture.Height / 2f);

            Main.EntitySpriteDraw(texture, position, new Rectangle?(rect), Color.White, Projectile.rotation, origin, 0.4f, SpriteEffects.None, 0);

            return false;
        }
    }
}
