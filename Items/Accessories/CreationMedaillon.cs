using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Accessories
{
	public class CreationMedaillon : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 38;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 8, 30, 0);
			Item.rare = ItemRarityID.Red;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{

		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<AstralTitansEyeJewel>())
			.AddIngredient(ModContent.ItemType<DivineStarBlessing>())
			.AddIngredient(ItemID.LunarBar, 10)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
		}
	}
}