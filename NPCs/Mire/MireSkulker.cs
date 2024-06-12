using MultidimensionMod.Items.Accessories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Base;
using MultidimensionMod.Biomes;
using MultidimensionMod.Items.Materials;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.Audio;

namespace MultidimensionMod.NPCs.Mire
{

    public class MireSkulker : ModNPC
    {

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Skulker");

            Main.npcFrameCount[NPC.type] = 13;
        }

        public enum ActionState
        {
            Eeping,
            Threatening,
            Pursuing,
            Reflecting,
            Retreating
        }

        public ActionState AIState
        {
            get => (ActionState)NPC.ai[0];
            set => NPC.ai[0] = (int)value;
        }

        public override void SetDefaults()
        {
            if (grass)
                NPC.lifeMax = 100;
            else
                NPC.lifeMax = 80;
            if (spiked)
                NPC.damage = 26;
            else
                NPC.damage = 20;
            if (scarred)
                NPC.defense = 8;
            else
                NPC.defense = 14;
            NPC.value = Item.sellPrice(0, 0, 1, 0);
            NPC.aiStyle = -1;
            NPC.width = 56;
            NPC.height = 20;
            NPC.npcSlots = 1f;
            NPC.HitSound = SoundID.NPCHit42;
            NPC.DeathSound = SoundID.NPCDeath36;
            NPC.noGravity = false;
            NPC.noTileCollide = false;
            NPC.knockBackResist = 0f;
            SpawnModBiomes = new int[1] { ModContent.GetInstance<TheShroudedMire>().Type };
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Skulker")
            });
        }

        private bool Shell = false;
        private int ShellTimer = 0;
        private bool normal = false;
        private bool scarred = false;
        private bool grass = false;
        private bool spiked = false;
        private Vector2 homeTile;
        private int hasNotBeenAttackedSince = 0;

        public override void OnSpawn(IEntitySource source)
        {
            homeTile = new Vector2(NPC.position.X, NPC.position.Y);
            int choice = Main.rand.Next(4);
            if (choice == 0)
            {
                normal = true; //Normal Skulker
            }
            else if (choice == 1)
            {
                scarred = true; //Scarred variant, has less defense but is faster and has a larger aggression radius
            }
            else if (choice == 2)
            {
                grass = true; //Overgrown variant, has a glowmask and more health
            }
            else if (choice == 3)
            {
                spiked = true; //Spiked variant, does more damage
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {

            }
        }

        public override void AI()
        {
            Player target = Main.player[NPC.target];
            float distanceToPlayer = Vector2.Distance(target.Center, NPC.Center);
            float distanceToHome = Vector2.Distance(homeTile, NPC.Center);
            if (target.dead || !target.active || Vector2.Distance(target.Center, NPC.Center) > 5000)
            {
                NPC.TargetClosest();
            }
            /*if (spiked)
            {
                NPC.damage = 30;
            }
            if (scarred)
            {
                NPC.defense = 8;
            }
            if (grass)
            {
                NPC.lifeMax *= (int)1.2f;
            }*/
            hasNotBeenAttackedSince--;
            if (NPC.justHit)
            {
                hasNotBeenAttackedSince = 120;
            }
            int aggroDistance = 300;
            int attackDistance = 100;
            if (scarred)
            {
                aggroDistance = 400;
                attackDistance = 200;
            }
            switch (AIState)
            {
                case ActionState.Eeping:
                    NPC.velocity.X = 0;
                    NPC.frame.Y = 0;
                    if (distanceToPlayer < aggroDistance || hasNotBeenAttackedSince > 0) //Start telling player that this is your territory
                    {
                        SoundEngine.PlaySound(SoundID.Zombie77, NPC.position);
                        AIState = ActionState.Threatening;
                        NPC.netUpdate = true;
                    }
                    else if (hasNotBeenAttackedSince > 0)
                    {
                        SoundEngine.PlaySound(SoundID.Zombie77, NPC.position);
                        AIState = ActionState.Pursuing;
                        NPC.netUpdate = true;
                    }
                    break;
                case ActionState.Threatening:
                    NPC.frame.Y = 308;
                    if (distanceToPlayer > aggroDistance && hasNotBeenAttackedSince <= 0) //Return to sleep if player goes far enough away
                    {
                        AIState = ActionState.Eeping;
                        NPC.netUpdate = true;
                    }
                    else if (distanceToPlayer < attackDistance || hasNotBeenAttackedSince > 0) //Start attacking if player keeps getting closer because they have no sense for privacy
                    {
                        AIState = ActionState.Pursuing;
                        NPC.netUpdate = true;
                    }
                    break;
                case ActionState.Pursuing:
                    NPC.frameCounter += 1;
                    ShellTimer++;
                    if (NPC.frameCounter >= 5)
                    {
                        NPC.frameCounter = 0;
                        NPC.frame.Y += 44;
                        if (NPC.frame.Y >= 13 * 44)
                        {
                            NPC.frame.Y = 8 * 44;
                        }
                    }
                    PursuitAI();
                    if (distanceToHome > 800 && hasNotBeenAttackedSince > 0) //Stop pursuing and retreat back to nesting tile if not under attack
                    {
                        AIState = ActionState.Retreating;
                        NPC.netUpdate = true;
                    }
                    else if (ShellTimer == 240) //Stop moving and enter projectile reflecting stance
                    {
                        ShellTimer = 0;
                        AIState = ActionState.Reflecting;
                        NPC.netUpdate = true;
                    }
                    break;
                case ActionState.Reflecting:
                    NPC.frame.Y = 0;
                    NPC.defense = 30;
                    NPC.velocity.X = 0f;
                    ShellTimer++;
                    NPC.reflectsProjectiles = true;
                    if (ShellTimer >= 120) //Continue pursuit
                    {
                        NPC.reflectsProjectiles = false;
                        ShellTimer = 0;
                        if (scarred)
                            NPC.defense = 8;
                        else
                            NPC.defense = 14;
                        AIState = ActionState.Pursuing;
                        NPC.netUpdate = true;
                    }
                    else if (ShellTimer >= 120 && distanceToHome > 800 && hasNotBeenAttackedSince > 0) //Retreat back to nesting tile
                    {
                        NPC.reflectsProjectiles = false;
                        ShellTimer = 0;
                        if (scarred)
                            NPC.defense = 8;
                        else
                            NPC.defense = 14;
                        AIState = ActionState.Retreating;
                        NPC.netUpdate = true;
                    }
                    break;
                case ActionState.Retreating:
                    RetreatAI();
                    NPC.frameCounter += 1;
                    if (NPC.frameCounter >= 5)
                    {
                        NPC.frameCounter = 0;
                        NPC.frame.Y += 44;
                        if (NPC.frame.Y >= 7 * 44)
                        {
                            NPC.frame.Y = 1 * 44;
                        }
                    }
                    if (hasNotBeenAttackedSince > 0) //Go back to pursuing of attacked
                    {
                        AIState = ActionState.Pursuing;
                        NPC.netUpdate = true;
                    }
                    if (NPC.position == homeTile) //Go back to sleep if nesting tile was reached
                    {
                        AIState = ActionState.Eeping;
                        NPC.netUpdate = true;
                    }
                    break;
            }
        }

        public void PursuitAI()
        {
            Player target = Main.player[NPC.target];
            if (target.Center.X > NPC.Center.X)
            {
                NPC.spriteDirection = 1;
            }
            else
            {
                NPC.spriteDirection = -1;
            }
            float speedUp = 1.30f;
            float maxVel = 2.0f;
            if (scarred)
            {
                speedUp = 1.50f;
                maxVel = 3.0f;
            }
            if (NPC.Center.X > target.Center.X)
            {
                NPC.velocity.X -= speedUp;
                if (NPC.velocity.X > 0f)
                {
                    NPC.velocity.X -= speedUp;
                }
                if (NPC.velocity.X < 0f - maxVel)
                {
                    NPC.velocity.X = 0f - maxVel;
                }
                NPC.netUpdate = true;
            }
            if (NPC.Center.X < target.Center.X)
            {
                NPC.velocity.X += speedUp;
                if (NPC.velocity.X < 0f)
                {
                    NPC.velocity.X += speedUp;
                }
                if (NPC.velocity.X > maxVel)
                {
                    NPC.velocity.X = maxVel;
                }
                NPC.netUpdate = true;
            }
            BaseAI.WalkupHalfBricks(NPC);
            if (Math.Abs(NPC.velocity.X) == NPC.ai[1])
                NPC.velocity.X = NPC.ai[1] * NPC.spriteDirection;
            if (BaseAI.HitTileOnSide(NPC, 3))
            {
                if (NPC.velocity.X < 0f && NPC.direction == -1 || NPC.velocity.X > 0f && NPC.direction == 1)
                {
                    Vector2 newVec = BaseAI.AttemptJump(NPC.position, NPC.velocity, NPC.width, NPC.height, NPC.direction, NPC.directionY, 6, 5, 4, true);
                    if (NPC.velocity != newVec) { NPC.velocity = newVec; NPC.netUpdate = true; }
                }
                NPC.netUpdate = true;
            }
        }

        public void RetreatAI()
        {
            Player target = Main.player[NPC.target];
            if (target.Center.X > NPC.Center.X)
            {
                NPC.spriteDirection = 1;
            }
            else
            {
                NPC.spriteDirection = -1;
            }
            float speedUp = 1.30f;
            float maxVel = 3.0f;
            if (NPC.Center.X > target.Center.X)
            {
                NPC.velocity.X -= speedUp;
                if (NPC.velocity.X > 0f)
                {
                    NPC.velocity.X -= speedUp;
                }
                if (NPC.velocity.X < 0f - maxVel)
                {
                    NPC.velocity.X = 0f - maxVel;
                }
                NPC.netUpdate = true;
            }
            if (NPC.Center.X < target.Center.X)
            {
                NPC.velocity.X += speedUp;
                if (NPC.velocity.X < 0f)
                {
                    NPC.velocity.X += speedUp;
                }
                if (NPC.velocity.X > maxVel)
                {
                    NPC.velocity.X = maxVel;
                }
                NPC.netUpdate = true;
            }
            BaseAI.WalkupHalfBricks(NPC);
            if (Math.Abs(NPC.velocity.X) == NPC.ai[1])
                NPC.velocity.X = NPC.ai[1] * NPC.spriteDirection;
            if (BaseAI.HitTileOnSide(NPC, 3))
            {
                if (NPC.velocity.X < 0f && NPC.direction == -1 || NPC.velocity.X > 0f && NPC.direction == 1)
                {
                    Vector2 newVec = BaseAI.AttemptJump(NPC.position, NPC.velocity, NPC.width, NPC.height, NPC.direction, NPC.directionY, 6, 5, 4, true);
                    if (NPC.velocity != newVec) { NPC.velocity = newVec; NPC.netUpdate = true; }
                }
                NPC.netUpdate = true;
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome(ModContent.GetInstance<TheShroudedMire>()) && !Main.dayTime && NPC.CountNPCS(ModContent.NPCType<MireSkulker>()) < 4)
            {
                return SpawnCondition.OverworldNight.Chance * .10f;
            }
            return 0f;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SkulkerShell>(), 20));
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D crab = ModContent.Request<Texture2D>(NPC.ModNPC.Texture).Value;
            Texture2D scarCrab = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "Cracked").Value;
            Texture2D grassCrab = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "Grass").Value;
            Texture2D spikeCrab = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "Spiked").Value;
            Texture2D grassGlow = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "Grass_Glow").Value;
            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            if (scarred)
                spriteBatch.Draw(scarCrab, NPC.Center + new Vector2(0f, -5f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            else if (grass)
            {
                spriteBatch.Draw(grassCrab, NPC.Center + new Vector2(0f, -5f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
                if (!Main.dayTime)
                {
                    spriteBatch.Draw(grassGlow, NPC.Center + new Vector2(0f, -5f) - screenPos, NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
                }
            }
            else if (spiked)
                spriteBatch.Draw(spikeCrab, NPC.Center + new Vector2(0f, -5f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            else if (normal)
                spriteBatch.Draw(crab, NPC.Center + new Vector2(0f, -5f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            return false;
        }
    }
}


