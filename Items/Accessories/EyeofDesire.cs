using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class EyeofDesire : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of Desire");
			Tooltip.SetDefault("The true greed can find every treasure. \nYour greedy eyes can now see treasures.");
			DisplayName.AddTranslation(GameCulture.German, "Auge des Verlangens");
			Tooltip.AddTranslation(GameCulture.German, "Ein wahrer Gierschlund kann jeden Schatz finden. \nDeine gierigen Augen können jetzt Schätze sehen.");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 20;
			item.accessory = true;
			item.value = Item.sellPrice(copper: 60);
			item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.findTreasure = true;
		}
	}
}