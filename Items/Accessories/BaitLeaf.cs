using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class BaitLeaf : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bait Leaf");
			Tooltip.SetDefault("A aromatic leaf from another dimension, its strong scent can even lure in bigger predators.\nThese might be useful to attract helpers, but be aware of possible stronger foes getting attracted too.\nGives +1 minion slot");
			DisplayName.AddTranslation(GameCulture.German, "Köderblatt");
			Tooltip.AddTranslation(GameCulture.German, "Ein aromatisches Blatt aus einer anderen Dimension, sein starker Geruch kann selbst große Raubtiere anlocken.\nDiese Blätter mögen zwar hilfreich sein um Helfer anzulocken, aber sei vorsichtig das keine möglichen stärkeren Feinde angelockt werden.\nGibt +1 Minion Slot.");
		}

		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 30;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 3);
			item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions += 1;
		}
	}
}