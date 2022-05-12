using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class CalamityRing : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Calamity Ring");
			Tooltip.SetDefault("This ring contains the eye of a calamitous dragon and doubles all damage taken.\nOnly a fool would consider wearing such a cursed artifact.");
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 24;
			Item.accessory = true;
			Item.value = Item.sellPrice(copper: 0);
			Item.rare = ItemRarityID.Red;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.endurance -= 1f;

		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddTile(26)
			.Register();
		}
	}
}