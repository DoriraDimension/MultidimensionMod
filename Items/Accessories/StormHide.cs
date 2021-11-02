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
			Tooltip.SetDefault("Gives immunity to electrified. \nIncreases movement speed by 8%, damage by 5% and defense by 5 when it is raining.");
			DisplayName.AddTranslation(GameCulture.German, "Sturmhaut");
			Tooltip.AddTranslation(GameCulture.German, "Gibt Immunität gegen den Elektrifiziert debuff. \nErhöht Bewegungsgeschwindigkeit um 8%m Schaden um 5% und verteidigung um 5 wenn es regnet.");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 22;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 3);
			item.rare = ItemRarityID.Lime;
			item.defense = 5;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.buffImmune[BuffID.Electrified] = true;
			if (Main.raining)
            {
				player.moveSpeed += 0.08f;
				player.allDamage += 0.05f;
				player.statDefense += 5;
            }
		}
	}
}