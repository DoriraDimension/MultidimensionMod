using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Neck)]
	public class ThornScarf : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thorn Scarf");
			Tooltip.SetDefault("Why would you wear this? \nHurts enemies when they touch you");
			DisplayName.AddTranslation(GameCulture.German, "Dornenschal");
			Tooltip.AddTranslation(GameCulture.German, "Warum würdest du sowas tragen? \nSchadet Gegnern wenn sie dich berühren.");
		}

		public override void SetDefaults()
		{
			item.width = 42;
			item.height = 46;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 5);
			item.rare = ItemRarityID.Orange;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.thorns = 0.15f;

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Stinger, 5);
            recipe.AddIngredient(ItemID.Vine, 1);
			recipe.AddIngredient(ItemID.JungleSpores, 8);
			recipe.AddTile(304);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}