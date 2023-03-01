using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class StinkyPaste : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 28;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 6);
			Item.rare = ItemRarityID.Green;
			Item.buffType = (BuffID.Stinky);
			Item.buffTime = 14400;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Summon) += 0.06f;
		}
	}
}