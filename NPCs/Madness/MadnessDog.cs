using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Biomes;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Base;
using MultidimensionMod.Items;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Bestiary;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria.Audio;

namespace MultidimensionMod.NPCs.Madness
{
	public class MadnessDog : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 7;
		}

		public override void SetDefaults()
		{
			NPC.width = 114;
			NPC.height = 58;
			NPC.damage = 40;
			NPC.defense = 0;
			NPC.lifeMax = 100;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath5;
			NPC.value = Item.buyPrice(0, 0, 1, 40);
			NPC.knockBackResist = 0.0f;
			NPC.lavaImmune = false;
			NPC.noGravity = false;
			NPC.noTileCollide = false;
			NPC.aiStyle = -1;
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<MadnessDogBanner>();
            SpawnModBiomes = new int[1] { ModContent.GetInstance<MadnessMoon>().Type };
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
				new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.MadnessStarving")
			});
		}

		public override void AI()
		{
			if (NPC.velocity.X > 0)
			{
				NPC.spriteDirection = 1;
				NPC.direction = 1;
			}
			else if (NPC.velocity.X < 0)
			{
				NPC.spriteDirection = -1;
				NPC.direction = -1;
			}
			BaseAI.AICharger(NPC, ref NPC.ai, 0.14f, 6, false, 300);
			if (BaseAI.HitTileOnSide(NPC, 3))
			{
				if (NPC.velocity.X < 0f && NPC.direction == -1 || NPC.velocity.X > 0f && NPC.direction == 1)
				{
					Vector2 newVec = BaseAI.AttemptJump(NPC.position, NPC.velocity, NPC.width, NPC.height, NPC.direction, NPC.directionY, 10, 4, 7, true);
					if (NPC.velocity != newVec) { NPC.velocity = newVec; NPC.netUpdate = true; }
				}
			}
        }

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.Player.InModBiome(ModContent.GetInstance<MadnessMoon>()))
			{
				return 0.60f;
			}
			return base.SpawnChance(spawnInfo);
		}

		public override void ModifyNPCLoot(NPCLoot NPCloot)
		{
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<MadnessFragment>(), 3, 1, 3));
            NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<ShadeEye>(), 100));
        }

		public override void OnHitPlayer(Player target, Player.HurtInfo info)
		{
			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Madness>(), 240);
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/MadnessDogGore1").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/MadnessDogGore2").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/MadnessDogGore3").Type, 1);
            }
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter += 1.0;
			if (NPC.frameCounter >= 7.0)
			{
				NPC.frameCounter = 0.0;
				NPC.frame.Y += frameHeight;
				if (NPC.frame.Y >= Main.npcFrameCount[NPC.type] * frameHeight)
				{
					NPC.frame.Y = 0;
				}
			}
		}
	}
}