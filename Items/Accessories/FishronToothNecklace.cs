using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class FishronToothNecklace : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 44;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 89);
			Item.rare = ItemRarityID.Lime;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetArmorPenetration(DamageClass.Generic) += 12;
			player.gills = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<SpiderFangNecklace>())
			.AddIngredient(ModContent.ItemType<TidalQuartz>(), 7)
			.AddTile(18)
			.Register();
		}
	}
}
