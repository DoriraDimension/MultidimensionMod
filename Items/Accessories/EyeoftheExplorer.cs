using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Face)]
	public class EyeoftheExplorer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of the Explorer");
			Tooltip.SetDefault("A true adventurer can sense traps and danger.\nOne of the forbidden eyes.\nYou can see danger sources.");
			DisplayName.AddTranslation(GameCulture.German, "Auge des Erkunders");
			Tooltip.AddTranslation(GameCulture.German, "Ein wahrer Abenteurer kann Fallen und Gefahren spüren.\nEins der verbotenen Augen.\nDu kannst jetzt Gefahrenquellen sehen.");
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
			player.dangerSense = true;
		}
	}
}