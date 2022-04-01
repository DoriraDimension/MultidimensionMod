using MultidimensionMod.Items.Placeables.Banners;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Ocean
{
	public class StormFrontEel : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Storm Front Eel");
			DisplayName.AddTranslation(GameCulture.German, "Sturmfront Aal");
			Main.npcFrameCount[npc.type] = 5;
		}

		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.DungeonSpirit);
			npc.width = 80;
			npc.height = 80;
			npc.damage = 85;
			npc.defense = 30;
			npc.lifeMax = 2000;
			npc.HitSound = SoundID.NPCHit9;
			npc.DeathSound = SoundID.NPCDeath33;
			npc.value = Item.buyPrice(2, 50, 7);
			npc.knockBackResist = 0f;
			npc.aiStyle = 56;
			aiType = NPCID.DungeonSpirit;
			animationType = NPCID.Bird;
			banner = npc.type;
			bannerItem = ModContent.ItemType<StormEelBanner>();
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextFloat() < .5000f)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("StormHide"));
			}
			if (Main.rand.NextFloat() < .2000f)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("ThunderbubbleBow"));
			}
			if (Main.rand.NextFloat() < .2000f)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("StormScepter"));
			}
			if (Main.rand.NextFloat() < .1000f)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("EelMask"));
			}

			Item.NewItem(npc.getRect(), mod.ItemType("TidalQuartz"), Main.rand.Next(1, 4));
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.playerSafe && Main.hardMode && Main.raining && NPC.downedGolemBoss && !NPC.AnyNPCs(ModContent.NPCType<StormFrontEel>()) ? SpawnCondition.Ocean.Chance * 0.15f : 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Ocean/StormEelGore1"), npc.scale);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Ocean/StormEelGore2"), npc.scale);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Ocean/StormEelGore3"), npc.scale);
			}
		}
	}
}
