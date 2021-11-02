using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Bags
{
	public class FairyGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fairy Geode");
			Tooltip.SetDefault("A geode found in the Hallow.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve Hallow minerals.");
			DisplayName.AddTranslation(GameCulture.German, "Feen Geode");
			Tooltip.AddTranslation(GameCulture.German, "Eine Geode welche im Heiligtum gefunden wurde. \nEin Schmied kann sie dir aufbrechen, leider ist da keiner. \nRechtsklicke um Heiligtum Mineralien zu erhalten.");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.rare = ItemRarityID.LightRed;
			item.maxStack = 99;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			int choice = Main.rand.Next(2);
			if (choice == 0)
			{
				player.QuickSpawnItem(ItemID.CrystalShard, 15);
			}
			else if (choice == 1)
			{
				player.QuickSpawnItem(ItemID.PearlstoneBlock, 50);
			}
		}
	}
}