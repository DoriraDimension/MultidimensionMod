using MultidimensionMod.Projectiles.Magic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Staffs
{
	public class OceanTrident : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ocean Trident");
			// Tooltip.SetDefault("Ball penetrator.");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 19;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 6;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 54;
			Item.useAnimation = 54;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(copper: 34);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Wave>();
			Item.shootSpeed = 15f;
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