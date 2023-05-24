using MultidimensionMod.Projectiles.Melee.Spears;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class RadiantAcceptance : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 46;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 23;
			Item.useTime = 23;
			Item.shootSpeed = 5.0f;
			Item.knockBack = 7.5f;
			Item.width = 74;
			Item.height = 74;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(0, 0, 95, 0);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<Acceptance>();
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<GildedRejection>())
			.AddIngredient(ItemID.GoldDust, 5)
			.AddIngredient(ItemID.SoulofLight, 10)
			.AddIngredient(ModContent.ItemType<Dimensium>(), 15)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();

			CreateRecipe()
			.AddIngredient(ModContent.ItemType<ShiningRejection>())
			.AddIngredient(ItemID.GoldDust, 5)
			.AddIngredient(ItemID.SoulofLight, 10)
			.AddIngredient(ModContent.ItemType<Dimensium>(), 15)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}