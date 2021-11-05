using MultidimensionMod.Items.Banners;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Desert
{
	public class LesserSandElemental : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lesser Sand Elemental");
			DisplayName.AddTranslation(GameCulture.German, "Niederer Sand Elementar");
			Main.npcFrameCount[npc.type] = 5;
		}

		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.FlyingSnake);
			npc.width = 36;
			npc.height = 36;
			npc.damage = 28;
			npc.defense = 7;
			npc.lifeMax = 60;
			npc.HitSound = SoundID.NPCHit23;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 0, 80);
			npc.knockBackResist = 0.3f;
			npc.aiStyle = 44;
			aiType = NPCID.FlyingSnake;
			animationType = NPCID.Bird;
			banner = npc.type;
			bannerItem = ModContent.ItemType<LesserSandEleBanner>();
		}

		public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), mod.ItemType("ManaInfusedSandstone"), Main.rand.Next(1, 3));
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.player.ZoneDesert && spawnInfo.spawnTileY <= Main.maxTilesY - 200 && spawnInfo.spawnTileY > Main.rockLayer)
			{
				return 0.05f;
			}
			return 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Desert/SandEleGore"), npc.scale);
			}
		}
	}
}
