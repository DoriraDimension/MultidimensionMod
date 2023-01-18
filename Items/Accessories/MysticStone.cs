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
			DisplayName.SetDefault("Mystic Geode");
			Tooltip.SetDefault("A geode infused with potent dimensional magic, its presence empowers any thrown geode\nCauses geodes to drop themself as a 1/3 chance instead of their regular loot\nGrants geodes unique effects depending on their type\nNew effects are added when entering hardmode\nIncreases the chance of obtaining Geodes drastically");
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