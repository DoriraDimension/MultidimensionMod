using MultidimensionMod.Projectiles.Melee.Spears;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class RaiderLance : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 35;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 36;
			Item.useTime = 36;
			Item.shootSpeed = 3.2f;
			Item.knockBack = 7f;
			Item.width = 54;
			Item.height = 56;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(0, 0, 70, 0);
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
			.AddIngredient(ModContent.ItemType<AbyssalHellstoneBar>(), 12)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}
