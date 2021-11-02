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
			DisplayName.AddTranslation(GameCulture.German, "Königlicher gürtel");
			Tooltip.AddTranslation(GameCulture.German, "Erhöht Sprunghöhe und Sprunggeschwindigkeit um 50%% \nDer Gürtel des Schleimkönigs, wenn er Beine hätte. ");
		}

		public override void SetDefaults()
		{
			item.width = 48;
			item.height = 28;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 5);
			item.rare = ItemRarityID.Blue;
			item.defense = 3;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.jumpSpeedBoost += 0.50f;
			player.jumpBoost = true;
			Player.jumpHeight += 3;
		}
	}
}