using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class HealthyCap : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Healthy Cap");
			Tooltip.SetDefault("A healthy mushroom filled with healing potion liquid.\nIncreases the amount of HP healed by mushrooms to 60.");
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 32;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 2);
			Item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MDPlayer>().Healthy = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Mushroom, 15)
			.AddIngredient(ItemID.LesserHealingPotion, 1)
			.Register();
		}
	}
}
