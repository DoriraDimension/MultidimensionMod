using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Tools
{
	public class PanaqueMalluris : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Panaque Malluris");
			Tooltip.SetDefault("A hamaxe created from old blueprints found at the shores. The ancient depictions show it being used to gather and shape wood.");
			DisplayName.AddTranslation(GameCulture.German, "Panaque Malluris");
			Tooltip.AddTranslation(GameCulture.German, "Eine Hamaxt die mit alten Bauplänen erschaffen wurde welche am Ufer gefunden wurden. Die uralten Darstellungen zeigen wie sie benutzt wurde um Holz zu sammeln und zu formen.");
		}

		public override void SetDefaults()
		{
			item.damage = 53;
			item.melee = true;
			item.width = 56;
			item.height = 50;
			item.useTime = 15;
			item.useAnimation = 15;
			item.axe = 27;
			item.hammer = 90;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = Item.sellPrice(gold: 2);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<TidalQuartz>(), 4);
			recipe.AddIngredient(ItemID.HallowedBar, 9);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
