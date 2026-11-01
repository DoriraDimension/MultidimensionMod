using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Buffs.Minions;
using MultidimensionMod.NPCs.Bosses.Smiley;
using MultidimensionMod.NPCs.Dungeon;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Summon.Minions
{

	public class ServantofOcram2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 4;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
		}

		public sealed override void SetDefaults()
		{
			Projectile.width = 50;
			Projectile.height = 50;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.minionSlots = 1f;
			Projectile.penetrate = -1;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 15;
		}

		public override bool? CanCutTiles()
		{
			return false;
		}

		public override bool MinionContactDamage()
		{
			return true;
		}

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            // Active check
            if (player.dead || !player.active)
                player.ClearBuff(ModContent.BuffType<OcramServantBuff>());

            if (player.HasBuff(ModContent.BuffType<OcramServantBuff>()))
                Projectile.timeLeft = 2;

            // Idle position
            Vector2 idlePosition = player.Center;
            idlePosition.Y -= 48f;
            idlePosition.X += (10 + Projectile.minionPos * 40) * -player.direction;

            Vector2 vectorToIdlePosition = idlePosition - Projectile.Center;
            float distanceToIdlePosition = vectorToIdlePosition.Length();

            if (Main.myPlayer == Projectile.owner && distanceToIdlePosition > 2000f)
            {
                Projectile.Center = idlePosition;
                Projectile.velocity = Vector2.Zero;
                Projectile.netUpdate = true;
            }

            // Find target
            float distanceFromTarget = 700f;
            Vector2 targetCenter = Projectile.Center;
            bool foundTarget = false;

            if (player.HasMinionAttackTargetNPC)
            {
                int targetIndex = player.MinionAttackTargetNPC;

                if (targetIndex >= 0 && targetIndex < Main.maxNPCs)
                {
                    NPC npc = Main.npc[targetIndex];

                    if (npc.active && npc.CanBeChasedBy())
                    {
                        float between = Vector2.Distance(npc.Center, Projectile.Center);

                        if (between < 2000f)
                        {
                            distanceFromTarget = between;
                            targetCenter = npc.Center;
                            foundTarget = true;
                        }
                    }
                }
            }

            if (!foundTarget)
            {
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC npc = Main.npc[i];

                    if (!npc.CanBeChasedBy())
                        continue;

                    float between = Vector2.Distance(npc.Center, Projectile.Center);

                    if (between < distanceFromTarget)
                    {
                        bool lineOfSight = Collision.CanHitLine(
                            Projectile.position, Projectile.width, Projectile.height,
                            npc.position, npc.width, npc.height);

                        bool closeThroughWall = between < 100f;

                        if (lineOfSight || closeThroughWall)
                        {
                            distanceFromTarget = between;
                            targetCenter = npc.Center;
                            foundTarget = true;
                        }
                    }
                }
            }

            Projectile.friendly = foundTarget;

            // Attack sequence
            if (foundTarget)
            {
                // Countdown until detonation
                Projectile.ai[0]++;

                // Erratic movement
                if (Projectile.ai[2] <= 0)
                {
                    if (Main.myPlayer == Projectile.owner)
                    {
                        Projectile.ai[1] = Main.rand.NextFloat(MathHelper.TwoPi);
                        Projectile.ai[2] = Main.rand.Next(15, 36);
                        Projectile.localAI[0] = Main.rand.NextFloat(110f, 230f);

                        Projectile.netUpdate = true;
                    }
                }

                Projectile.ai[2]--;

                float orbitDistance = Projectile.localAI[0];

                Vector2 orbitPosition = targetCenter +
                    new Vector2(
                        (float)Math.Cos(Projectile.ai[1]),
                        (float)Math.Sin(Projectile.ai[1])
                    ) * orbitDistance;

                Vector2 direction = orbitPosition - Projectile.Center;

                if (direction.Length() > 10f)
                {
                    direction.Normalize();
                    direction *= 15f;

                    Projectile.velocity = (Projectile.velocity * 19f + direction) / 20f;
                }

                // Laser attack
                Projectile.localAI[1]++;

                if (Projectile.localAI[1] >= 45f)
                {
                    Projectile.localAI[1] = 0f;

                    if (Main.myPlayer == Projectile.owner)
                    {
                        Vector2 laserDirection = targetCenter - Projectile.Center;
                        laserDirection.Normalize();
                        SoundEngine.PlaySound(SoundID.Item12 with { Volume = 0.50f }, Projectile.position);
                        SoundEngine.PlaySound(SoundID.Item33 with { Volume = 0.50f }, Projectile.position);
                        Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, laserDirection * 12f, ModContent.ProjectileType<OcramLaser>(), (int)(Projectile.damage * 0.7f), Projectile.knockBack, Projectile.owner);
                    }
                }

                //Summon demon sickles after 6 seconds
                if (Projectile.ai[0] >= 360f)
                {
                    if (Main.myPlayer == Projectile.owner)
                    {
                        int sickleType = ModContent.ProjectileType<OcramDemonSickle>();
                        int sickleDamage = (int)(Projectile.damage * 0.6f);

                        for (int i = 0; i < 8; i++)
                        {
                            float angle = MathHelper.TwoPi / 8f * i;

                            Vector2 sickleVelocity = new Vector2(
                                (float)Math.Cos(angle),
                                (float)Math.Sin(angle)
                            ) * 9f;
                            SoundEngine.PlaySound(SoundID.Item8, Projectile.position);
                            Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, sickleVelocity, sickleType, sickleDamage, Projectile.knockBack, Projectile.owner);
                        }
                    }

                    Projectile.ai[0] = 0;
                    return;
                }
            }
            else
            {
                // Return to the player when no target exists
                Projectile.ai[0] = 0f;
                Projectile.ai[2] = 0f;

                float speed = distanceToIdlePosition > 600f ? 27f : 14f;
                float inertia = distanceToIdlePosition > 600f ? 60f : 80f;

                if (distanceToIdlePosition > 20f)
                {
                    vectorToIdlePosition.Normalize();
                    vectorToIdlePosition *= speed;

                    Projectile.velocity =
                        (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
                }
                else if (Projectile.velocity == Vector2.Zero)
                {
                    Projectile.velocity = new Vector2(-0.15f, -0.05f);
                }
            }

            // Animation and visuals
            Projectile.rotation = Projectile.velocity.X * 0.03f;

            Projectile.frameCounter++;

            if (Projectile.frameCounter >= 6)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;

                if (Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }

            Lighting.AddLight(Projectile.Center, Color.White.ToVector3() * 0.78f);
        }
    }

    public class OcramLaser : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 12;
            Projectile.height = 12;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Summon;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 90;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.extraUpdates = 1;
        }

        public override void AI()
        {
            Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.spriteDirection = Projectile.direction;

            Lighting.AddLight(
                Projectile.Center,
                0.3f,
                0.05f,
                0.5f
            );
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            //Deal 3x as much damage to Mechdusa's components
            if (target.type >= NPCID.SkeletronPrime || target.type >= NPCID.PrimeCannon || target.type >= NPCID.PrimeVice || target.type >= NPCID.PrimeLaser
                 || target.type >= NPCID.PrimeSaw || target.type >= NPCID.TheDestroyer || target.type >= NPCID.TheDestroyerBody || target.type >= NPCID.TheDestroyerTail
                  || target.type >= NPCID.Retinazer || target.type >= NPCID.Spazmatism)
            {
                if (Main.zenithWorld)
                {
                    modifiers.FinalDamage += (int)3.0f;
                }
            }
        }
    }

    public class OcramDemonSickle : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Summon;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 240;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 15;
        }

        public override void AI()
        {
            // Find the closest enemy
            NPC target = null;
            float distance = 500f;

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];

                if (!npc.CanBeChasedBy())
                    continue;

                float between = Vector2.Distance(
                    Projectile.Center,
                    npc.Center
                );

                if (between < distance)
                {
                    distance = between;
                    target = npc;
                }
            }

            // Home toward the target
            if (target != null)
            {
                Vector2 direction = target.Center - Projectile.Center;
                direction.Normalize();

                float speed = 12f;
                float inertia = 20f;

                Projectile.velocity =
                    (Projectile.velocity * (inertia - 1) + direction * speed) / inertia;
            }

            Projectile.rotation += 0.4f;
            Projectile.spriteDirection = Projectile.direction;

            Lighting.AddLight(
                Projectile.Center,
                0.35f,
                0.05f,
                0.45f
            );
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            //Deal 3x as much damage to Mechdusa's components
            if (target.type >= NPCID.SkeletronPrime || target.type >= NPCID.PrimeCannon || target.type >= NPCID.PrimeVice || target.type >= NPCID.PrimeLaser
                 || target.type >= NPCID.PrimeSaw || target.type >= NPCID.TheDestroyer || target.type >= NPCID.TheDestroyerBody || target.type >= NPCID.TheDestroyerTail
                  || target.type >= NPCID.Retinazer || target.type >= NPCID.Spazmatism)
            {
                if (Main.zenithWorld)
                {
                    modifiers.FinalDamage += (int)3.0f;
                }
            }
        }

    }
}