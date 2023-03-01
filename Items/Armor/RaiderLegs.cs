using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class RaiderLegs : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = Item.sellPrice(silver: 26);
			Item.rare = ItemRarityID.Green;
			Item.defense = 6;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<VikingRelic>(), 7)
			.AddTile(134)
			.Register();
		}
	}
}