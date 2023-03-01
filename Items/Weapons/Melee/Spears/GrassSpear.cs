using MultidimensionMod.Projectiles.Melee.Spears;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class GrassSpear : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Jungle Leaf Spear");
			// Tooltip.SetDefault("Shoots small leafes");
		}

		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 24;
			Item.useTime = 24;
			Item.shootSpeed = 3.9f;
			Item.knockBack = 7f;
			Item.width = 54;
			Item.height = 56;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 15);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<GrassSpearProj>();
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.RichMahogany, 20)
			.AddIngredient(ItemID.Vine, 3)
			.AddIngredient(ItemID.JungleSpores, 6)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}
