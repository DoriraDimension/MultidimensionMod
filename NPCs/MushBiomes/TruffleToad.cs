using MultidimensionMod.Items.Accessories;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using MultidimensionMod.Base;
using MultidimensionMod.NPCs.Bosses.FeudalFungus;
using Terraria.GameContent.Bestiary;
using MultidimensionMod.NPCs.Bosses.MushroomMonarch;
using MultidimensionMod.Items.Placeables.Banners;

namespace MultidimensionMod.NPCs.MushBiomes
{
    public class TruffleToad : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Truffle Toad");
            Main.npcFrameCount[NPC.type] = 16;
        }

        public enum ActionState
        {
            Peaceful,
            Idle,
            Hopping,
            OhDamnYesterdaysDinnerWasNotWellReceivedByMyTummy
        }

        public ActionState AIState
        {
            get => (ActionState)NPC.ai[0];
            set => NPC.ai[0] = (int)value;
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 400;
            NPC.damage = 20;
            NPC.defense = 6;
            NPC.knockBackResist = 0f;
            NPC.value = Item.sellPrice(0, 0, 40, 0);
            NPC.aiStyle = -1;
            NPC.width = 88;
            NPC.height = 68;
            //music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/TODE");
            NPC.netAlways = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.rarity = 2;
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<ToadBanner>();
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundMushroom,
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Toad")
            });
        }

        public override void ModifyNPCLoot(NPCLoot NPCloot)
        {
            NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<ToadLeg>(), 5));
        }

        public int IThinkImStupid = 0;
        public int MotivationToMove = 0;
        public int Stamina = 0;
        public int Charge = 0;
        public bool aggro = false;

        public override void AI()
        {
            if (NPC.life < NPC.lifeMax)
            {
                aggro = true;
            }
            if (aggro)
            {
                IThinkImStupid++;
                if (IThinkImStupid == 1)
                {
                    AIState = ActionState.Idle;
                    NPC.netUpdate = true;
                }
                if (IThinkImStupid >= 2)
                {
                    IThinkImStupid = 2;
                }
            }
            if (Main.rand.NextBool(700))
            {
                SoundEngine.PlaySound(SoundID.Zombie13 with { Pitch = -0.40f }, NPC.position);
            }
            NPC.TargetClosest();
            Player player = Main.player[NPC.target];
            if (player.dead || !player.active || !player.ZoneGlowshroom)
            {
                NPC.TargetClosest();
            }
            if (player.Center.X < NPC.Center.X) //Look at the player, they are over there, they are an easy meal, take the chance.
            {
                NPC.spriteDirection = -1;
            }
            else
            {
                NPC.spriteDirection = 1;
            }
            if (!BaseAI.HitTileOnSide(NPC, 3))
            {
                NPC.spriteDirection = NPC.direction;
                NPC.netUpdate = true;
            }

            switch (AIState)
            {
                case ActionState.Peaceful:
                    NPC.frameCounter++;
                    int FrameSpeed = 6;
                    if (NPC.frameCounter >= FrameSpeed)
                    {
                        NPC.frame.Y += 86;
                        NPC.frameCounter = 0;
                        if (NPC.frame.Y > (86 * 5))
                        {
                            NPC.frameCounter = 0;
                            NPC.frame.Y = 86 * 0;
                        }
                    }
                    break;
                case ActionState.Idle:
                    MotivationToMove++;
                    NPC.velocity.X = 0;
                    NPC.frameCounter++;
                    int FrameSpeeder = 6;
                    if (NPC.frameCounter >= FrameSpeeder)
                    {
                        NPC.frame.Y += 86;
                        NPC.frameCounter = 0;
                        if (NPC.frame.Y > (86 * 5))
                        {
                            NPC.frameCounter = 0;
                            NPC.frame.Y = 86 * 0;
                        }
                    }
                    if (MotivationToMove == 120)
                    {
                        AIState = ActionState.Hopping;
                        MotivationToMove = 0;
                        NPC.netUpdate = true;
                    }
                    break;
                case ActionState.Hopping:
                    ToadHopAI();
                    if (!BaseAI.HitTileOnSide(NPC, 3))
                    {
                        NPC.frame.Y = 602;
                        NPC.netUpdate = true;
                    }
                    else NPC.frame.Y = 0;
                    Stamina++;
                    if (Stamina == 240)
                    {
                        AIState = ActionState.OhDamnYesterdaysDinnerWasNotWellReceivedByMyTummy;
                        Stamina = 0;
                        NPC.netUpdate = true;
                    }
                    break;
                case ActionState.OhDamnYesterdaysDinnerWasNotWellReceivedByMyTummy:
                    NPC.velocity.X = 0;
                    NPC.frameCounter++;
                    Charge++;
                    FrameSpeed = 10;
                    if (Charge <= 120)
                    {

                        if (NPC.frameCounter >= FrameSpeed)
                        {
                            NPC.frame.Y += 86;
                            NPC.frameCounter = 0;
                            if (NPC.frame.Y > (86 * 10))
                            {
                                NPC.frameCounter = 0;
                                NPC.frame.Y = 86 * 10;
                            }
                        }
                    }
                    else
                    {
                        if (Charge == 125) 
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                Vector2 ba = new Vector2(1, 1).RotatedByRandom(MathHelper.ToRadians(55));
                                Vector2 targetCenter = player.position;
                                float ProjSpeed = 6f;
                                Vector2 velocity = targetCenter - NPC.Center;
                                velocity.Normalize();
                                velocity *= ProjSpeed * ba;
                                if (Main.netMode != NetmodeID.MultiplayerClient)
                                    Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y, velocity.X, velocity.Y, ModContent.ProjectileType<FungusBubble>(), 25, 0);
                                SoundEngine.PlaySound(SoundID.Item85, NPC.position);
                                NPC.netUpdate = true;
                            }
                        }
                        FrameSpeed = 6;
                        if (NPC.frameCounter >= FrameSpeed)
                        {
                            NPC.frame.Y += 86;
                            NPC.frameCounter = 0;
                            if (NPC.frame.Y > (86 * 15))
                            {
                                NPC.frame.Y = 0;
                                AIState = ActionState.Idle;
                                Charge = 0;
                                NPC.netUpdate = true;
                            }
                        }
                    }
                    break;
            }
        }

        public int ASmallRest = 0;
        private void ToadHopAI()
        {
            int x = 0;
            if (BaseAI.HitTileOnSide(NPC, 3))
            {
                ASmallRest++;
                NPC.velocity.X = x;
            }
            Player target = Main.player[NPC.target];
            if (ASmallRest == 30)
            {
                x = 6;
                NPC.netUpdate = true;
                ASmallRest = 0;
                if (BaseAI.HitTileOnSide(NPC, 3))
                {
                    if (target.Center.X < NPC.Center.X)
                        x *= -1;
                    NPC.velocity.X += x;
                    NPC.velocity.Y = -3f;
                }
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.tile[spawnInfo.SpawnTileX, spawnInfo.SpawnTileY].TileType == TileID.MushroomGrass && spawnInfo.Player.ZoneGlowshroom ? 0.03f : 0f;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/ToadGore1").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/ToadGore2").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/ToadGore3").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/ToadGore4").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/ToadGore5").Type, 1);
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D frog = ModContent.Request<Texture2D>(NPC.ModNPC.Texture).Value;
            Texture2D glow = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_Glow").Value;
            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(frog, NPC.Center + new Vector2(0f, -5f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            spriteBatch.Draw(glow, NPC.Center + new Vector2(0f, -5f) - screenPos, NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            return false;
        }
    }
}


