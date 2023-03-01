using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class VikingHelm : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Viking Helm");
			// Tooltip.SetDefault("lore soon");
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 22;
			Item.value = Item.sellPrice(silver: 12);
			Item.rare = ItemRarityID.Green;
			Item.vanity = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<VikingRelic>(), 2)
			.AddTile(134)
			.Register();
		}
	}
}