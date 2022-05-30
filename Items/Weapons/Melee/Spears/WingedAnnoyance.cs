using MultidimensionMod.Projectiles.Melee.Spears;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class WingedAnnoyance : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Winged Annoyance");
			Tooltip.SetDefault("Annoy your enemies until they go away.");
		}

		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 33;
			Item.useTime = 33;
			Item.shootSpeed = 4.1f;
			Item.knockBack = 7f;
			Item.width = 56;
			Item.height = 56;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 2);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = false;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<WingedAnnoyanceProj>();
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.LeadBar, 15)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}
