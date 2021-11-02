using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.ToolsEnviromentChange
{
	public class CelestialLepidoptera : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestial Lepidoptera");
			Tooltip.SetDefault("A artifact created with the two artifacts of day and night, it's said that it resembles a deity of time.\nCan be used to change day to night and vice versa.");
			DisplayName.AddTranslation(GameCulture.German, "Himmlischer Lepidoptera");
			Tooltip.AddTranslation(GameCulture.German, "Ein Artefakt welches mit den Artefakten des Tags und der Nacht geschaffen wurde, es wird gesagt das es einer Gottheit der Zeit ähnelt.\nKann benutzt werden um den Tag zur Nacht zu ändern und umgekehrt.");
		}

		public override void SetDefaults()
		{
			item.width = 66;
			item.height = 60;
			item.rare = ItemRarityID.LightRed;
			item.useAnimation = 20;
			item.useTime = 20;
			item.useStyle = 4;
			item.UseSound = SoundID.Item60;
			item.consumable = false;
		}

		public override bool UseItem(Player player)
		{
			if (Main.netMode != 1 && Main.dayTime == false)
			{
				Main.dayTime = true;
			}
			else if (Main.dayTime)
            {
				Main.dayTime = false;
            }
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<SunlightButterfly>());
			recipe.AddIngredient(ModContent.ItemType<MoonlightMoth>());
			recipe.AddIngredient(ItemID.AncientBattleArmorMaterial);
			recipe.AddIngredient(ItemID.FrostCore);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
