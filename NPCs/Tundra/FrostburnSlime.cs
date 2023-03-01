using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Items.Wings;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Tundra
{
	public class FrostburnSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Frostburn Slime");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.Slimer);
			NPC.width = 45;
			NPC.height = 42;
			NPC.damage = 70;
			NPC.defense = 6;
			NPC.lifeMax = 180;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 6, 70);
			NPC.knockBackResist = 0.2f;
			NPC.aiStyle = 14;
			AIType = NPCID.Slimer;
			AnimationType = NPCID.Slimer;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<FrostburnSlimeBanner>();
		}

		public override void ModifyNPCLoot(NPCLoot NPCloot)
		{
			NPCloot.Add(ItemDropRule.Common(ItemID.Gel));
			NPCloot.Add(ItemDropRule.Common(ItemID.SlimeStaff, 1000));
			NPCloot.Add(ItemDropRule.Common(ItemID.FrostCore, 50));
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<FrostburnWings>(), 50));
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.Player.ZoneSnow && Main.hardMode)
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
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}
}
