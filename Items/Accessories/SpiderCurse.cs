using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class SpiderCurse : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spider Curse");
			Tooltip.SetDefault("A cursed artifact found in the spider caverns. \nIncreases movement speed by 10% and gives +1 minion slot. \nYou can stick to walls like a spider.");
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 34;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.LightRed;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.moveSpeed += 0.06f;
			player.spikedBoots += 2;
			player.maxMinions += 1;
			player.buffImmune[BuffID.Webbed] = true;
		}
	}
}