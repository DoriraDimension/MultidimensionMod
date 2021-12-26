using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Waist)]
	public class IronUndies : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Iron Undies");
			Tooltip.SetDefault("How can you even wear this?");
			DisplayName.AddTranslation(GameCulture.German, "Eisen Unterhose");
			Tooltip.AddTranslation(GameCulture.German, "Wie kannst du das überhaupt tragen?");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 16;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 5);
			item.rare = ItemRarityID.Blue;
			item.defense = 5;
		}
	}
}