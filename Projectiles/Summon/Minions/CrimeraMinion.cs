using Microsoft.Xna.Framework;
using MultidimensionMod.Buffs.Minions;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Summon.Minions
{
    public class CrimeraMinion : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Crimtane Crimera");
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
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<CrimeraMinionBuff>());
            }
            if (player.HasBuff(ModContent.BuffType<CrimeraMinionBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            NPC target = Main.npc[player.MinionAttackTargetNPC];
            float maxDetectDistance = 700f;

            if (player.MinionAttackTargetNPC >= 0)
            {
                NPC potentialTarget = Main.npc[player.MinionAttackTargetNPC];

                if (potentialTarget.CanBeChasedBy(Projectile))
                {
                    target = potentialTarget;
                }
            }
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];

                if (!npc.CanBeChasedBy(Projectile))
                    continue;

                float distance = Vector2.Distance(Projectile.Center, npc.Center);

                if (distance < maxDetectDistance)
                {
                    maxDetectDistance = distance;
                    target = npc;
                }
            }

            if (target != null)
            {
                Vector2 desiredPosition = target.Center + new Vector2(0f, -100f);

                Vector2 direction = desiredPosition - Projectile.Center;

                if (direction.Length() > 10f)
                {
                    direction.Normalize();
                    direction *= 10f;
                }

                Projectile.velocity = Vector2.Lerp(Projectile.velocity, direction, 0.1f);
                if (maxDetectDistance < 100)
                {
                    Projectile.ai[0]++;

                    if (Projectile.ai[0] >= 8)
                    {
                        Projectile.ai[0] = 0;

                        VomitBlood(target);
                    }
                }

                Projectile.rotation = direction.ToRotation() + MathHelper.PiOver2;
                Projectile.rotation = (target.Center - Projectile.Center).ToRotation() + MathHelper.PiOver2;
            }
            else
            {
                // No target: stay near the player.
                Vector2 idlePosition =  player.Center + new Vector2(0f, -60f);

                Vector2 direction =  idlePosition - Projectile.Center;
                Vector2 vectorToIdlePosition = idlePosition - Projectile.Center;
                float distanceToIdlePosition = vectorToIdlePosition.Length();

                if (distanceToIdlePosition < 20)
                {
                    Projectile.velocity *= 0.9f;
                }
                else
                {
                    if (direction.Length() > 5f)
                    {
                        direction.Normalize();
                        direction *= 5f;
                    }
                    Projectile.velocity = Vector2.Lerp(Projectile.velocity, direction, 0.1f);
                }
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            } 
            int frameSpeed = 8;
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

        private void VomitBlood(NPC target)
        {
            Vector2 spawnPosition = Projectile.Bottom;

            Vector2 velocity = new Vector2(
                Main.rand.NextFloat(-1f, 1f),
                Main.rand.NextFloat(2f, 4f)
            );

            Projectile.NewProjectile(
                Projectile.GetSource_FromAI(),
                spawnPosition,
                velocity,
                ModContent.ProjectileType<GolemLaser>(),//ModContent.ProjectileType<BloodDroplet>(),
                Projectile.damage,
                Projectile.knockBack,
                Projectile.owner
            );
        }
    }
}