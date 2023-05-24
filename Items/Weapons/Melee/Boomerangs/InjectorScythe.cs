using MultidimensionMod.Projectiles.Melee.Boomerangs;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Boomerangs
{
	public class InjectorScythe : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 65;
			Item.DamageType = DamageClass.Melee;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.width = 38;
			Item.height = 52;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.value = Item.sellPrice(0, 2, 40, 0);
			Item.rare = ItemRarityID.LightRed;
			Item.shoot = ModContent.ProjectileType<InjectorScytheProj>();
			Item.shootSpeed = 16;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<FleshRipper>())
			.AddIngredient(ItemID.Ichor, 8)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}