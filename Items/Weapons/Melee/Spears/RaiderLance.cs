using MultidimensionMod.Projectiles.Melee.Spears;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class RaiderLance : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Raider Drakeslayer");
			// Tooltip.SetDefault("Inflicts Drakeblood Poison.");
		}

		public override void SetDefaults()
		{
			Item.damage = 27;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 24;
			Item.useTime = 24;
			Item.shootSpeed = 3.2f;
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
			Item.shoot = ModContent.ProjectileType<RaiderLanceProj>();
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<VikingPolearm>())
			.AddIngredient(ItemID.Bone, 12)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}
