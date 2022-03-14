using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Face)]
	public class EyeofDesire : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of Desire");
			Tooltip.SetDefault("A true greed can find every treasure.\nOne of the forbidden eyes.\nYour greedy eyes can now see treasures.");
			DisplayName.AddTranslation(GameCulture.German, "Auge des Verlangens");
			Tooltip.AddTranslation(GameCulture.German, "Ein wahrer Gierschlund kann jeden Schatz finden.\nEins der verbotenen Augen.\nDeine gierigen Augen können jetzt Schätze sehen.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
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