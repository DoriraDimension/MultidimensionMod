using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class NeroBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nero Breastplate");
			Tooltip.SetDefault("A breastplate created from old blueprints found at the shores. The ancient depictions show brave warriors defending their home.\nIncreases crit chance by 15%.");
			DisplayName.AddTranslation(GameCulture.German, "Nero Brustplatte");
			Tooltip.AddTranslation(GameCulture.German, "Eine Brustplatte die mit alten Bauplänen erschaffen wurde welche am Ufer gefunden wurden. Die uralten Darstellungen zeigen tapfere Krieger die ihr zuhause verteidigen.\nIncreases crit chance by 15%.\nErhöht kritische Trefferchance um 15%.");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 20;
			item.value = Item.sellPrice(gold: 5);
			item.rare = ItemRarityID.Yellow;
			item.defense = 21;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 15;
			player.magicCrit += 15;
			player.rangedCrit += 15;
			player.thrownCrit += 15;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<TidalQuartz>(), 10);
			recipe.AddIngredient(ItemID.HallowedBar, 13);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}