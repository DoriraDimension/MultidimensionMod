using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Others
{
	public class SmileySmile : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Smiley's Dark Blast");
			Tooltip.SetDefault("A smiling stare.\nShoots dark energy beams that explode on hit");
		}

		public override void SetDefaults()
		{
			Item.damage = 36;
			Item.DamageType = DamageClass.Magic;
			Item.width = 28;
			Item.height = 26;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.mana = 5;
			Item.knockBack = 1;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.DD2_SonicBoomBladeSlash;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<DarkBolt>();
			Item.shootSpeed = 35f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<SmileySoulshard>())
			.AddIngredient(ModContent.ItemType<Dimensium>(), 10)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}
