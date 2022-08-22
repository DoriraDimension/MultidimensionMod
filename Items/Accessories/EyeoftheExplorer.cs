using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class EyeoftheExplorer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of the Explorer");
			Tooltip.SetDefault("A true adventurer can sense traps and danger.\nOne of the forbidden eyes.\nYou can see danger sources.");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.accessory = true;
			Item.value = Item.sellPrice(copper: 60);
			Item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.dangerSense = true;
			player.GetModPlayer<MDPlayer>().ExplorerEye = true;
		}
	}
}