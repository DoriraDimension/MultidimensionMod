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
			Tooltip.SetDefault("A artifact shaped after a deity of balance, it's magic power scares the sun away\nThis butterfly resembles the blue goddess who is more childish and playful.");
		}

		public override void SetDefaults()
		{
			Item.width = 66;
			Item.height = 60;
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
                Main.dayTime = false;
				Main.time = 0.0;
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<FrostScale>(), 8)
			.AddIngredient(ItemID.Moonglow, 3)
			.AddRecipeGroup("EvilSample", 6)
			.AddTile(16)
			.Register();
		}
	}
}
