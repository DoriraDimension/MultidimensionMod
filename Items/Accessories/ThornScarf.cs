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
			DisplayName.SetDefault("Thorn Scarf");
			Tooltip.SetDefault("Old natives of the jungle would wear this to hurt animals that attack them but would also hurt themself,\na small price to pay to be able to escape a attacking predator.\nReflects 15% of damage back to the enemy if they touch you");
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