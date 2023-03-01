using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using MultidimensionMod.Items.Vanity;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Corruption
{
	public class CorrGuy : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Infested Abomination");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Crab];
		}

		public override void SetDefaults()
		{
			NPC.width = 44;
			NPC.height = 46;
			NPC.damage = 23;
			NPC.defense = 12;
			NPC.lifeMax = 100;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = Item.buyPrice(0, 0, 1, 50);
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = 3;
			AIType = NPCID.DesertGhoul;
			AnimationType = NPCID.Crab;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<InfestedBanner>();
		}

		public override void ModifyNPCLoot(NPCLoot NPCloot)
		{
			NPCloot.Add(ItemDropRule.Common(ItemID.RottenChunk, 2));
		    NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<TheFly>(), 30));
		    NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<CorrGuyMask>(), 30));

		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.Corruption.Chance * 0.5f;
		}

		public override void HitEffect(int hitDirection, double damage)
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
