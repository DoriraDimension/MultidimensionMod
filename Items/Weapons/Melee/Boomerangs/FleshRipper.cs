using MultidimensionMod.Projectiles.Melee.Boomerangs;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Boomerangs
{
	public class FleshRipper : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 26;
			Item.DamageType = DamageClass.Melee;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.width = 30;
			Item.height = 42;
			Item.autoReuse = true;
			Item.useTime = 45;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.useAnimation = 45;
            Item.knockBack = 3f;
            Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.Green;
			Item.shoot = ModContent.ProjectileType<FleshRipperProj>();
			Item.shootSpeed = 14;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<OldStainedScythe>())
			.AddIngredient(ItemID.TissueSample, 20)
			.AddTile(TileID.SharpeningStation)
			.Register();
		}
	}
}