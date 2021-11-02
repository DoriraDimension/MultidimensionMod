using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Bags
{
	public class EnergyFish : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Energy Fish");
			Tooltip.SetDefault("A fish charged with the lowest tier of Dimensional Energy.\nRight click to extract its energy.");
			DisplayName.AddTranslation(GameCulture.German, "Energie Fisch");
			Tooltip.AddTranslation(GameCulture.German, "Ein fish geladen mit der niedrigsten stufe von dimensionaler Energie.\nRechtsklick um seine Energie zu extrahieren.");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 22;
			item.rare = ItemRarityID.Blue;
			item.maxStack = 99;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			player.QuickSpawnItem(ModContent.ItemType<Dimensium>(), Main.rand.Next(8, 10));
		}
	}
}
