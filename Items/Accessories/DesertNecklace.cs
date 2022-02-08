using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class DesertNecklace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Necklace");
			Tooltip.SetDefault("A magical necklace, created with the mana infused sand from a Lesser Sand Elemental.\nIt is unknown why the gem only reacts to the dry aura of deserts so are its actual origins.\nIncreases all damage and crit chance by 4% when in the Desert.");
			DisplayName.AddTranslation(GameCulture.German, "Wüsten Halskette");
			Tooltip.AddTranslation(GameCulture.German, "Eine magische Halskette, geschaffen mit dem mana durchwirkten Sand eines Niederen Sand Elementars.\nEs ist nicht bekannt warum der Edelstein nur auf die trockene Aura von Wüsten reagiert und so sind seine Ursprünge.\nErhöht allen Schaden und Kritische Trefferchance um 4% wenn in der Wüste.");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 2);
			item.rare = ItemRarityID.Green;
			item.defense = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.ZoneDesert)
			{
				player.allDamage += 0.4f;
				player.meleeCrit += 4;
				player.rangedCrit += 4;
				player.magicCrit += 4;
				player.thrownCrit += 4;
			}

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>(), 5);
			recipe.AddIngredient(ItemID.Emerald);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}