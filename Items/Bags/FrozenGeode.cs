using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Bags
{
	public class FrozenGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frozen Geode");
			Tooltip.SetDefault("A geode found in the ice caves\nA blacksmith can break this open for you, sadly, there is none\nRight click to recieve ice cave minerals.");
			DisplayName.AddTranslation(GameCulture.German, "Gefrorene Geode");
			Tooltip.AddTranslation(GameCulture.German, "Eine Geode welche in den Eishöhlen gefunden wurde. \nEin Schmied kann sie dir aufbrechen, leider ist da keiner. \nRechtsklicke um Eis Mineralien zu erhalten.");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.rare = ItemRarityID.Green;
			item.maxStack = 99;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			int choice = Main.rand.Next(8);
			if (choice == 0)
			{
				player.QuickSpawnItem(ItemID.IceBlock, 35);
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(ItemID.FrostCore);
					}
				}
			}
			else if (choice == 1)
			{
				if (Main.hardMode)
				{
					player.QuickSpawnItem(ItemID.PinkIceBlock, 35);
				}
				else if (Main.hardMode == false)
                {
					player.QuickSpawnItem(ItemID.IceBlock, 35);
                }

			}
			else if (choice == 2)
            {
				player.QuickSpawnItem(ItemID.RedIceBlock, 35);
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(ItemID.FrostCore);
					}
				}
			}
			else if (choice == 3)
            {
				player.QuickSpawnItem(ItemID.PurpleIceBlock, 35);
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(ItemID.FrostCore);
					}
				}
			}
			else if (choice == 4)
            {
				player.QuickSpawnItem(ItemID.VikingHelmet);
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(ItemID.FrostCore);
					}
				}
			}
			else if (choice == 5)
            {
				player.QuickSpawnItem(ItemID.SlushBlock, 35);
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(ItemID.FrostCore);
					}
				}
			}
			else if (choice == 6)
			{
				player.QuickSpawnItem(ModContent.ItemType<OldFrozenStaffHead>());
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(ItemID.FrostCore);
					}
				}
			}
			else if (choice == 7)
			{
				player.QuickSpawnItem(ModContent.ItemType<OldFrozenRod>());
				if (Main.hardMode)
				{
					if (Main.rand.NextFloat() < .2500f)
					{
						player.QuickSpawnItem(ItemID.FrostCore);
					}
				}
			}
		}
	}
}