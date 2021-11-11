using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Vanity
{
	[AutoloadEquip(EquipType.Front)]
	public class DarkCloak : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lonely Warrior's Cloak");
			Tooltip.SetDefault("The cloak of a lonely dark warrior.");
			DisplayName.AddTranslation(GameCulture.German, "Umhang des einsamen Kriegers");
			Tooltip.AddTranslation(GameCulture.German, "Der Umhang eines einsamen dunklen Kriegers.");
		}

		public override void SetDefaults()
		{
			item.width = 48;
			item.height = 46;
			item.accessory = true;
			item.vanity = true;
			item.rare = ItemRarityID.LightRed;
			item.value = Item.sellPrice(silver: 89);
		}
	}
}
