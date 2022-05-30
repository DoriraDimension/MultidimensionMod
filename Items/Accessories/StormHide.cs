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
			DisplayName.SetDefault("Storm Hide");
			Tooltip.SetDefault("The rubbery hide of stormy Eels makes them immune to the thunder that strikes down during storms.\nThe storm is a untamed force of nature and so are these creatures.\nGives immunity to electrified.\nIncreases movement speed by 8%, damage by 5% and defense by 5 when it is raining.");
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