using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class RaiderChest : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Raider Chestplate");
			Tooltip.SetDefault("lore soon.");
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 36;
			Item.value = Item.sellPrice(silver: 31);
			Item.rare = ItemRarityID.Green;
			Item.defense = 10;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<VikingRelic>(), 9)
			.AddTile(134)
			.Register();
		}
	}
}