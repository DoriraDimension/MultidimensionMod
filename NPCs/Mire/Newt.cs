using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Base;
using MultidimensionMod.Biomes;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Mushrooms;
using MultidimensionMod.Items.Weapons.Magic.Staffs;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Mire
{
    public class Newt : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Newt");
            Main.npcFrameCount[NPC.type] = 14;
        }

        public enum ActionState
        {
            Walking,
            Artillery
        }

        public ActionState AIState
        {
            get => (ActionState)NPC.ai[0];
            set => NPC.ai[0] = (int)value;
        }

        public override void SetDefaults()
        {
            NPC.width = 114;
            NPC.height = 40;
            NPC.damage = 10;
            NPC.defense = 10;
            NPC.damage = 28;
            NPC.defense = 6;
            NPC.lifeMax = 60;
            NPC.knockBackResist = 0.55f;
            NPC.value = 100f;
            NPC.aiStyle = -1;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            SpawnModBiomes = new int[1] { ModContent.GetInstance<TheShroudedMire>().Type };
        }

        public override void SetBestiary(BestiaryDatabase dataNPC, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Newt")
            });
        }

        private int acidTimer;
        private bool Pale;

        public override void OnSpawn(IEntitySource source)
        {
            if (Main.rand.NextBool(200))
            {
                Pale = true;
            }
        }

        public override void AI()
        {
            Player target = Main.player[NPC.target];
            float distanceToPlayer = Vector2.Distance(target.Center, NPC.Center);
            if (target.dead || !target.active || Vector2.Distance(target.Center, NPC.Center) > 5000)
            {
                NPC.TargetClosest();
            }
            switch (AIState)
            {
                case ActionState.Walking:
                    WalkAI();
                    NPC.frameCounter += 1;
                    if (NPC.frameCounter >= 5)
                    {
                        NPC.frameCounter = 0;
                        NPC.frame.Y += 42;
                        if (NPC.frame.Y >= 6 * 42)
                        {
                            NPC.frame.Y = 0 * 42;
                        }
                    }
                    if (distanceToPlayer >= 100 & distanceToPlayer <= 400)
                    {
                        AIState = ActionState.Artillery;
                        NPC.netUpdate = true;
                    }
                    break;
                case ActionState.Artillery:
                    NPC.velocity.X = 0;
                    acidTimer++;
                    if (acidTimer >= 1)
                    {
                        if (target.Center.X > NPC.Center.X)
                        {
                            NPC.spriteDirection = 1;
                        }
                        else
                        {
                            NPC.spriteDirection = -1;
                        }
                    }
                    if (NPC.frame.Y < 7)
                    {
                        NPC.frame.Y = 7;
                    }
                    if (acidTimer == 15)
                    {
                        if (NPC.direction == -1)
                        {
                            Projectile.NewProjectile(NPC.GetSource_FromAI(), new Vector2(NPC.position.X + 70f, NPC.Center.Y), new Vector2(-3 + Main.rand.Next(-3, 0), -4 + Main.rand.Next(-4, 0)), ModContent.ProjectileType<NewtAcidProj>(), 15 / 4, 3);
                        }
                        else
                        {
                            Projectile.NewProjectile(NPC.GetSource_FromAI(), new Vector2(NPC.Center.X - 56f, NPC.Center.Y), new Vector2(3 + Main.rand.Next(0, 3), -4 + Main.rand.Next(-4, 0)), ModContent.ProjectileType<NewtAcidProj>(), 15 / 4, 3);
                        }
                    }
                    if (acidTimer <= 30)
                    {
                        NPC.frameCounter += 1;
                        if (NPC.frameCounter >= 5)
                        {
                            NPC.frameCounter = 0;
                            NPC.frame.Y += 42;
                            if (NPC.frame.Y >= 13 * 42)
                            {
                                NPC.frame.Y = 7 * 42;
                            }
                        }
                    }
                    if (acidTimer == 120)
                    {
                        acidTimer = 0;
                    }
                    if (acidTimer == 30 && distanceToPlayer <= 100 || acidTimer == 30 && distanceToPlayer >= 400)
                    {
                        AIState = ActionState.Walking;
                        acidTimer = 0;
                        NPC.netUpdate = true;
                    }
                        break;
            }
        }

        public void WalkAI()
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
            float speedUp = 0.70f;
            float maxVel = 1.80f;
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
                    Vector2 newVec = BaseAI.AttemptJump(NPC.position, NPC.velocity, NPC.width, NPC.height, NPC.direction, NPC.directionY, 3, 4, 4, true);
                    if (NPC.velocity != newVec) { NPC.velocity = newVec; NPC.netUpdate = true; }
                }
                NPC.netUpdate = true;
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                if (Pale)
                {
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/NewtGoreWhite1").Type, 1); //head
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/NewtGoreWhite2").Type, 1); //body
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/NewtGoreWhite3").Type, 1); //front legs
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/NewtGoreWhite3").Type, 1);
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/NewtGoreWhite4").Type, 1); //hind legs
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/NewtGoreWhite4").Type, 1);
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/NewtGoreWhite5").Type, 1); //tail
                }
                else
                {
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/NewtGore1").Type, 1); //head
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/NewtGore2").Type, 1); //body
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/NewtGore3").Type, 1); //front legs
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/NewtGore3").Type, 1);
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/NewtGore4").Type, 1); //hind legs
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/NewtGore4").Type, 1);
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/NewtGore5").Type, 1); //tail
                }
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MirePod>(), 3, 1, 2));
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D tex = ModContent.Request<Texture2D>(NPC.ModNPC.Texture).Value;
            Texture2D whiteTex = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "White").Value;
            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            if (Pale)
                spriteBatch.Draw(whiteTex, NPC.Center + new Vector2(0f, 0f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            else
                spriteBatch.Draw(tex, NPC.Center + new Vector2(0f, 0f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            return false;
        }
    }
}