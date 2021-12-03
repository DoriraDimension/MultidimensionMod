using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.ToolsEnviromentChange
{
	public class SunlightButterfly : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sunlight Butterfly");
			Tooltip.SetDefault("A artifact created with the essence of light, it's magic power scares the moon away");
			DisplayName.AddTranslation(GameCulture.German, "Sonnenlicht Schmetterling");
			Tooltip.AddTranslation(GameCulture.German, "Ein Artefakt welches mit der Essenz des Lichts geschaffen wurde, seine magischen Kräfte verscheuchen den Mond.");
		}

		public override void SetDefaults()
		{
			item.width = 66;
			item.height = 54;
			item.rare = ItemRarityID.LightRed;
			item.useAnimation = 20;
			item.useTime = 20;
			item.useStyle = 4;
			item.UseSound = SoundID.Item60;
			item.consumable = false;
		}

		public override bool UseItem(Player player)
		{
			if (Main.netMode != 1)
			{
				Main.dayTime = true;
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>(), 8);
			recipe.AddIngredient(ItemID.Daybloom, 3);
			recipe.AddRecipeGroup("EvilSample", 6);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
