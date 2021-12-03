using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class GlowingFungiScarf : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glowing Fungi Scarf");
			Tooltip.SetDefault("A scarf made out of several mushrooms, it glows.\nIncreases ranged damage by 5%.\nIncreases max life by 10 when in a glowing mushroom biome\nIncreases max life by 25 and damage reduction by 5% when in a glowing mushroom biome in hardmode.");
			DisplayName.AddTranslation(GameCulture.German, "Leuchtender Fungi Schal");
			Tooltip.AddTranslation(GameCulture.German, "Ein Schal der aus einigen Pilzen gemacht wurde, er leuchtet.\nErhöht Fernkampfschaden um 5%.\nErhöht maximale Leben um 10 wenn in einem glühenden Pilz biom.\nErhöht maximale Leben um 25 und Schadenreduziering um 5% wenn in einem glühenden Pilz biom im Hardmode.");
		}

		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 48;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 36);
			item.rare = ItemRarityID.Green;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
		    if (player.ZoneGlowshroom && Main.hardMode)
			{
				player.statLifeMax2 += 25;
				player.endurance += 5f;
			}
			else if (player.ZoneGlowshroom)
            {
				player.statLifeMax2 += 10;
            }
			else
				player.rangedDamage += 5f;
			    Lighting.AddLight((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f), 0.15f, 0.6f, 0.8f);


		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Mushmatter>(), 10);
			recipe.AddIngredient(ItemID.GlowingMushroom, 25);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}