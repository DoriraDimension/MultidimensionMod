using MultidimensionMod.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class EyeofDesire : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of the Greed");
			Tooltip.SetDefault("A true greed can find every treasure.\nOne of the forbidden eyes.\nYour greedy eyes can now see treasures.\nHas a chance to inflict the Cursed debuff when you get it");
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
			player.findTreasure = true;
			player.GetModPlayer<MDPlayer>().DesireEye = true;
		}
	}
}