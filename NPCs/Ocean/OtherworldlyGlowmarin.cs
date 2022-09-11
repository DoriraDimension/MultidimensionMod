using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Items.Hooks;
using MultidimensionMod.Items.Weapons.Melee.Others;
using MultidimensionMod.Items.Placeables;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Ocean
{
	public class OtherworldlyGlowmarin : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Otherworldly Glowmarin");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Shark];
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.Shark);
			NPC.width = 134;
			NPC.height = 38;
			NPC.damage = 120;
			NPC.defense = 30;
			NPC.lifeMax = 350;
			NPC.HitSound = SoundID.NPCHit51;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 0, 11);
			NPC.knockBackResist = 0.3f;
			NPC.aiStyle = 16;
			AIType = NPCID.Shark;
			AnimationType = NPCID.Shark;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<GlowmarinBanner>();
		}

		public override void ModifyNPCLoot(NPCLoot NPCloot)
		{
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<GlowingKelpHook>(), 7));
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<OceanicGlowshard>(), 7));
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<Glowseed>(), 5));
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.PlayerSafe && Main.hardMode && NPC.downedMechBossAny ? SpawnCondition.OceanMonster.Chance * 0.18f : 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (NPC.life <= 0)
			{
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/GlowmarinGore1").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/GlowmarinGore2").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/GlowmarinGore3").Type, 1);
			}
		}
	}
}
