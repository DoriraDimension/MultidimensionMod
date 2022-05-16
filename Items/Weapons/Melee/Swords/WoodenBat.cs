using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class WoodenBat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wooden Bat");
			Tooltip.SetDefault("Le Bonk\nLow chance to confuse enemies on hit.");
		}

		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Melee;
			Item.width = 52;
			Item.height = 52;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.knockBack = 4;
			Item.value = Item.buyPrice(copper: 5);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;

		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddRecipeGroup("Wood", 50)
			.AddTile(18)
			.Register();
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextFloat() < .1500f)
				target.AddBuff(BuffID.Confused, 180);
		}
	}
}