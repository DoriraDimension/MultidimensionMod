using MultidimensionMod.Projectiles.Melee.Spears;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class ShiningRejection : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Shining Rejection");
			// Tooltip.SetDefault("Reject your enemies until they go away.");
		}

		public override void SetDefaults()
		{
			Item.damage = 14;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.shootSpeed = 3.7f;
			Item.knockBack = 6.5f;
			Item.width = 64;
			Item.height = 64;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 10);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = false;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<ShiningRejectionProj>();
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.PlatinumBar, 15)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}
