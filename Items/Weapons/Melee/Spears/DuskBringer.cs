using MultidimensionMod.Projectiles.Melee.Spears;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class DuskBringer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dusk Bringer");
			Tooltip.SetDefault("Shoots slowly deccelerating crescents from the spear");
		}

		public override void SetDefaults()
		{
			Item.damage = 34;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 24;
			Item.useTime = 24;
			Item.shootSpeed = 4.4f;
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
			Item.shoot = ModContent.ProjectileType<DuskBringerProj>();
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.TheRottedFork)
			.AddIngredient(ItemID.DarkLance)
			.AddIngredient(ModContent.ItemType<GrassSpear>())
			.AddIngredient(ModContent.ItemType<MoltenLance>())
			.AddTile(TileID.Anvils)
			.Register();

			CreateRecipe()
			.AddIngredient(ModContent.ItemType<Soulpiercer>())
			.AddIngredient(ItemID.DarkLance)
			.AddIngredient(ModContent.ItemType<GrassSpear>())
			.AddIngredient(ModContent.ItemType<MoltenLance>())
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}
