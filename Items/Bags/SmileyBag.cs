using MultidimensionMod.NPCs.Boss.Smiley;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using MultidimensionMod.Items.Weapons.Ranged.Guns;
using MultidimensionMod.Items.Weapons.Magic.Other;
using MultidimensionMod.Items.Weapons.Summon;
using MultidimensionMod.Items.Vanity;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Placeables.Trophies;
using MultidimensionMod.Items.Pets;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Bags
{
	public class SmileyBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 34;
			item.height = 38;
			item.rare = ItemRarityID.LightRed;
			item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			if (Main.rand.Next(7) == 0)
			{
				player.QuickSpawnItem(ModContent.ItemType<SmileyMask>());
			}
			if (Main.rand.Next(10) == 0)
			{
				player.QuickSpawnItem(ModContent.ItemType<SmileyTrophy>());
			}
			if (Main.rand.Next(10) == 0)
			{
				player.QuickSpawnItem(ModContent.ItemType<LonelyWarriorsVisor>());
				player.QuickSpawnItem(ModContent.ItemType<DarkCloak>());
			}
			if (Main.rand.Next(8) == 0)
			{
				player.QuickSpawnItem(ModContent.ItemType<CuteEmoji>());
			}
			int choice = Main.rand.Next(4);
			if (choice == 0)
			{
				player.QuickSpawnItem(ModContent.ItemType<LonelySword>());
			}
			if (choice == 1)
			{
				player.QuickSpawnItem(ModContent.ItemType<DarkMatterLauncher>());
			}
			if (choice == 2)
			{
				player.QuickSpawnItem(ModContent.ItemType<SmileySmile>());
			}
			if (choice == 3)
			{
				player.QuickSpawnItem(ModContent.ItemType<DarkRebels>());
			}
			player.QuickSpawnItem(ModContent.ItemType<DarkMatterClump>(), Main.rand.Next(20, 26));
			player.QuickSpawnItem(ModContent.ItemType<ShadowEmoji>());
			player.QuickSpawnItem(ModContent.ItemType<SmileySoulshard>());
		}

		public override int BossBagNPC => ModContent.NPCType<Smiley>();
	}
}