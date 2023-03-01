using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Tomes
{
	public class SandBook : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Dune Chaser");
			// Tooltip.SetDefault("Old desert magic used by ancient magicians, it shoots a bouncing ball of sand.");
		}

		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 9;
			Item.width = 24;
			Item.height = 30;
			Item.useTime = 26;
			Item.useAnimation = 26;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 12);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<SandBallz>();
			Item.shootSpeed = 9f;
			Item.crit = 8;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>(), 5)
			.AddIngredient(ItemID.SandBlock, 25)
			.AddIngredient(ItemID.AntlionMandible, 2)
			.AddTile(16)
			.Register();
		}
	}
}
