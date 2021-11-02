using MultidimensionMod.Items.Banners;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Ocean
{
	public class MagicTrident : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magic Trident");
			DisplayName.AddTranslation(GameCulture.German, "Magischer Dreizack");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.EnchantedSword];
		}

		public override void SetDefaults()
		{
			npc.width = 80;
			npc.height = 80;
			npc.damage = 85;
			npc.defense = 12;
			npc.lifeMax = 230;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = 60f;
			npc.knockBackResist = 0.6f;
			npc.aiStyle = 23;
			aiType = NPCID.EnchantedSword;
			animationType = NPCID.EnchantedSword;
			banner = npc.type;
			bannerItem = ModContent.ItemType<TridentBanner>();
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextFloat() < .0100f)
			{
				Item.NewItem(npc.getRect(), ItemID.Nazar);
			}

			if (Main.rand.NextFloat() < .0400f)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("OldSeaCrown"));
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.playerSafe && Main.hardMode ? SpawnCondition.Ocean.Chance * 0.18f : 0f;
		}
	}
}
