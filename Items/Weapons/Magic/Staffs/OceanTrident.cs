using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Items.Placeables.Banners;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MultidimensionMod.Items.Accessories;

namespace MultidimensionMod.Items.Weapons.Magic.Staffs
{
	public class OceanTrident : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.staff[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<TridentBanner>();
        }

		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 6;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 54;
			Item.useAnimation = 54;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(0, 0, 36, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<SaltwaterBolt>();
			Item.shootSpeed = 32f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Starfish, 4)
			.AddIngredient(ItemID.Coral, 9)
			.AddIngredient(ItemID.WhitePearl)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}