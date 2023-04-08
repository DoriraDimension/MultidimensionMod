using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Biomes;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Base;
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
	public class Madman : ModNPC
	{

		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 5;
		}

		public override void SetDefaults()
		{
			NPC.width = 114;
			NPC.height = 58;
			NPC.damage = 60;
			NPC.defense = 10;
			NPC.lifeMax = 500;
			NPC.HitSound = SoundID.NPCHit54;
			NPC.DeathSound = SoundID.NPCDeath52;
			NPC.value = Item.buyPrice(0, 0, 1, 40);
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = -1;
			Banner = NPC.type;
			SpawnModBiomes = new int[1] { ModContent.GetInstance<MadnessMoon>().Type };
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
				new FlavorTextBestiaryInfoElement("A simple man who witnessed the true horror beyond, no longer able to think like a normal person.")
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
			BaseAI.AIZombie(NPC, ref NPC.ai, true, false, 0, 0.16f, 3, 5, 6, 200, true, 5, 20, false);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.Player.InModBiome(ModContent.GetInstance<MadnessMoon>()))
			{
				return 0.70f;
			}
			return base.SpawnChance(spawnInfo);
		}

		public override void ModifyNPCLoot(NPCLoot NPCloot)
		{
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<MadnessFragment>(), 3, 1, 2));
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{

			}
		}

		public override void OnHitPlayer(Player target, Player.HurtInfo info)
		{
			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Madness>(), 600);
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.rotation = NPC.velocity.X * 0.05f;
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