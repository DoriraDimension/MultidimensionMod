using MultidimensionMod.Items.Banners;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Corruption
{
	public class CorrGuy : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infested Abomination");
			DisplayName.AddTranslation(GameCulture.German, "Befallene Abscheuligkeit");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Crab];
		}

		public override void SetDefaults()
		{
			npc.width = 18;
			npc.height = 40;
			npc.damage = 23;
			npc.defense = 12;
			npc.lifeMax = 100;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = NPCID.DesertGhoul;
			animationType = NPCID.Crab;
			banner = npc.type;
			bannerItem = ModContent.ItemType<InfestedBanner>();
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextFloat() < .5000f)
			{
				Item.NewItem(npc.getRect(), ItemID.RottenChunk);
			}
			if (Main.rand.NextFloat() < .0300f)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("TheFly"));
			}

		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.Corruption.Chance * 0.5f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Corruption/InfestedGore1"), npc.scale);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Corruption/InfestedGore2"), npc.scale);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Corruption/InfestedGore3"), npc.scale);
			}
			if (Main.netMode != NetmodeID.MultiplayerClient && npc.life <= 0)
			{
				Vector2 spawnAt = npc.Center + new Vector2(0f, (float)npc.height / 2f);
				NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, ModContent.NPCType<DecayFly>());
			}

			if (Main.netMode != NetmodeID.MultiplayerClient && npc.life <= 0)
			{
				Vector2 spawnAt = npc.Center + new Vector2(0f, (float)npc.height / 5f);
				NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, ModContent.NPCType<DecayFly>());
			}

			if (Main.netMode != NetmodeID.MultiplayerClient && npc.life <= 0)
			{
				Vector2 spawnAt = npc.Center + new Vector2(0f, (float)npc.height / 11f);
				NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, ModContent.NPCType<DecayFly>());
			}
		}
	}
}
