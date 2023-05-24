using MultidimensionMod.Projectiles.Melee.Spears;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class Soulpiercer : ModItem
	{
		public override void SetStaticDefaults() 
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.damage = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 28;
			Item.useTime = 28;
			Item.shootSpeed = 3.2f;
			Item.knockBack = 7f;
			Item.width = 54;
			Item.height = 56;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(0, 0, 70, 0);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true; 
			Item.noUseGraphic = true; 
			Item.autoReuse = false; 
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<SoulpiercerProj>();
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.DemoniteBar, 15)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}
