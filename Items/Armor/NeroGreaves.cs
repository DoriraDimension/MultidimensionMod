using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class NeroGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nero Greaves");
			Tooltip.SetDefault("Greaves created from old blueprints found at the shores. The ancient depictions show brave warriors defending their home.\nIncreases movement speed by 8%.");
			DisplayName.AddTranslation(GameCulture.German, "Nero Beinschienen");
			Tooltip.AddTranslation(GameCulture.German, "Beinschienen die mit alten Bauplänen erschaffen wurde welche am Ufer gefunden wurden. Die uralten Darstellungen zeigen tapfere Krieger die ihr zuhause verteidigen.\nErhöht Bewegungsgeschwindigkeit um 8%.");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 14;
			item.value = Item.sellPrice(gold: 7);
		    item.rare = ItemRarityID.Yellow;
			item.defense = 15;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.08f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<TidalQuartz>(), 8);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}