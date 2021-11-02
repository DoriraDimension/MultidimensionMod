using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Bags
{
	public class DecayGeode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Decay Geode");
			Tooltip.SetDefault("A geode found in the Corruption.\nA blacksmith can break this open for you, sadly, there is none.\nRight click to recieve Corruption minerals.");
			DisplayName.AddTranslation(GameCulture.German, "Verwesungs Geode");
			Tooltip.AddTranslation(GameCulture.German, "Eine Geode welche im Verderben gefunden wurde. \nEin Schmied kann sie dir aufbrechen, leider ist da keiner. \nRechtsklicke um Verderben Mineralien zu erhalten.");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 20;
			item.rare = ItemRarityID.Green;
			item.maxStack = 99;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			int choice = Main.rand.Next(4);
			if (choice == 0)
			{
				player.QuickSpawnItem(ItemID.DemoniteOre, 20);
			}
			else if (choice == 1)
			{
				player.QuickSpawnItem(ItemID.EbonstoneBlock, 50);
			}
			else if (choice == 2)
			{
				player.QuickSpawnItem(ModContent.ItemType<OldTaintedMandible>());
			}
			else if (choice == 3)
			{
				player.QuickSpawnItem(ModContent.ItemType<OldTaintedCurseContainer>());
			}
		}
	}
}