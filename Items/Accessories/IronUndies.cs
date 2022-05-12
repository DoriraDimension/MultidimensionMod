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
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 16;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 5);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 5;
		}
	}
}