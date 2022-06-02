using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Weapons.Summon;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Tundra
{
	public class IceDrakeJuvenile : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Drake Juvenile");
			Main.npcFrameCount[NPC.type] = 5;
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.FlyingSnake);
			NPC.width = 44;
			NPC.height = 34;
			NPC.damage = 16;
			NPC.defense = 13;
			NPC.lifeMax = 50;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 0, 90);
			NPC.knockBackResist = 0.6f;
			NPC.aiStyle = 14;
			AIType = NPCID.FlyingSnake;
			AnimationType = NPCID.Bird;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<BbyDrakeBanner>();
		}

		public override void ModifyNPCLoot(NPCLoot NPCloot)
		{
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<FrostScale>(), 1, 1, 3));
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<DrakeCrystal>(), 30));
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (spawnInfo.Player.ZoneSnow && spawnInfo.SpawnTileY <= Main.maxTilesY - 200 && spawnInfo.SpawnTileY > Main.rockLayer)
            {
				return 0.13f;
            }
			else if (spawnInfo.Player.ZoneSnow && spawnInfo.Player.ZoneRain)
			{
				return 0.80f;
			}
			return 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (NPC.life <= 0)
			{
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/JuvenileDrakeGore1").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/JuvenileDrakeGore2").Type, 1);
			}
		}
	}
}
