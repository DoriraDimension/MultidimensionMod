using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class BaitLeaf : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bait Leaf");
			Tooltip.SetDefault("A aromatic leaf from another dimension, its strong scent can even lure in bigger predators.\nThese might be useful to attract helpers, but be aware of possible stronger foes getting attracted too.\nGives +1 minion slot");
		}

		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 30;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 3);
			Item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions += 1;
		}
	}
}