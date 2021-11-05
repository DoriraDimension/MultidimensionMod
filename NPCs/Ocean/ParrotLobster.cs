using MultidimensionMod.Items.Banners;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Ocean
{
	public class ParrotLobster : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Parrot Lobster");
			DisplayName.AddTranslation(GameCulture.German, "Papagei Hummer");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.WalkingAntlion];
		}

		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.WalkingAntlion);
			npc.width = 80;
			npc.height = 36;
			npc.damage = 28;
			npc.defense = 5;
			npc.lifeMax = 150;
			npc.HitSound = SoundID.NPCHit46;
			npc.DeathSound = SoundID.NPCDeath48;
			npc.value = Item.buyPrice(0, 0, 1);
			npc.knockBackResist = 0.3f;
			npc.aiStyle = 3;
			aiType = NPCID.WalkingAntlion;
			animationType = NPCID.WalkingAntlion;
			banner = npc.type;
			bannerItem = ModContent.ItemType<ParrotLobsterBanner>();
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextFloat() < .3000f)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("LobsterClaw"));
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.playerSafe ? SpawnCondition.OceanMonster.Chance * 0.28f : 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Ocean/LobsterGore1"), npc.scale);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Ocean/LobsterGore2"), npc.scale);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Ocean/LobsterGore3"), npc.scale);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Ocean/LobsterGore4"), npc.scale);
			}
		}
	}
}
