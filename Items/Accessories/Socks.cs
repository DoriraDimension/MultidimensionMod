using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class Socks : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Socks");
			Tooltip.SetDefault("Don't let them get wet or you will be in eternal pain.");
			DisplayName.AddTranslation(GameCulture.German, "Socken");
			Tooltip.AddTranslation(GameCulture.German, "Lass sie nicht nass werden oder du wirst ewigen Schmerz erleben.");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 32;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 4);
			item.rare = ItemRarityID.White;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.wet && !player.immune)
			{
				player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " died from the pain of wearing wet socks."), 1000.0, 0);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.Silk, 10);
			modRecipe.AddTile(332);
			modRecipe.SetResult(this);
			modRecipe.AddRecipe();
		}
	}
}