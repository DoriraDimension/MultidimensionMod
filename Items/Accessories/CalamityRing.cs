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
			DisplayName.AddTranslation(GameCulture.German, "Ring des Unheils");
			Tooltip.AddTranslation(GameCulture.German, "Dieser Ring enthält das Auge eines Drachen des Unheil und verdoppelt allen erhaltenen Schaden.\nNur ein Narr würde solch ein verfluchtes Artefakt tragen.");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 24;
			item.accessory = true;
			item.value = Item.sellPrice(copper: 0);
			item.rare = ItemRarityID.Red;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.endurance -= 1f;

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}