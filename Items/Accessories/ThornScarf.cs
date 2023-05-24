using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Neck)]
	public class ThornScarf : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 42;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 40, 0);
			Item.rare = ItemRarityID.Green;
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
			.AddTile(TileID.LivingLoom)
			.Register();
		}
	}
}