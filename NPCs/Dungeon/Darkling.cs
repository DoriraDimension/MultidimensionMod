using MultidimensionMod.Items.Banners;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Dungeon
{
	public class Darkling : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkling");
			DisplayName.AddTranslation(GameCulture.German, "Dunkelling");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.CursedSkull);
			npc.width = 46;
			npc.height = 46;
			npc.damage = 45;
			npc.defense = 3;
			npc.lifeMax = 60;
			npc.HitSound = SoundID.NPCHit54;
			npc.DeathSound = SoundID.NPCDeath52;
			npc.value = Item.buyPrice(0, 0, 1, 40);
			npc.knockBackResist = 0.6f;
			npc.aiStyle = 10;
			aiType = NPCID.CursedSkull;
			animationType = NPCID.Harpy;
			banner = npc.type;
			bannerItem = ModContent.ItemType<DarklingBanner>();
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.Dungeon.Chance * 0.1f;
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextFloat() < .7500f)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("DarkMatterClump"), Main.rand.Next(1, 4));
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = Main.rand.Next(27, 27);
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}
}