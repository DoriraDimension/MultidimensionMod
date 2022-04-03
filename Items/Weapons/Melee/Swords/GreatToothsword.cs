using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class GreatToothsword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Skeletal Greatsword");
			Tooltip.SetDefault("Ever thought about taking a skeleton and force it into a blade shape, well here you go.");
			DisplayName.AddTranslation(GameCulture.German, "Skelett Großschwert");
			Tooltip.AddTranslation(GameCulture.German, "Jemals darüber nachgedacht ein Skelett zu nehmen und in eine Klingenform zu zwingen, nun bitte schön.");
		}

		public override void SetDefaults()
		{
			item.damage = 83;
			item.melee = true;
			item.width = 78;
			item.height = 82;
			item.useTime = 29;
			item.useAnimation = 29;
			item.useStyle = 1;
			item.knockBack = 4;
			item.autoReuse = true;
			item.value = Item.sellPrice(gold: 2);
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileID.BoneGloveProj;
			item.shootSpeed = 10f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BoneSword);
			recipe.AddIngredient(ItemID.Bone, 150);
			recipe.AddIngredient(ItemID.BoneFeather);
			recipe.AddTile(300);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}