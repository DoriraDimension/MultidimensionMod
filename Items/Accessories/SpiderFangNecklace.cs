using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class SpiderFangNecklace : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 42;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 23);
			Item.rare = ItemRarityID.LightRed;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetArmorPenetration(DamageClass.Generic) += 9;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(3212)
			.AddIngredient(ItemID.SpiderFang, 10)
			.AddTile(18)
			.Register();
		}
	}
}
