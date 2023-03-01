using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Neck)]
	public class ThornScarf : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 42;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 5);
			Item.rare = ItemRarityID.Orange;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.thorns = 0.15f;

		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Stinger, 5)
            .AddIngredient(ItemID.Vine, 2)
			.AddIngredient(ItemID.JungleSpores, 8)
			.AddTile(304)
			.Register();
		}
	}
}