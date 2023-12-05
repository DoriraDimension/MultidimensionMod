using MultidimensionMod.Base;
using MultidimensionMod.Common.Systems;
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

namespace MultidimensionMod.NPCs.Bosses.FeudalFungus
{
    [AutoloadBossHead]
    public class FeudalFungus : ModNPC
    {
        public bool TitleCard = false;
        public int damage = 0;
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
            Hovering,
            GlowRing,
            Roots,
            SporeRain
        }

        public ActionState AIState
        {
            get => (ActionState)NPC.ai[0];
            set => NPC.ai[0] = (int)value;
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
            NPC.defense = 15;    //boss defense
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
                //Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<FungusMask>());
            }
        }

        public override void ModifyNPCLoot(NPCLoot NPCloot)
        {
            LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<GlowingMushmatter>(), 1, 5, 10));
            NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<GlowshroomSoul>()));
            //NPCloot.Add(ItemDropRule.BossBag(ModContent.ItemType<FungusBag>()));
            //NPCloot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<FungusRelic>()));
            //NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<FungusTrophy>(), 10));
            //notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<SusGlowsporeBag>(), 10));
            int choice = Main.rand.Next(2);
            if (choice == 0)
            {
                //notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<IlluminaRing>()));
            }
            if (choice == 1)
            {
                //notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<SporeSpitter>()));
            }
        }

		public float[] internalAI = new float[5];

        public int despawnTimer = 0;
        public int AISwitch = 0;
        public int FireShroom = 0;

        public override void AI()
        {
            NPC.alpha--;
            if (!TitleCard)
            {
                if (!Main.dedServ)
                {
                    MDSystem.Instance.TitleCardUIElement.DisplayTitle("The Feudal Fungus", 60, 90, 1.0f, 0, Color.Blue, "Glowing Monarch");
                    TitleCard = true;
                }
            }
            Player player = Main.player[NPC.target];

            NPC.rotation = 0;
            if (NPC.alpha <= 1)
            {
                AIState = ActionState.Hovering;
            }

            switch (AIState)
            {
                case ActionState.Hovering:
                    AISwitch++;
                    FungusHoverAI();
                    FireShroom++;
                    if (FireShroom == 120)
                    {
                        Vector2 targetCenter = player.position;
                        float ProjSpeed = 2f;
                        Vector2 velocity = targetCenter - NPC.Center;
                        velocity *= ProjSpeed;
                        Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y, velocity.X, velocity.Y, ModContent.ProjectileType<Mushshot>(), 0, 0);
                        FireShroom = 0;
                    }
                    if (AISwitch == 180)
                    {
                        int choice = Main.rand.Next(3);
                        if (choice == 0)
                        {
                            AIState = ActionState.GlowRing;
                            //Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y, 0, 0, ModContent.ProjectileType<IlluminaRing>(), 0, 0);
                            AISwitch = 0;
                        }
                        if (choice == 1)
                        {
                            AIState = ActionState.Roots;
                            AISwitch = 0;
                        }
                        if (choice == 2)
                        {
                            AIState = ActionState.SporeRain;
                            AISwitch = 0;
                        }
                    }
                    break;
                case ActionState.GlowRing:
                    AISwitch++;
                    FungusGlowRingAI(player.Center);
                    if (AISwitch == 180)
                    {
                        int choice = Main.rand.Next(3);
                        if (choice == 0)
                        {
                            AIState = ActionState.Hovering;
                            //Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y, 0, 0, ModContent.ProjectileType<IlluminaRing>(), 0, 0);
                            AISwitch = 0;
                        }
                        if (choice == 1)
                        {
                            AIState = ActionState.Roots;
                            AISwitch = 0;
                        }
                        if (choice == 2)
                        {
                            AIState = ActionState.SporeRain;
                            AISwitch = 0;
                        }
                    }
                    break;
                case ActionState.Roots:
                    AISwitch++;
                    if (AISwitch == 180)
                    {
                        int choice = Main.rand.Next(3);
                        if (choice == 0)
                        {
                            AIState = ActionState.Hovering;
                            AISwitch = 0;
                        }
                        if (choice == 1)
                        {
                            AIState = ActionState.GlowRing;
                            //Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y, 0, 0, ModContent.ProjectileType<IlluminaRing>(), 0, 0);
                            AISwitch = 0;
                        }
                        if (choice == 2)
                        {
                            AIState = ActionState.SporeRain;
                            AISwitch = 0;
                        }
                    }
                    break;
                case ActionState.SporeRain:
                    AISwitch++;
                    if (AISwitch == 180)
                    {
                        int choice = Main.rand.Next(3);
                        if (choice == 0)
                        {
                            AIState = ActionState.Hovering;
                            AISwitch = 0;
                        }
                        if (choice == 1)
                        {
                            AIState = ActionState.Roots;
                            AISwitch = 0;
                        }
                        if (choice == 2)
                        {
                            AIState = ActionState.GlowRing;
                            //Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y, 0, 0, ModContent.ProjectileType<IlluminaRing>(), 0, 0);
                            AISwitch = 0;
                        }
                    }
                    break;
            }
        }

        public void FireMagic(NPC NPC, Vector2 velocity)
        {
            Player player = Main.player[NPC.target];
            //BaseAI.ShootPeriodic(NPC, player.position, player.width, player.height, mod.ProjType("Mushshot"), ref shootAI[0], 5, damage, 8f, false, new Vector2(20f, 15f));
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.6f * balance);
            NPC.damage = (int)(NPC.damage * 0.6f);
        }

        public void FungusHoverAI()
        {
            Player target = Main.player[NPC.target];
            float speedUp = 0.04f;
            float maxVel = 4.0f;
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
            Vector2 hoverPosition = target.Center;
            hoverPosition.Y -= 20f;
            float speed = 8f;
            float inertia = 20f;
            if (NPC.Center.Y > hoverPosition.Y)
            {
                Vector2 vectorToHoverPosition = hoverPosition - NPC.Center;
                float distanceToHoverPosition = vectorToHoverPosition.Length();
                if (distanceToHoverPosition > 20f)
                {

                    vectorToHoverPosition.Normalize();
                    vectorToHoverPosition *= speed;
                    NPC.velocity = (NPC.velocity * (inertia - 1) + vectorToHoverPosition) / inertia;
                }
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
                moveSpeed *= 0.5f;
            }
            if (length < 100f)
            {
                moveSpeed *= 0.5f;
            }
            if (length < 50f)
            {
                moveSpeed *= 0.5f;
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
            return true;
        }
    }   
}


