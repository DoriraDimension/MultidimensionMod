using MultidimensionMod.Base;
using MultidimensionMod.Items.Pets;
using MultidimensionMod.Items.Vanity;
using MultidimensionMod.Items.Bags;
using MultidimensionMod.Items.Weapons.Magic.Tomes;
using MultidimensionMod.Items.Weapons.Summon;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Items.Materials;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using MultidimensionMod.NPCs.Bosses.MushroomMonarch;
using System.Collections.Generic;
using Terraria.GameContent;
using MultidimensionMod.Common.Players;
using MultidimensionMod.Projectiles.Melee.Swords;
using Terraria.Audio;
using MultidimensionMod.Projectiles;

namespace MultidimensionMod.NPCs.Bosses.FeudalFungus
{
    [AutoloadBossHead]
    public class FeudalFungus : ModNPC
    {
        public bool TitleCard = false;
        public int damage = 0;
        public bool mad = false;
        public override void SendExtraAI(BinaryWriter writer)
        {
            base.SendExtraAI(writer);
            if(Main.netMode == NetmodeID.Server || Main.dedServ)
            {
                writer.Write(internalAI[0]);
				writer.Write(internalAI[1]);
                writer.Write(internalAI[2]);
                writer.Write(internalAI[3]);
                writer.Write(internalAI[4]);
            }
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			base.ReceiveExtraAI(reader);
			if(Main.netMode == NetmodeID.MultiplayerClient)
			{
                internalAI[0] = (float)reader.ReadDouble();
                internalAI[1] = (float)reader.ReadDouble();
                internalAI[2] = (float)reader.ReadDouble();
                internalAI[3] = (float)reader.ReadDouble();
                internalAI[4] = (float)reader.ReadDouble();
            }	
		}	

        public enum ActionState
        {
            TPose,
            Hovering,
            Attack,
            Radiance
        }

        public ActionState AIState
        {
            get => (ActionState)NPC.ai[0];
            set => NPC.ai[0] = (int)value;
        }

        public List<int> AttackList = new() { 0, 1, 2, 3 }; //Summon ring, summon tracking spores, summon mushroom sentries, summon root walls
        public List<int> CopyList = null;
        public int ID { get => (int)NPC.ai[3]; set => NPC.ai[3] = value; }

        void Attacks()
        {
            int attempts = 0;
            while (attempts == 0)
            {
                if (CopyList == null || CopyList.Count == 0)
                    CopyList = new List<int>(AttackList);
                ID = CopyList[Main.rand.Next(0, CopyList.Count)];
                CopyList.Remove(ID);
                NPC.netUpdate = true;

                attempts++;
            }
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Feudal Fungus");
            //Main.NPCFrameCount[NPC.type] = 8;
            NPCID.Sets.TrailCacheLength[NPC.type] = 8;
            NPCID.Sets.TrailingMode[NPC.type] = 0;
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 3000;   //boss life
            NPC.damage = 24;  //boss damage
            NPC.defense = 10;    //boss defense
            NPC.knockBackResist = 0f;
            NPC.value = Item.sellPrice(0, 1, 50, 0);
            NPC.aiStyle = -1;
            NPC.width = 74;
            NPC.height = 108;
            NPC.npcSlots = 1f;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.netAlways = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.noTileCollide = true;
            if (!Main.dedServ)
                Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Fungus");
            NPC.alpha = 255;
            NPC.dontTakeDamage = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.LesserHealingPotion;
            //DownedSystem.downedFungus = true;
            if (!Main.expertMode && Main.rand.NextBool(7))
            {
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<FungusMask>());
            }
        }

        public override void ModifyNPCLoot(NPCLoot NPCloot)
        {
            LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<GlowingMushmatter>(), 1, 5, 10));
            NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<GlowshroomSoul>()));
            NPCloot.Add(ItemDropRule.BossBag(ModContent.ItemType<FungusBag>()));
            //NPCloot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<FungusRelic>()));
            //NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<FungusTrophy>(), 10));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<SusGlowsporeBag>(), 10));
            int choice = Main.rand.Next(2);
            if (choice == 0)
            {
                notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<UmosShower>()));
            }
            if (choice == 1)
            {
                notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<RadianceTalisman>()));
            }
        }

		public float[] internalAI = new float[5];

        public override void ModifyIncomingHit(ref NPC.HitModifiers modifiers)
        {
            if (mad)
            {
                modifiers.FinalDamage *= 1.25f;
            }
            if (NPC.CountNPCS(ModContent.NPCType<GlowSentry>()) < 2) //Increases damage reduction by 20% if two Glowing Sentries are alive.
            {
                modifiers.FinalDamage *= 1.20f;
            }
            else if (NPC.CountNPCS(ModContent.NPCType<GlowSentry>()) < 1) //Increases damage reduction by 10% if a Glowing Sentry is alive.
            {
                modifiers.FinalDamage *= 1.10f;
            }
            return;
        }

        //Did you know that I really love using named timers? No? Well now you do!
        public int despawnTimer = 0;
        public int AISwitch = 0;
        public int MakeItRain = 0;
        public int FireShroom = 0;
        public int RingTime = 0;
        public int DoubleTimer = 0;
        public int DoubleFire = 0;
        public int SentryTimer = 0;
        public int ImFalling = 0;
        public int IHaveLanded = 0;
        public int Waking = 0; //Using NPC.alpha in an if statement didn't work, so another named timer I guess.
        public int ScreamTimer = 0;
        public int DesperateScreamTimer = 0;

        public override void AI()
        {
            if (NPC.CountNPCS(ModContent.NPCType<GlowSentry>()) < 2) //Increases damage reduction by 20% if two Glowing Sentries are alive.
            {
                NPC.defense = 20;
            }
            else if (NPC.CountNPCS(ModContent.NPCType<GlowSentry>()) < 1) //Increases damage reduction by 10% if a Glowing Sentry is alive.
            {
                NPC.defense = 15;
            }
            else
                NPC.defense = 10;
            if (!Main.player[NPC.target].ZoneGlowshroom) //Becomes very angry outside of the Glowing Mushroom biome
            {
                mad = true;
            }
            else
            {
                mad = false;
            }
            NPC.alpha -= 5;
            Waking++;
            if (!TitleCard)
            {
                if (!Main.dedServ)
                {
                    MDSystem.Instance.TitleCardUIElement.DisplayTitle("The Feudal Fungus", 60, 90, 1.0f, 0, Color.Blue, "Glowing Monarch");
                    TitleCard = true;
                }
            }
            Player player = Main.player[NPC.target];

            NPC.TargetClosest();

            if (player.dead || !player.active || Vector2.Distance(player.Center, NPC.Center) > 5000)
            {
                NPC.TargetClosest();

            }
            if (Waking == 180) //Initiate AI
            {
                AIState = ActionState.Hovering;
                NPC.dontTakeDamage = false;
            }
            if (NPC.life >= NPC.lifeMax / 5)
            {
                Lighting.AddLight(NPC.Center, 0, 0, (255 - NPC.alpha) * 0.30f / 255f);
            }
            if (NPC.life <= NPC.lifeMax / 5)
            {
                AIState = ActionState.Radiance;
                ScreamTimer++;
                if (NPC.life >= NPC.lifeMax / 10)
                    Lighting.AddLight(NPC.Center, 0, (255 - NPC.alpha) * 0.25f / 160, (255 - NPC.alpha) * 0.35f / 255f);
                if (ScreamTimer == 1)
                {
                    SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/RoyalRadianceScream"), NPC.position);
                }
                if (ScreamTimer >= 2)
                {
                    ScreamTimer = 2;
                }
            }
            switch (AIState)
            {
                case ActionState.TPose:
                    NPC.Center = player.Center + new Vector2(0, -200);
                    break;
                case ActionState.Hovering:
                    AISwitch++;
                    FungusHoverAI(new Vector2(player.Center.X, player.Center.Y - 200), 0.3f);
                    FireShroom++;
                    MakeItRain++;
                    if (FireShroom == 90) //Shoot projectile at the player
                    {
                        Vector2 targetCenter = player.position;
                        float ProjSpeed = 8f;
                        Vector2 velocity = targetCenter - NPC.Center;
                        velocity.Normalize();
                        velocity *= ProjSpeed;
                        Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y - 10, velocity.X, velocity.Y, ModContent.ProjectileType<Mushshot>(), 10, 0);
                        FireShroom = 0;
                    }
                    if (MakeItRain == 40) //Shoot spread upwards
                    {
                        int amount = 10; //Amnount of projectiles
                        if (Main.expertMode)
                        {
                            amount = 12; //Fires 2 additional ones in expert mode
                        }
                        for (int i = 0; i < amount; i++)
                        {
                            Vector2 perturbedSpeed = new Vector2(NPC.velocity.X / 2, -20).RotatedByRandom(MathHelper.ToRadians(85));
                            Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y - 10, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<Mushshot2>(), 8, 0);
                            SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/Blurb"), NPC.position);
                        }
                        MakeItRain = 0;
                    }
                    if (AISwitch == 180) //Switch to different attack & reset all timers
                    {
                        AISwitch = 0;
                        FireShroom = 0;
                        MakeItRain = 0;
                        Attacks();
                        AIState = ActionState.Attack;

                    }
                    break;
                case ActionState.Attack:
                    switch (ID)
                    {
                        case 0: //Illumina Ring (spawns a ring projectile on the NPC and makes it move towards the player
                            FungusGlowRingAI(player.Center);
                            RingTime++;
                            if (RingTime == 1)
                            {
                                int color = Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y, 0, 0, ModContent.ProjectileType<IlluminaRing>(), 32, 0);
                                (Main.projectile[color].ModProjectile as Aura).color = Color.Blue;
                                SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/HallowedCry"), NPC.position);
                            }
                            if (RingTime == 180)
                            {
                                AIState = ActionState.Hovering;
                                RingTime = 0;
                                NPC.netUpdate = true;
                            }
                            break;
                        case 1: //Double fire (Starts firing projectiles from both of its arms)
                            FungusHoverAI(new Vector2(Main.rand.NextBool(4) ? player.Center.X - 150 : player.Center.X + 150, player.Center.Y - 200), 0.2f);
                            DoubleTimer++;
                            DoubleFire++;
                            if (DoubleFire == 90)
                            {
                                Vector2 sped = new Vector2(0, -8);
                                Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X + 100, NPC.Center.Y - 10, sped.X, sped.Y, ModContent.ProjectileType<StalkingShot>(), 15, 0);
                                Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X - 100, NPC.Center.Y - 10, sped.X, sped.Y, ModContent.ProjectileType<StalkingShot>(), 15, 0);
                                SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/Blurb"), NPC.position);
                                DoubleFire = 60;
                            }
                            if (DoubleTimer == 240)
                            {
                                AIState = ActionState.Hovering;
                                DoubleTimer = 0;
                                DoubleFire = 0;
                                NPC.netUpdate = true;
                            }
                            break;
                        case 2: //Sentries (Summons a glowing sentry that empowers the boss, only two can be alive at once and the boost stacks.
                            if (NPC.CountNPCS(ModContent.NPCType<GlowSentry>()) < 2)
                            {
                                SentryTimer++;
                                FungusHoverAI(new Vector2(player.Center.X, player.Center.Y - 200), 0.3f);
                                if (SentryTimer == 60)
                                {
                                    int Sentry = NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, BaseWorldGen.GetFirstTileFloor((int)NPC.Center.X / 16, (int)NPC.Center.Y / 16) * 16, ModContent.NPCType<GlowSentry>(), 0);
                                    Main.npc[Sentry].netUpdate = true;
                                }
                                if (SentryTimer == 120)
                                {
                                    AIState = ActionState.Hovering;
                                    SentryTimer = 0;
                                    NPC.netUpdate = true;
                                }
                            }
                            else
                            {
                                AIState = ActionState.Hovering;
                                NPC.netUpdate = true;
                            }
                            break;
                        case 3:
                            ImFalling++;
                            NPC.velocity.X = 0;
                            if (ImFalling == 120)
                            {
                                NPC.velocity.Y = 20;
                            }
                            if ((player.Center.Y - NPC.Center.Y) <= 30)
                            {
                                NPC.noTileCollide = false;
                            }
                            if (BaseAI.HitTileOnSide(NPC, 3))
                            {
                                IHaveLanded++;
                                if (IHaveLanded == 1)
                                {
                                    int wall = NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X + 400, BaseWorldGen.GetFirstTileFloor((int)NPC.Center.X / 16, (int)NPC.Center.Y / 16) * 16, ModContent.NPCType<EvokedMushroot>(), 0);
                                    Main.npc[wall].netUpdate = true;
                                    int wall2 = NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X - 400, BaseWorldGen.GetFirstTileFloor((int)NPC.Center.X / 16, (int)NPC.Center.Y / 16) * 16, ModContent.NPCType<EvokedMushroot>(), 0);
                                    Main.npc[wall2].netUpdate = true;
                                    SoundEngine.PlaySound(SoundID.Item14, NPC.position);
                                }
                            }
                            if (IHaveLanded == 120)
                            {
                                NPC.noTileCollide = true;
                                AIState = ActionState.Hovering;
                                ImFalling = 0;
                                IHaveLanded = 0;
                            }
                            break;
                    }
                    break;
                case ActionState.Radiance:
                    NPC.Center = player.Center + new Vector2(0, -200);
                    MakeItRain++;
                    if (Main.expertMode)
                    {
                        if (NPC.life <= NPC.lifeMax / 10)
                        {
                            Lighting.AddLight(NPC.Center, 0, (255 - NPC.alpha) * 0.40f / 255, (255 - NPC.alpha) * 0.10f / 130f);
                            DesperateScreamTimer++;
                            if (DesperateScreamTimer == 1)
                            {
                                SoundEngine.PlaySound(Sounds.CustomSounds.RoyalRadianceScream with { Pitch = 1.05f }, NPC.position);
                            }
                            if (DesperateScreamTimer >= 2)
                            {
                                DesperateScreamTimer = 2;
                            }
                        }
                    }
                    if (MakeItRain == 40) //Shoot spread upwards
                    {
                        int amount = 12; //Amnount of projectiles
                        if (Main.expertMode)
                        {
                            amount = 14; //Fires 2 additional ones in expert mode
                        }
                        for (int i = 0; i < amount; i++)
                        {
                            Vector2 targetCenter = player.position;
                            float ProjSpeed = 12f;
                            Vector2 velocity = targetCenter - NPC.Center;
                            velocity.Normalize();
                            velocity *= ProjSpeed;
                            Vector2 perturbedSpeed = new Vector2(NPC.velocity.X / 2, -20).RotatedByRandom(MathHelper.ToRadians(85));
                            if (NPC.life <= NPC.lifeMax / 10)
                            {
                                if (Main.expertMode)
                                {
                                    Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y - 10, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<PureRadianceShot>(), 30, 0);
                                }
                            }
                            else
                                Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y - 10, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<RadianceShot>(), 20, 0);
                            SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/RadianceShot"), NPC.position);
                        }
                        MakeItRain = 0;
                    }
                    break;
            }
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.6f * balance);
            NPC.damage = (int)(NPC.damage * 0.6f);
        }

        public void FungusHoverAI(Vector2 targetPos, float speedModifier)
        {
            Player target = Main.player[NPC.target];
            float speedUp = 0.12f;
            float maxVel = 10.0f;
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
            }
            if (NPC.Center.Y < targetPos.Y)
            {
                NPC.velocity.Y += speedModifier;
                if (NPC.velocity.Y < 0)
                    NPC.velocity.Y += speedModifier * 2;
            }
            else
            {
                NPC.velocity.Y -= speedModifier;
                if (NPC.velocity.Y > 0)
                NPC.velocity.Y -= speedModifier * 2;
            }
        }

        public void FungusGlowRingAI(Vector2 point)
        {
            float moveSpeed = 4f;
            if (moveSpeed == 0f || NPC.Center == point) return; //don't move if you have no move speed
            float velMultiplier = 1f;
            Vector2 dist = point - NPC.Center;
            float length = dist == Vector2.Zero ? 0f : dist.Length();
            if (length < moveSpeed)
            {
                velMultiplier = MathHelper.Lerp(0f, 1f, length / moveSpeed);
            }
            if (length < 200f)
            {
                moveSpeed *= 0.4f;
            }
            if (length < 100f)
            {
                moveSpeed *= 0.3f;
            }
            if (length < 50f)
            {
                moveSpeed *= 0.3f;
            }
            NPC.velocity = length == 0f ? Vector2.Zero : Vector2.Normalize(dist);
            NPC.velocity *= moveSpeed;
            NPC.velocity *= velMultiplier;
        }

        public void FungusRootAI()
        {

        }

        public void FungusRainAI()
        {

        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos,  Color drawColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_Glow").Value;
            Texture2D texture2 = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_Radiant").Value;
            Texture2D texture3 = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_PureRadiant").Value;
            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, NPC.Center + new Vector2(0f, -14f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            if (NPC.life <= NPC.lifeMax / 10 && Main.expertMode)
            {
                spriteBatch.Draw(texture3, NPC.Center + new Vector2(0f, -14f) - screenPos, NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            }
            else if (NPC.life <= NPC.lifeMax / 5)
            {
                spriteBatch.Draw(texture2, NPC.Center + new Vector2(0f, -14f) - screenPos, NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            }
            else
                spriteBatch.Draw(texture, NPC.Center + new Vector2(0f, -14f) - screenPos, NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);

            return false;
        }
    }   
}


