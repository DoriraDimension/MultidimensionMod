using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Vanity
{
	[AutoloadEquip(EquipType.Body)]
	public class VikingPlate : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Viking Chestplate");
			// Tooltip.SetDefault("lore soon.");
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 18;
			Item.value = Item.sellPrice(silver: 15);
			Item.rare = ItemRarityID.Green;
			Item.vanity = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<VikingRelic>(), 4)
			.AddTile(134)
			.Register();
		}
	}
}