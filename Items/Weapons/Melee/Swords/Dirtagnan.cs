using MultidimensionMod.Projectiles.Melee.Swords;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class Dirtagnan : ModItem
	{
		public override void SetStaticDefaults() 
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 6;
			Item.DamageType = DamageClass.Melee;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.knockBack = 1.5f;
			Item.value = Item.sellPrice(0, 0, 0, 4);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.crit = 10;
			Item.shoot = ModContent.ProjectileType<DirtagnanProj>();
			Item.shootSpeed = 2.1f;
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
			.AddIngredient(ItemID.DirtBlock, 100)
			.AddRecipeGroup(RecipeGroupID.IronBar, 5)
			.AddIngredient(ItemID.GoldBar, 2)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}