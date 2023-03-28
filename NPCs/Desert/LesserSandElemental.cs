using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Weapons.Summon;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Bestiary;

namespace MultidimensionMod.NPCs.Desert
{
	public class LesserSandElemental : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Lesser Sand Elemental");
			Main.npcFrameCount[NPC.type] = 5;
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.FlyingSnake);
			NPC.width = 36;
			NPC.height = 36;
			NPC.damage = 18;
			NPC.defense = 7;
			NPC.lifeMax = 60;
			NPC.HitSound = SoundID.NPCHit23;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 0, 0, 80);
			NPC.knockBackResist = 0.3f;
			NPC.aiStyle = 44;
			AIType = NPCID.FlyingSnake;
			AnimationType = NPCID.Bird;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<LesserSandEleBanner>();
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
				new FlavorTextBestiaryInfoElement("They are actually crystalized mana surrounded by sand, created artificially by the Children of Rahlem. They will react hostile against anything that enters their desert. During sandstorms they become even more active and travel to the surface, sometimes following Sand Elementals.")
			});
		}

		public override void ModifyNPCLoot(NPCLoot NPCloot)
		{
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<ManaInfusedSandstone>(), 1, 1, 3));
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<SandBun>(), 30));
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.Player.ZoneDesert && spawnInfo.SpawnTileY <= Main.maxTilesY - 200 && spawnInfo.SpawnTileY > Main.rockLayer)
			{
				return 0.05f;
			}

			if (spawnInfo.Player.ZoneDesert && spawnInfo.Player.ZoneSandstorm)
			{
				return 0.30f;
			}
			return 0f;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/SandEleGore").Type, 1);
			}
		}
	}
}
