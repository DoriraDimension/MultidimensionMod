using MultidimensionMod.Projectiles.Melee.Spears;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class PokingLoser : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Poking Loser");
			Tooltip.SetDefault("Poke your enemies until they go away.");
		}

		public override void SetDefaults()
		{
			Item.damage = 7;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 35;
			Item.useTime = 35;
			Item.shootSpeed = 4.6f;
			Item.knockBack = 6.5f;
			Item.width = 48;
			Item.height = 48;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(copper: 80);

			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = false;

			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<PokingLoserProj>();
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.TinBar, 15)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}
