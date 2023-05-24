using MultidimensionMod.Projectiles.Melee.Spears;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class WingedNuisance : ModItem
	{
		public override void SetStaticDefaults() 
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.damage = 9;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 33;
			Item.useTime = 33;
			Item.shootSpeed = 4.1f;
			Item.knockBack = 7f;
			Item.width = 56;
			Item.height = 56;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(0, 0, 30, 0);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true; 
			Item.noUseGraphic = true; 
			Item.autoReuse = false; 
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<WingedNuisanceProj>();
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.IronBar, 15)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}
