using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Waist)]
	public class RoyalBelt : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Royal Belt");
			Tooltip.SetDefault("Increases jump height and jump speed by 50%. \nThe King Slime's belt, if he had legs.");
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 30;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 5);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 3;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.jumpSpeedBoost += 0.50f;
			Player.jumpHeight += 10;
		}
	}
}