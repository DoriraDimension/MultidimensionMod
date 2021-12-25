using MultidimensionMod.Items.Placeables.Banners;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Desert
{
	public class GilaMonster : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gilania");
			DisplayName.AddTranslation(GameCulture.German, "Gilania");
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.Crab);
			npc.width = 70;
			npc.height = 26;
			npc.damage = 26;
			npc.defense = 20;
			npc.lifeMax = 210;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 6, 25);
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = NPCID.Crab;
			animationType = NPCID.Squirrel;
			banner = npc.type;
			bannerItem = ModContent.ItemType<GilaBanner>();
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextFloat() < .8000f)
			{
				Item.NewItem(npc.getRect(), ItemID.VialofVenom);
			}
		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
		     player.AddBuff(BuffID.Venom, 240);

		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.player.ZoneDesert && Main.hardMode && Main.dayTime && spawnInfo.spawnTileY <= Main.maxTilesY - 200 && spawnInfo.spawnTileY > Main.rockLayer)
			{
				return 0.15f;
			}
			else if (spawnInfo.player.ZoneDesert && Main.hardMode && !Main.dayTime && !spawnInfo.player.ZoneSandstorm)
			{
				return 0.15f;
			}
			return 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Desert/GilaGore1"), npc.scale);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Desert/GilaGore2"), npc.scale);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Desert/GilaGore3"), npc.scale);
			}
		}
	}
}
