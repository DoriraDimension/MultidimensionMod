using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class EleanoraBodypillow : ModItem
	{
		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Dimensional Goddess Bodypillow");
			Tooltip.SetDefault("A Dimensional Goddess Bodypillow for your bedroom.");
			DisplayName.AddTranslation(GameCulture.German, "Dimensionsgöttin Körperkissen");
			Tooltip.AddTranslation(GameCulture.German, "Ein Dimensionsgöttin Körperkissen für dein Schlafzimmer.");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 48;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Red;
			item.value = Item.sellPrice(silver: 69);
			item.createTile = ModContent.TileType<Tiles.EleanoraBodypillow>();
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
			recipe.AddIngredient(ItemID.Silk, 200);
			recipe.AddIngredient(ItemID.LivingFireBlock, 69);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}