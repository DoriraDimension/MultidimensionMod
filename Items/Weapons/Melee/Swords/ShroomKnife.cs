using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class ShroomKnife : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shroom Knife");
			Tooltip.SetDefault("A small knife made of juicy fungus flesh.");
			DisplayName.AddTranslation(GameCulture.German, "Shroom Messer");
			Tooltip.AddTranslation(GameCulture.German, "Ein kleines Messer das aus saftigem Pilzfleisch gemacht wurde.");
		}

		public override void SetDefaults()
		{
			item.damage = 19;
			item.melee = true;
			item.width = 34;
			item.height = 36;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 3;
			item.knockBack = 2;
			item.value = Item.sellPrice(silver: 4);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Mushmatter>(), 12);
			recipe.AddIngredient(ItemID.GlowingMushroom, 16);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}