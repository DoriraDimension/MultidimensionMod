using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MultidimensionMod.Projectiles.Melee.Swords
{
    internal class AccursedStalker : ModProjectile
    {

        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.width = 34;
            Projectile.height = 34;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = false;
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.NPCDeath52, Projectile.position);

            for (int i = 0; i < 3; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Shadowflame, 0f, 0f, 100, default(Color), 2f);
                Main.dust[dustIndex].velocity *= 1.4f;
            }
        }

        public int Freeze = 0;

        public override void AI()
        {
            Freeze++;
            if (Freeze >= 60)
            {
                if (Projectile.timeLeft > 180)
                    Projectile.timeLeft = 180;

                Player player = Main.player[Projectile.owner];
                float distanceFromTarget = 700f;
                Vector2 targetCenter = Projectile.position;
                bool foundTarget = false;

                if (player.HasMinionAttackTargetNPC)
                {
                    NPC npc = Main.npc[player.MinionAttackTargetNPC];
                    float between = Vector2.Distance(npc.Center, Projectile.Center);
                    if (between < 2000f)
                    {
                        distanceFromTarget = between;
                        targetCenter = npc.Center;
                        foundTarget = true;
                        Projectile.netUpdate = true;
                    }
                }
                if (!foundTarget)
                {
                    for (int i = 0; i < Main.maxNPCs; i++)
                    {
                        NPC npc = Main.npc[i];
                        if (npc.CanBeChasedBy())
                        {
                            float between = Vector2.Distance(npc.Center, Projectile.Center);
                            bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
                            bool inRange = between < distanceFromTarget;
                            bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
                            bool closeThroughWall = between > 0f;
                            if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall))
                            {
                                distanceFromTarget = between;
                                targetCenter = npc.Center;
                                foundTarget = true;
                                Projectile.netUpdate = true;
                            }
                        }
                    }
                }

                float speed = 8f;
                float inertia = 20f;

                if (foundTarget)
                {
                    if (distanceFromTarget > 40f)
                    {
                        Vector2 direction = targetCenter - Projectile.Center;
                        direction.Normalize();
                        direction *= speed;
                        Projectile.velocity = (Projectile.velocity * (inertia - 1) + direction) / inertia;
                    }
                }
                else
                {
                    if (!foundTarget)
                    {
                        speed = 4f;
                        inertia = 60f;
                    }
                    else
                    {
                        speed = 8f;
                        inertia = 300f;
                    }
                }

                Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
                if (Projectile.velocity.Y > 16f)
                {
                    Projectile.velocity.Y = 16f;
                }
                Projectile.spriteDirection = Projectile.direction;
                if (++Projectile.frameCounter >= 5)
                {
                    Projectile.frameCounter = 0;
                    if (++Projectile.frame >= 5)
                    {
                        Projectile.frame = 0;
                    }
                }
            }
            else
                Projectile.velocity = new Vector2(0, 0);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Projectiles/Melee/Swords/AccursedStalker").Value;
            Texture2D glow = ModContent.Request<Texture2D>("MultidimensionMod/Projectiles/Melee/Swords/AccursedStalker_Glow").Value;
            var effects = Projectile.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            int height = texture.Height / 6;
            int y = height * Projectile.frame;
            Rectangle rect = new(0, y, texture.Width, height);
            Vector2 drawOrigin = new(texture.Width / 2, Projectile.height / 2);

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, new Rectangle?(rect), lightColor, Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            Main.EntitySpriteDraw(glow, Projectile.Center - Main.screenPosition, new Rectangle?(rect), Color.White, Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            return false;
        }
    }
}