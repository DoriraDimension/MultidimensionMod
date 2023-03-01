using MultidimensionMod.Items.Placeables.Banners;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;

namespace MultidimensionMod.NPCs.Desert
{
	public class GilaMonster : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Gilania");
			Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.Crab);
			NPC.width = 70;
			NPC.height = 26;
			NPC.damage = 26;
			NPC.defense = 20;
			NPC.lifeMax = 210;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 6, 25);
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = 3;
			AIType = NPCID.Crab;
			AnimationType = NPCID.Squirrel;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<GilaBanner>();
		}

		public override void ModifyNPCLoot(NPCLoot NPCloot)
		{
			NPCloot.Add(ItemDropRule.Common(ItemID.VialofVenom, 2));
		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
		     player.AddBuff(BuffID.Venom, 240);

		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.Player.ZoneDesert && Main.hardMode && Main.dayTime && spawnInfo.SpawnTileY <= Main.maxTilesY - 200 && spawnInfo.SpawnTileY > Main.rockLayer)
			{
				return 0.15f;
			}
			else if (spawnInfo.Player.ZoneDesert && Main.hardMode && !Main.dayTime && !spawnInfo.Player.ZoneSandstorm)
			{
				return 0.15f;
			}
			return 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (NPC.life <= 0)
			{
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/GilaGore1").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/GilaGore2").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/GilaGore3").Type, 1);
			}
		}
	}
}
