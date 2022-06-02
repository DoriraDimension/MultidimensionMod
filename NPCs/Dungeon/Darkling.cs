using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Dungeon
{
	public class Darkling : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkling");
			Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.CursedSkull);
			NPC.width = 46;
			NPC.height = 46;
			NPC.damage = 45;
			NPC.defense = 3;
			NPC.lifeMax = 120;
			NPC.HitSound = SoundID.NPCHit54;
			NPC.DeathSound = SoundID.NPCDeath52;
			NPC.value = Item.buyPrice(0, 0, 1, 40);
			NPC.knockBackResist = 0.6f;
			NPC.aiStyle = 10;
			AIType = NPCID.CursedSkull;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<DarklingBanner>();
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.Dungeon.Chance * 0.1f;
		}

		public override void ModifyNPCLoot(NPCLoot NPCloot)
		{
		    NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<DarkMatterClump>(), 1, 1, 3));
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = Main.rand.Next(27, 27);
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter += 1.0;
			if (NPC.frameCounter >= 5.0)
			{
				NPC.frameCounter = 0.0;
				NPC.frame.Y += frameHeight;
				if (NPC.frame.Y >= Main.npcFrameCount[NPC.type] * frameHeight)
				{
					NPC.frame.Y = 0;
				}
			}
		}
	}
}