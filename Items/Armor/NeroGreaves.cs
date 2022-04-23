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
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 14;
			Item.value = Item.sellPrice(gold: 5);
		    Item.rare = ItemRarityID.Yellow;
			Item.defense = 15;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.08f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<TidalQuartz>(), 8)
			.AddIngredient(ItemID.HallowedBar, 10)
			.AddTile(134)
			.Register();
		}
	}
}