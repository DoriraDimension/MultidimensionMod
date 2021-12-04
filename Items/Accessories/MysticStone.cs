using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class MysticStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mystic Stone");
			Tooltip.SetDefault("This stone pulses with magical energy and increases max mana by 40.");
			DisplayName.AddTranslation(GameCulture.German, "Mystischer Stein");
			Tooltip.AddTranslation(GameCulture.German, "Dieser Stein pulsiert mit magischer Energy und erhöht maximales Mana um 40.");
		}

		public override void SetDefaults()
		{
			item.width = 44;
			item.height = 34;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.LightRed;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statManaMax2 += 40;
		}
	}
}