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
			DisplayName.SetDefault("Fishron Tooth Necklace");
			Tooltip.SetDefault("A necklace made from the Teeth of a great ocean abomination,\nas shown in depictions of the old sea civilisation, it was seen as a sign of strength.\nIncreases armor penetration by 12.");
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
