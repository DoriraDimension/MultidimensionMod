using MultidimensionMod.Projectiles.Melee.Spears;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class GrassSpear : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 19;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 31;
			Item.useTime = 31;
			Item.shootSpeed = 3.9f;
			Item.knockBack = 7f;
			Item.width = 54;
			Item.height = 56;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(0, 0, 60, 0);
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
