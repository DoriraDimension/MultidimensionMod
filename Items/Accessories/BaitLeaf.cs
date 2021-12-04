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
			Tooltip.SetDefault("A aromatic leaf, perfect to get in more followers.\nGives +1 minion slot");
			DisplayName.AddTranslation(GameCulture.German, "Köderblatt");
			Tooltip.AddTranslation(GameCulture.German, "Ein aromatisches Blatt, perfekt um neue anhänger zu bekommen.\nGibt +1 Minion Slot.");
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