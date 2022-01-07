using MultidimensionMod.Items.Materials;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class DarkshotBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkshot Bow");
			Tooltip.SetDefault("A dark matter bow from the dark edge of the cosmos.");
			DisplayName.AddTranslation(GameCulture.German, "Dunkelschuss Bogen");
			Tooltip.AddTranslation(GameCulture.German, "Ein dunkle materie Bogen vom dunklen teil des Kosmos.");
		}

		public override void SetDefaults()
		{
			item.damage = 18;
			item.ranged = true;
			item.width = 24;
			item.height = 30;
			item.useTime = 27;
			item.useAnimation = 27;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = Item.sellPrice(silver: 7);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 15f;
			item.useAmmo = AmmoID.Arrow;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 10);
			recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}