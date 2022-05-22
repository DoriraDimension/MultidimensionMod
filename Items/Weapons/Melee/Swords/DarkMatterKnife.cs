using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class DarkMatterKnife : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Matter Knife");
			Tooltip.SetDefault("A small dark matter knife to stab your enemies with dark powers.");
		}

		public override void SetDefaults()
		{
			Item.damage = 38;
			Item.DamageType = DamageClass.Melee;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = 3;
			Item.knockBack = 1f;
			Item.value = Item.sellPrice(silver: 7);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.crit = 5;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 9)
			.AddTile(26)
			.Register();
		}
	}
}