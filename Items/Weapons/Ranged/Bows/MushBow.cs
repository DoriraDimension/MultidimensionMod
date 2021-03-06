using MultidimensionMod.Items.Materials;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class MushBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mush Bow");
			Tooltip.SetDefault("A bow made of juicy fungi flesh.");
			DisplayName.AddTranslation(GameCulture.German, "Mush Bogen");
			Tooltip.AddTranslation(GameCulture.German, "Ein Bogen der aus saftigem Pilzfleisch gemacht wurde.");
		}

		public override void SetDefaults()
		{
			item.damage = 18;
			item.ranged = true;
			item.width = 24;
			item.height = 42;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = Item.sellPrice(silver: 3);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 6f;
			item.useAmmo = AmmoID.Arrow;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Mushmatter>(), 14);
			recipe.AddIngredient(ItemID.GlowingMushroom, 20);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}