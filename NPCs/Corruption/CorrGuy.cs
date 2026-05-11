using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using MultidimensionMod.Items.Vanity;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using MultidimensionMod.Base;
using System;
using MultidimensionMod.NPCs.Bosses.MushroomMonarch;
using Terraria.Audio;

namespace MultidimensionMod.NPCs.Corruption
{
	public class CorrGuy : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 8;
		}

        public enum ActionState
        {
            Walk,
			Spit
        }

        public ActionState AIState
        {
            get => (ActionState)NPC.ai[0];
            set => NPC.ai[0] = (int)value;
        }

        public override void SetDefaults()
		{
			NPC.width = 32;
			NPC.height = 50;
			NPC.damage = 23;
			NPC.defense = 12;
			NPC.lifeMax = 50;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = Item.buyPrice(0, 0, 1, 50);
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = -1;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<InfestedBanner>();
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption,
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Abomination")
			});
		}

		public int AITimer = 0;

		public override void AI()
		{
            Player target = Main.player[NPC.target];
            if (target.dead || !target.active || Vector2.Distance(target.Center, NPC.Center) > 5000)
            {
                NPC.TargetClosest();
            }
            if (target.Center.X > NPC.Center.X)
            {
                NPC.spriteDirection = -1;
            }
            else
            {
                NPC.spriteDirection = 1;
            }
            switch (AIState)
			{
				case ActionState.Walk:
					AITimer++;
					NPC.frameCounter++;
                    if (NPC.frameCounter >= 6)
                    {
                        NPC.frameCounter = 0;
                        NPC.frame.Y += 72;
                        if (NPC.frame.Y > (72 * 7))
                        {
                            NPC.frameCounter = 0;
                            NPC.frame.Y = 0;
                        }
                    }
                    float speedUp = 0.06f;
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
                            Vector2 newVec = BaseAI.AttemptJump(NPC.position, NPC.velocity, NPC.width, NPC.height, NPC.direction, NPC.directionY, 3, 5, 4, true);
                            if (NPC.velocity != newVec) { NPC.velocity = newVec; NPC.netUpdate = true; }
                        }
                        NPC.netUpdate = true;
                    }
					if (AITimer == 180)
					{
						AIState = ActionState.Spit;
						AITimer = 0;
					}
                    break;
				case ActionState.Spit:
					AITimer++;
                    NPC.velocity.X = 0;
                    NPC.frame.Y = 72 * 3;
                    if (AITimer == 10)
					{
                        NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<DecayFly>());
                        SoundEngine.PlaySound(SoundID.NPCDeath13 with { Volume = 0.5f }, NPC.position);
                    }
					else if (AITimer == 20)
					{
						AIState = ActionState.Walk;
                        AITimer = 0;
                    }
					break;
			}
        }

		public override void ModifyNPCLoot(NPCLoot NPCloot)
		{
			NPCloot.Add(ItemDropRule.Common(ItemID.RottenChunk, 2));
		    NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<TheFly>(), 25));
		    NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<CorrGuyMask>(), 30));
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.Corruption.Chance * 0.4f;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/InfestedGore1").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/InfestedGore2").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/InfestedGore3").Type, 1);
			}
			if (Main.netMode != NetmodeID.MultiplayerClient && NPC.life <= 0)
			{
				Vector2 spawnAt = NPC.Center + new Vector2(0f, (float)NPC.height / 2f);
				NPC.NewNPC(NPC.GetSource_FromAI(), (int)spawnAt.X, (int)spawnAt.Y, ModContent.NPCType<DecayFly>());
			}

			if (Main.netMode != NetmodeID.MultiplayerClient && NPC.life <= 0)
			{
				Vector2 spawnAt = NPC.Center + new Vector2(0f, (float)NPC.height / 5f);
				NPC.NewNPC(NPC.GetSource_FromAI(), (int)spawnAt.X, (int)spawnAt.Y, ModContent.NPCType<DecayFly>());
			}

			if (Main.netMode != NetmodeID.MultiplayerClient && NPC.life <= 0)
			{
				Vector2 spawnAt = NPC.Center + new Vector2(0f, (float)NPC.height / 11f);
				NPC.NewNPC(NPC.GetSource_FromAI(), (int)spawnAt.X, (int)spawnAt.Y, ModContent.NPCType<DecayFly>());
			}
		}
	}
}
