using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Accessories
{
	public class BlackRoseScarf : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 46;
			Item.height = 50;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.Yellow;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.thorns = 0.45f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<ThornScarf>())
			.AddIngredient(ItemID.VialofVenom, 2)
			.AddIngredient(ItemID.BlackFairyDust)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}