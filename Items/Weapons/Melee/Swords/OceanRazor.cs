using MultidimensionMod.Projectiles.Melee.Swords;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class OceanRazor : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ocean Razor");
			// Tooltip.SetDefault("This is definetily a knife with water thats salty.");
		}

		public override void SetDefaults()
		{
			Item.damage = 24;
			Item.DamageType = DamageClass.Melee;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 13;
			Item.useAnimation = 13;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.knockBack = 1.5f;
			Item.value = Item.sellPrice(copper: 45);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.shoot = ModContent.ProjectileType<OceanRazorStab>();
			Item.shootSpeed = 4f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Starfish, 4)
			.AddIngredient(ItemID.Coral, 9)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}