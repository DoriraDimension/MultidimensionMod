using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Tools
{
	public class MatterMiner : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Matter Miner");
			Tooltip.SetDefault("A dark matter pickaxe made to mine any matter... and it still cannot mine high tier ores...");
			DisplayName.AddTranslation(GameCulture.German, "Materie Miner");
			Tooltip.AddTranslation(GameCulture.German, "Eine dunkle materie Spitzhacke, geschaffen um jede Materie abzubauen... leider kann sie trozdem keine stärkeren Erze abbauen.");
		}

		public override void SetDefaults()
		{
			item.damage = 15;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 16;
			item.useAnimation = 24;
			item.pick = 100;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = Item.sellPrice(silver: 6);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.tileBoost += 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 12);
			recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}