using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Items.Vanity;
using MultidimensionMod.Items.Weapons.Ranged.Bows;
using MultidimensionMod.Items.Weapons.Magic.Staffs;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;

namespace MultidimensionMod.NPCs.Ocean
{
	public class StormFrontEel : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 5;
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.DungeonSpirit);
			NPC.width = 80;
			NPC.height = 80;
			NPC.damage = 85;
			NPC.defense = 35;
			NPC.lifeMax = 2000;
			NPC.HitSound = SoundID.NPCHit9;
			NPC.DeathSound = SoundID.NPCDeath33;
			NPC.value = Item.buyPrice(0, 2, 50, 7);
			NPC.knockBackResist = 0f;
			NPC.aiStyle = 56;
			AIType = NPCID.DungeonSpirit;
			AnimationType = NPCID.Bird;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<StormEelBanner>();
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Events.Rain,
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.StormEel")
			});
		}

		public override void ModifyNPCLoot(NPCLoot NPCloot)
		{
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<StormHide>(), 2));
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<ThunderbubbleBow>(), 4));
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<StormScepter>(), 4));
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<EelMask>(), 10));
			if (NPC.downedFishron)
			{
				NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<TidalQuartz>(), 1, 1, 3));
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.PlayerSafe && Main.hardMode && Main.raining && NPC.downedGolemBoss && !NPC.AnyNPCs(ModContent.NPCType<StormFrontEel>()) ? SpawnCondition.Ocean.Chance * 0.15f : 0f;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/StormEelGore1").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/StormEelGore2").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/StormEelGore3").Type, 1);
			}
		}
	}
}
