using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System.Collections.Generic;
using Terraria.DataStructures;

namespace MultidimensionMod.Projectiles.Ranged
{
    internal class BurstKunaiThrown : ModProjectile
    {
        public bool StickingToTarget
        {
            get => Projectile.ai[0] == 1f;
            set => Projectile.ai[0] = value ? 1f : 0f;
        }
        public int TargetWhoAmI
        {
            get => (int)Projectile.ai[1];
            set => Projectile.ai[1] = value;
        }
        public int DemiseTimer = 0;
        public int ExplosionDamage = 0;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.hide = false;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
            Projectile.hide = true;
            Projectile.timeLeft = 600;
            Projectile.penetrate = 2;
        }

        public override void OnSpawn(IEntitySource source)
        {
            ExplosionDamage = Projectile.damage;
        }

        public override void AI()
        {
            if (StickingToTarget)
            {
                int npcTarget = TargetWhoAmI;
                DemiseTimer++;
                Projectile.ignoreWater = true;
                Projectile.tileCollide = false;
                if (Main.npc[npcTarget].active && !Main.npc[npcTarget].dontTakeDamage)
                {
                    Projectile.Center = Main.npc[npcTarget].Center - Projectile.velocity * 2f;
                    Projectile.gfxOffY = Main.npc[npcTarget].gfxOffY;
                }
                else
                {
                    Projectile.Kill();
                }
            }
            if (!StickingToTarget)
            {
                Projectile.spriteDirection = (Vector2.Dot(Projectile.velocity, Vector2.UnitX) >= 0f).ToDirectionInt();
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
            }
            if (DemiseTimer == 180)
            {
                SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode, Projectile.position);
                if (Projectile.owner == Main.myPlayer)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y + 0f, 0f, 0f, ModContent.ProjectileType<BurstKunaiExplosion>(), ExplosionDamage * (int)(double)1.5f, 0f, Main.myPlayer);
                }
                Projectile.Kill();
            }
        }

        private const int MaxStickingKunai = 4;
        private readonly Point[] stickingKunai = new Point[MaxStickingKunai];
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/KunaiHit"), Projectile.position);
            StickingToTarget = true;
            TargetWhoAmI = target.whoAmI;
            Projectile.velocity = (target.Center - Projectile.Center) * 0.75f;
            Projectile.netUpdate = true;
            Projectile.damage = 0;
            Projectile.KillOldestJavelin(Projectile.whoAmI, Type, target.whoAmI, stickingKunai);
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
            {
                targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
            }
            // Return if the hitboxes intersects, which means the javelin collides or not
            return projHitbox.Intersects(targetHitbox);
        }

        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
        {
            if (StickingToTarget)
            {
                int npcIndex = TargetWhoAmI;
                if (npcIndex >= 0 && npcIndex < 200 && Main.npc[npcIndex].active)
                {
                    if (Main.npc[npcIndex].behindTiles)
                    {
                        behindNPCsAndTiles.Add(index);
                    }
                    else
                    {
                        behindNPCsAndTiles.Add(index);
                    }

                    return;
                }
            }
            behindNPCsAndTiles.Add(index);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Projectiles/Ranged/BurstKunaiThrown").Value;
            Texture2D glow = ModContent.Request<Texture2D>("MultidimensionMod/Projectiles/Ranged/BurstKunaiThrown_Glow").Value;
            Texture2D trail = ModContent.Request<Texture2D>("MultidimensionMod/Projectiles/Ranged/BurstKunaiThrown_Trail").Value;
            Vector2 drawOrigin = new(texture.Width / 2, texture.Height / 2);
            var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k] + Projectile.Size / 2f - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
                Color color = Color.White * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                if (!StickingToTarget)
                    Main.spriteBatch.Draw(trail, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale - k / (float)Projectile.oldPos.Length / 3, effects, 0);
            }

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(lightColor), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            Main.EntitySpriteDraw(glow, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(Color.White), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            return false;
        }
    }

    internal class BurstKunaiExplosion : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            Projectile.width = 52;
            Projectile.height = 52;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
            Projectile.timeLeft = 60;
        }

        public override void AI()
        {
            if (++Projectile.frameCounter >= 5)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            var effects = Projectile.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            int height = texture.Height / 5;
            int y = height * Projectile.frame;
            Rectangle rect = new(0, y, texture.Width, height);
            Vector2 drawOrigin = new(texture.Width / 2, Projectile.height / 2);

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, new Rectangle?(rect), Color.White, Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            return false;
        }
    }
}
