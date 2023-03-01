using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Ocean
{
	public class ParrotLobster : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Parrot Lobster");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.WalkingAntlion];
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.WalkingAntlion);
			NPC.width = 80;
			NPC.height = 36;
			NPC.damage = 21;
			NPC.defense = 5;
			NPC.lifeMax = 100;
			NPC.HitSound = SoundID.NPCHit46;
			NPC.DeathSound = SoundID.NPCDeath48;
			NPC.value = Item.buyPrice(0, 0, 0, 78);
			NPC.knockBackResist = 0.3f;
			NPC.aiStyle = 3;
			AIType = NPCID.WalkingAntlion;
			AnimationType = NPCID.WalkingAntlion;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<ParrotLobsterBanner>();
		}

		public override void ModifyNPCLoot(NPCLoot NPCloot)
		{
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<LobsterClaw>(), 10));
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.PlayerSafe ? SpawnCondition.OceanMonster.Chance * 0.28f : 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (NPC.life <= 0)
			{
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/LobsterGore1").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/LobsterGore2").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/LobsterGore3").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/LobsterGore4").Type, 1);
			}
		}
	}
}
