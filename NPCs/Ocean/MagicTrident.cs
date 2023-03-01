using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Items.Vanity;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Ocean
{
	public class MagicTrident : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Magic Trident");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.EnchantedSword];
		}

		public override void SetDefaults()
		{
			NPC.width = 80;
			NPC.height = 80;
			NPC.damage = 85;
			NPC.defense = 12;
			NPC.lifeMax = 230;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 0, 9, 20);
			NPC.knockBackResist = 0.6f;
			NPC.aiStyle = 23;
			AIType = NPCID.EnchantedSword;
			AnimationType = NPCID.EnchantedSword;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<TridentBanner>();
		}

		public override void ModifyNPCLoot(NPCLoot NPCloot)
		{
			NPCloot.Add(ItemDropRule.Common(ItemID.Nazar, 100));
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<OldSeaCrown>(), 20));
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.PlayerSafe && Main.hardMode ? SpawnCondition.Ocean.Chance * 0.18f : 0f;
		}
	}
}
