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
			Tooltip.SetDefault("Always be careful when you explore a new area. \nYou can see danger sources.");
			DisplayName.AddTranslation(GameCulture.German, "Auge des Erkunders");
			Tooltip.AddTranslation(GameCulture.German, "Sei immer vorsichtig wenn du ein neues Gebiet erkundest. \nDu kannst jetzt Gefahrenquellen sehen.");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 16;
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