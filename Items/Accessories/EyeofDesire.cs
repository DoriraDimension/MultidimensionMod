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