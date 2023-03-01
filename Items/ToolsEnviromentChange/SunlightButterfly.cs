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
			// DisplayName.SetDefault("Sunlight Butterfly");
			// Tooltip.SetDefault("A artifact shaped after a deity of balance, its magic power scares the moon away\nThis butterfly resembles the red goddess who is more mature and serious.");
		}

		public override void SetDefaults()
		{
			Item.width = 82;
			Item.height = 76;
			Item.rare = ItemRarityID.Orange;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.useStyle = 4;
			Item.UseSound = SoundID.Item60;
			Item.consumable = false;
		}

		public override bool? UseItem(Player player)
		{
			if (Main.netMode != 1)
			{
				Main.dayTime = true;
				Main.time = 0.0;
			}
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>(), 8)
			.AddIngredient(ItemID.Daybloom, 3)
			.AddRecipeGroup("EvilSample", 6)
			.AddTile(16)
			.Register();
		}
	}
}