using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Melee.Swords;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class XiphiasGladius : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 53;
			Item.DamageType = DamageClass.Melee;
			Item.width = 54;
			Item.height = 58;
			Item.useTime = 5;
			Item.useAnimation = 5;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.knockBack = 3;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(0, 3, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.crit = 11;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.shoot = ModContent.ProjectileType<XiphiasGladiusStab>();
			Item.shootSpeed = 4.50f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
		    .AddIngredient(ModContent.ItemType<OceanRazor>())
			.AddIngredient(ModContent.ItemType<TidalQuartz>(), 7)
			.AddIngredient(ItemID.HallowedBar, 15)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}