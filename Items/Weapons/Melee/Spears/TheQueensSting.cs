using MultidimensionMod.Projectiles.Melee.Spears;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using MultidimensionMod.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class TheQueensSting : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Queen's Sting");
			Tooltip.SetDefault("Explodes into bees and poison clouds on hit.");
		}

		public override void SetDefaults()
		{
			Item.damage = 23;
			Item.DamageType = DamageClass.Melee;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 16;
			Item.useTime = 25;
			Item.knockBack = 6.5f;
			Item.crit = 6;
			Item.width = 70;
			Item.height = 70;
			Item.scale = 1f;
			Item.rare = ModContent.RarityType<BossSoulItem>();
			Item.value = Item.sellPrice(gold: 6);
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<QueensSting>();
			Item.shootSpeed = 4.5f;
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<BeeSoul>())
			.AddIngredient(ModContent.ItemType<Dimensium>(), 10)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}