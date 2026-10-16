using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Buffs.Minions;
using MultidimensionMod.Projectiles.Ranged;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Summon.Minions
{
    public class EaterMinion : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
        }
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.minionSlots = 1f;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.minion = true;
            Projectile.netImportant = true;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
        }

        private enum AttackState
        {
            Retreat,
            Chasing,
            Dashing,
            Latched,
            Exploding
        }

        private AttackState State
        {
            get => (AttackState)(int)Projectile.ai[0];
            set => Projectile.ai[0] = (int)value;
        }

        private ref float Timer => ref Projectile.ai[1];

        private NPC GetTarget()
        {
            int index = (int)Projectile.ai[2];

            if (index >= 0 && index < Main.maxNPCs)
            {
                NPC npc = Main.npc[index];

                if (npc.active && npc.CanBeChasedBy(Projectile))
                    return npc;
            }

            return null;
        }
        int TimeUntilChase = 0;
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<EaterMinionBuff>());
            }
            if (player.HasBuff(ModContent.BuffType<EaterMinionBuff>()))
            {
                Projectile.timeLeft = 2;
            }
            if (State != AttackState.Latched)
            {
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            }

            NPC target = GetTarget();
            if (target != null && !target.CanBeChasedBy(Projectile))
            {
                target = null;
                Projectile.ai[2] = -1f;
            }

            // Find a target if we don't have one.
            if (target == null && State != AttackState.Latched)
            {
                float bestDistance = 700f;
                int bestTarget = -1;

                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC npc = Main.npc[i];

                    if (!npc.CanBeChasedBy(Projectile))
                        continue;

                    float distance = Vector2.Distance(
                        Projectile.Center, npc.Center);

                    if (distance < bestDistance)
                    {
                        bestDistance = distance;
                        bestTarget = i;
                    }
                }

                if (bestTarget != -1)
                {
                    Projectile.ai[2] = bestTarget;
                    target = Main.npc[bestTarget];
                }
            }

            Timer++;

            switch (State)
            {
                case AttackState.Retreat:
                    {
                        Vector2 idlePosition = player.Center + new Vector2(0, -60f);

                        MoveTowards(idlePosition, 10f, 0.12f);
                        TimeUntilChase++;
                        if (TimeUntilChase == 60)
                        {
                            State = AttackState.Chasing;
                            TimeUntilChase = 0;
                        }
                        break;
                    }
                case AttackState.Chasing:
                    {
                        if (target == null)
                        {
                            Vector2 idlePosition =
                                player.Center + new Vector2(0, -60f);

                            MoveTowards(idlePosition, 10f, 0.12f);
                            break;
                        }

                        // Approach the target before dashing.
                        Vector2 approachPosition =
                            target.Center + new Vector2(
                                -Projectile.direction * 70f, -15f);

                        MoveTowards(approachPosition, 10f, 0.12f);

                        if (Vector2.Distance(
                            Projectile.Center, target.Center) < 180f)
                        {
                            State = AttackState.Dashing;
                            Timer = 0f;

                            Vector2 dashDirection =
                                target.Center - Projectile.Center;

                            Projectile.velocity =
                                dashDirection.SafeNormalize(Vector2.UnitX) * 15f;
                        }

                        break;
                    }

                case AttackState.Dashing:
                    {
                        if (target == null)
                        {
                            State = AttackState.Chasing;
                            Timer = 0f;
                            break;
                        }

                        // Keep the dash aimed at the enemy.
                        Vector2 direction =
                            target.Center - Projectile.Center;

                        Projectile.velocity =
                            direction.SafeNormalize(Vector2.UnitX) * 15f;

                        if (Projectile.Hitbox.Intersects(target.Hitbox))
                        {
                            State = AttackState.Latched;
                            Timer = 0f;

                            Projectile.velocity = Vector2.Zero;
                            Projectile.friendly = false;
                        }
                        else if (Timer > 45f)
                        {
                            // Missed the dash; try again.
                            State = AttackState.Chasing;
                            Timer = 0f;
                        }

                        break;
                    }

                case AttackState.Latched:
                    {
                        if (target == null)
                        {
                            State = AttackState.Chasing;
                            Timer = 0f;
                            Projectile.friendly = true;
                            break;
                        }

                        // Stay attached as the enemy moves.
                        Vector2 attachmentOffset =
                            new Vector2(-target.direction * 12f, -4f);

                        Projectile.Center =
                            target.Center + attachmentOffset;

                        Projectile.velocity = Vector2.Zero;

                        Vector2 toTarget =
                            target.Center - Projectile.Center;

                        // Stay attached for 2 seconds.
                        if (Timer >= 120f)
                        {
                            State = AttackState.Exploding;
                            Timer = 0f;
                        }

                        break;
                    }

                case AttackState.Exploding:
                    {
                        Projectile.velocity = Vector2.Zero;

                        // Brief explosion animation/attack phase.
                        if (Timer == 1f && Projectile.owner == Main.myPlayer)
                        {
                            Projectile.NewProjectile(
                                Projectile.GetSource_FromAI(),
                                Projectile.Center,
                                Vector2.Zero,
                                ModContent.ProjectileType<EaterMinionExplosion>(),
                                Projectile.damage * 2,
                                Projectile.knockBack,
                                Projectile.owner
                            );
                        }

                        if (Timer >= 10f)
                        {
                            State = AttackState.Retreat;
                            Timer = 0f;
                            Projectile.friendly = true;
                            Projectile.ai[2] = -1f;
                        }

                        break;
                    }

            }
            int frameSpeed = 8;
            if (State == AttackState.Latched)
            {
                Projectile.frame = 2;
            }
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= frameSpeed)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                }
            }
        }

        private void MoveTowards(
            Vector2 destination,
            float maxSpeed,
            float inertia)
        {
            Vector2 offset = destination - Projectile.Center;
            float distance = offset.Length();

            if (distance < 8f)
            {
                Projectile.velocity *= 0.85f;
                return;
            }

            Vector2 desiredVelocity =
                offset.SafeNormalize(Vector2.Zero)
                * Math.Min(maxSpeed, distance * 0.15f);

            Projectile.velocity = Vector2.Lerp(
                Projectile.velocity,
                desiredVelocity,
                inertia
            );
        }
        private void MoveAway(
            Vector2 destination,
            float maxSpeed,
            float inertia)
        {
            Vector2 offset = destination - Projectile.Center;
            float distance = offset.Length();

            if (distance < 8f)
            {
                Projectile.velocity *= 0.85f;
                return;
            }

            Vector2 desiredVelocity =
                offset.SafeNormalize(Vector2.Zero)
                * Math.Min(maxSpeed, distance * 0.15f);

            Projectile.velocity = Vector2.Lerp(
                Projectile.velocity,
                desiredVelocity,
                inertia
            );
        }
    }

    internal class EaterMinionExplosion : ModProjectile
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
            Projectile.DamageType = DamageClass.Summon;
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