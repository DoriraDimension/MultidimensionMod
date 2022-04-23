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
		}

		public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 46;
			Item.accessory = true;
			Item.vanity = true;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(silver: 89);
		}
	}
}
