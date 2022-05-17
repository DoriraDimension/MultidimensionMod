using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class DarkMatterImpacter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Matter Impacter");
			Tooltip.SetDefault("A massive dark matter sword used to hit enemies with a hefty swing.");
		}

		public override void SetDefaults()
		{
			Item.damage = 48;
			Item.DamageType = DamageClass.Melee;
			Item.width = 86;
			Item.height = 86;
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.useStyle = 1;
			Item.knockBack = 8;
			Item.value = Item.sellPrice(silver: 23);
			Item.rare = 3;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 14)
			.AddTile(26)
			.Register();
		}
	}
}