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
			Tooltip.SetDefault("Old natives of the jungle would wear this to hurt animals that attack them but would also hurt themself,\na small price to pay to be able to escape a attacking predator.\nHurts enemies when they touch you");
			DisplayName.AddTranslation(GameCulture.German, "Dornenschal");
			Tooltip.AddTranslation(GameCulture.German, "Alte Einwohner des Dschungels trugen diesen Schal um Tieren zu schaden die sie attackieren würden aber auch sich slebst schaden,\nein kleiner Preis um einem Angriff eines Raubtiers zu entkommen.\nSchadet Gegnern wenn sie dich berühren.");
		}

		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 42;
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
            recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddIngredient(ItemID.JungleSpores, 8);
			recipe.AddTile(304);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}