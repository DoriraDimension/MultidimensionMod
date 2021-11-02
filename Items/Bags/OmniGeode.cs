using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Bags
{
	public class OmniGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Omni Geode");
			Tooltip.SetDefault("A geode found after the spirits of lights and darkness have been released.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve hardmode cavern minerals.");
			DisplayName.AddTranslation(GameCulture.German, "Omni Geode");
			Tooltip.AddTranslation(GameCulture.German, "Eine Geode welche gefunden wurde nachdem die Geister des Lichts und der Dunkelheit entfesselt wurden. \nEin Schmied kann sie dir aufbrechen, leider ist da keiner. \nRechtsklicke um hardmode Untergrund Mineralien zu erhalten.");
		}

		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 34;
			item.rare = ItemRarityID.LightRed;
			item.maxStack = 99;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			int choice = Main.rand.Next(6);
			if (choice == 0)
			{
				player.QuickSpawnItem(ItemID.CobaltOre, 20);
			}
			else if (choice == 1)
			{
				player.QuickSpawnItem(ItemID.PalladiumOre, 20);
			}
			else if (choice == 2)
			{
				player.QuickSpawnItem(ItemID.OrichalcumOre, 20);
			}
			else if (choice == 3)
			{
				player.QuickSpawnItem(ItemID.MythrilOre, 20);
			}
			else if (choice == 4)
			{
				player.QuickSpawnItem(ItemID.AdamantiteOre, 20);
			}
			else if (choice == 5)
			{
				player.QuickSpawnItem(ItemID.TitaniumOre, 20);
			}
		}
	}
}