using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.ToolsEnviromentChange
{
	public class MoonlightMoth : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moonlight Moth");
			Tooltip.SetDefault("A artifact created with the essence of the night, it's magic power scares the sun away");
			DisplayName.AddTranslation(GameCulture.German, "Moondlicht Motte");
			Tooltip.AddTranslation(GameCulture.German, "Ein Artefakt welches mit der Essenz der Nacht geschaffen wurde, seine magischen Kräfte verscheuchen die Sonne.");
		}

		public override void SetDefaults()
		{
			item.width = 50;
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
				Main.dayTime = false;
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<FrostScale>(), 8);
			recipe.AddIngredient(ItemID.Moonglow, 3);
			recipe.AddRecipeGroup("EvilSample", 6);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
