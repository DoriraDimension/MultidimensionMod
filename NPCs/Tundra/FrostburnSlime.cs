using MultidimensionMod.Items.Placeables.Banners;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Tundra
{
	public class FrostburnSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frostburn Slime");
			DisplayName.AddTranslation(GameCulture.German, "Frostbrand Schleim");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.Slimer);
			npc.width = 45;
			npc.height = 42;
			npc.damage = 70;
			npc.defense = 6;
			npc.lifeMax = 180;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 6, 70);
			npc.knockBackResist = 0.2f;
			npc.aiStyle = 14;
			aiType = NPCID.Slimer;
			animationType = NPCID.Slimer;
			banner = npc.type;
			bannerItem = ModContent.ItemType<FrostburnSlimeBanner>();
		}

		public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), ItemID.Gel);
			if (Main.rand.NextFloat() < .0001f)
			{
				Item.NewItem(npc.getRect(), ItemID.SlimeStaff);
			}

			if (Main.rand.NextFloat() < .0200f)
			{
				Item.NewItem(npc.getRect(), ItemID.FrostCore);
			}

			if (Main.rand.NextFloat() < .0200f)
            {
				Item.NewItem(npc.getRect(), mod.ItemType("FrostburnWings"));
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.player.ZoneSnow && Main.hardMode)
			{
				return 0.15f;
			}
			else return 0f;
		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			player.AddBuff(BuffID.Frostburn, 360, true);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = Main.rand.Next(80, 80);
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}
}
