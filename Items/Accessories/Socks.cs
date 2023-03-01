using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace MultidimensionMod.Items.Accessories
{
	public class Socks : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 32;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 4);
			Item.rare = ItemRarityID.White;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.wet && !player.lavaWet && !player.honeyWet && !player.immune)
			{
				player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " died from the pain of wearing wet socks."), 1000.0, 0);
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Silk, 10)
			.AddTile(332)
			.Register();
		}
	}
}