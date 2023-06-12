using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Accessories
{
	public class DivineStarBlessing : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 42;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 4, 0, 0);
			Item.rare = ItemRarityID.Lime;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.starCloakItem = Item;
			player.pStone = true;
			player.longInvince = true;
			player.lifeRegen++;
		}

		public override void AddRecipes()
        {
			CreateRecipe()
			.AddIngredient(ItemID.StarVeil)
			.AddIngredient(ItemID.CharmofMyths)
			.AddIngredient(ModContent.ItemType<Prismatine>(), 4)
			//.AddIngredient(ModContent.ItemType<CelestialPlating>(), 4)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
        }
	}
}