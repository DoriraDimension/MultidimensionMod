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
			Tooltip.SetDefault("A healthy mushroom filled with healing potion liquid.\nIncreases max HP by 35.");
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
			player.statLifeMax2 += 35;
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
