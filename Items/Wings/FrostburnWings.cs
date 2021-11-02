using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace MultidimensionMod.Items.Wings
{
	[AutoloadEquip(EquipType.Wings)]
	public class FrostburnWings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frostburn Wings");
			Tooltip.SetDefault("These wings are hot and cold at the same time, seems cool.");
			DisplayName.AddTranslation(GameCulture.German, "Frostbrand Flügel");
			Tooltip.AddTranslation(GameCulture.German, "Diese Flügel sind heiß und kalt zugleich, scheint cool zu sein.");
		}

		public override void SetDefaults()
		{
			item.width = 42;
			item.height = 20;
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.LightRed;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 130;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.40f;
			ascentWhenRising = 0.10f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.100f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 6f;
			acceleration *= 2.5f;
		}
	}
}