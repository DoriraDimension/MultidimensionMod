using MultidimensionMod.Items.Placeables.Banners;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Tundra
{
	public class IceDrakeJuvenile : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Drake Juvenile");
			DisplayName.AddTranslation(GameCulture.German, "Eis Draken Jungtier");
			Main.npcFrameCount[npc.type] = 5;
		}

		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.FlyingSnake);
			npc.width = 44;
			npc.height = 34;
			npc.damage = 24;
			npc.defense = 13;
			npc.lifeMax = 50;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 0, 90);
			npc.knockBackResist = 0.6f;
			npc.aiStyle = 14;
			aiType = NPCID.FlyingSnake;
			animationType = NPCID.Bird;
			banner = npc.type;
			bannerItem = ModContent.ItemType<BbyDrakeBanner>();
		}

		public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), mod.ItemType("FrostScale"), Main.rand.Next(1, 3));
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (spawnInfo.player.ZoneSnow && spawnInfo.spawnTileY <= Main.maxTilesY - 200 && spawnInfo.spawnTileY > Main.rockLayer)
            {
				return 0.20f;
            }
			return 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Tundra/JuvenileDrakeGore1"), npc.scale);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Tundra/JuvenileDrakeGore2"), npc.scale);
			}
		}
	}
}
