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
	public class OtherworldlyGlowmarin : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Otherworldly Glowmarin");
			DisplayName.AddTranslation(GameCulture.German, "Jenseitiger Leuchtmarin");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Shark];
		}

		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.Shark);
			npc.width = 134;
			npc.height = 38;
			npc.damage = 120;
			npc.defense = 30;
			npc.lifeMax = 350;
			npc.HitSound = SoundID.NPCHit51;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 11);
			npc.knockBackResist = 0.3f;
			npc.aiStyle = 16;
			aiType = NPCID.Shark;
			animationType = NPCID.Shark;
			banner = npc.type;
			bannerItem = ModContent.ItemType<GlowmarinBanner>();
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextFloat() < .1500f)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("GlowingKelpHook"));
			}

			if (Main.rand.NextFloat() < .1500f)
            {
				Item.NewItem(npc.getRect(), mod.ItemType("OceanicGlowshard"));
			}

			if (Main.rand.NextFloat() < .3500f)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("Glowseed"));
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.playerSafe && Main.hardMode && NPC.downedMechBossAny ? SpawnCondition.OceanMonster.Chance * 0.21f : 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Ocean/GlowmarinGore1"), npc.scale);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Ocean/GlowmarinGore2"), npc.scale);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Ocean/GlowmarinGore3"), npc.scale);
			}
		}
	}
}
