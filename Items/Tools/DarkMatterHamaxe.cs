using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Tools
{
	public class DarkMatterHamaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Matter Hamaxe");
			Tooltip.SetDefault("A dark matter hamaxe that could cut down dark trees if they would exist.");
		}

		public override void SetDefaults()
		{
			Item.damage = 26;
			Item.DamageType = DamageClass.Melee;
			Item.width = 56;
			Item.height = 50;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.axe = 30;
			Item.hammer = 70;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(silver: 6);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 11)
			.AddTile(26)
			.Register();
		}
	}
}
