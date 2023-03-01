using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class AstralTitansEyeJewel : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 38;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Pink;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.pStone = true;
			player.starCloakItem = Item;
			player.longInvince = true;
			player.lifeRegen += 2;

		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(860)
			.AddIngredient(862)
			.AddIngredient(ModContent.ItemType<Blight2>(), 2)
			.AddTile(134)
			.Register();
		}
	}
}