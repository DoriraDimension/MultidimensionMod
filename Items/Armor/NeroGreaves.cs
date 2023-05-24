using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class NeroGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 14;
			Item.value = Item.sellPrice(0, 1, 0, 0);
		    Item.rare = ItemRarityID.Yellow;
			Item.defense = 15;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.08f;
			player.accFlipper = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<TidalQuartz>(), 8)
			.AddIngredient(ItemID.HallowedBar, 10)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}