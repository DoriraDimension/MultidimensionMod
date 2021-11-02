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
			DisplayName.AddTranslation(GameCulture.German, "Spinnenfluch");
			Tooltip.AddTranslation(GameCulture.German, "Ein verfluchtes Artefakt gefunden in den Spinnenhöhlen. \nErhöht Bewegungsgeschwindigkeit um 10% und gibt +1 Günstling Slot. \nDu kannst an Wänden kleben wie eine Spinne.");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 34;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 3);
			item.rare = ItemRarityID.LightRed;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.moveSpeed += 0.10f;
			player.spikedBoots += 2;
			player.maxMinions += 1;
		}
	}
}