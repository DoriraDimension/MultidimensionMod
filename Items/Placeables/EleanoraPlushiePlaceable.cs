using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class EleanoraPlushiePlaceable : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dimensional Goddess Plushie");
			Tooltip.SetDefault("The adorable goddess now exists as a marketable plushie.");
			DisplayName.AddTranslation(GameCulture.German, "Dimensionsgötting Plüschtier");
			Tooltip.AddTranslation(GameCulture.German, "Die bezaubernde Göttin existiert jetzt als ein marktfähiges Pluschtier.");
		}

		public override void SetDefaults()
		{
			item.width = 48;
			item.height = 60;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Red;
			item.value = Item.sellPrice(silver: 69);
			item.createTile = ModContent.TileType<Tiles.EleanoraPlushiePlaced>();
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.mod == "Terraria" && item.Name == "ItemName")
				{
					item.overrideColor = MDRarity.Eleanora;
				}
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentSolar, 10);
			recipe.AddIngredient(ItemID.Silk, 15);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}