using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Tools
{
	public class ScarusFossores : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scarus Fossores");
			Tooltip.SetDefault("A pickaxe created from old blueprints found at the shores. The ancient depictions show it being used to carve out holes from reefs.");
			DisplayName.AddTranslation(GameCulture.German, "Scarus Fossores");
			Tooltip.AddTranslation(GameCulture.German, "Eine Spitzhacke die mit alten Bauplänen erschaffen wurde welche am Ufer gefunden wurden. Die uralten Darstellungen zeigen wie sie benutzt wurde um Löcher in Riffe zu hauen.");
		}

		public override void SetDefaults()
		{
			item.damage = 56;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 5;
			item.useAnimation = 13;
			item.pick = 220;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = Item.sellPrice(gold: 4);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.tileBoost += 3;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<TidalQuartz>(), 5);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}