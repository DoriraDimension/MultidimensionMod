using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Ammo
{
	public class InfiniteGelTank : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infinite Gel Tank");
			Tooltip.SetDefault("A tank with integrated gel fabricator, you will never run out of gel anymore.");
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.Green;
			Item.ammo = AmmoID.Gel;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Gel, 600)
			.AddTile(134)
			.Register();
		}
	}
}
