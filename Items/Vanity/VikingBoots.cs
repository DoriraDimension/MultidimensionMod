using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Vanity
{
	[AutoloadEquip(EquipType.Legs)]
	public class VikingBoots : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Viking Boots");
			Tooltip.SetDefault("lore soon.");
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 18;
			Item.value = Item.sellPrice(silver: 15);
			Item.rare = ItemRarityID.Green;
			Item.vanity = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<VikingRelic>(), 3)
			.AddTile(134)
			.Register();
		}
	}
}