using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class StormHide : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 18;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Lime;
			Item.defense = 5;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.buffImmune[BuffID.Electrified] = true;
			if (Main.raining)
            {
				player.moveSpeed += 0.08f;
				player.GetDamage(DamageClass.Generic) += 0.05f;
				player.statDefense += 5;
            }
		}
	}
}