using MultidimensionMod.Common.Players;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class MysticStone : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 36;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 13);
			Item.rare = ItemRarityID.Green;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MDPlayer>().Geodes = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Geode, 3)
			.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>(), 5)
			.AddIngredient(ItemID.Granite, 13)
			.AddIngredient(ItemID.Marble, 13)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}