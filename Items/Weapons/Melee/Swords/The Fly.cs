using MultidimensionMod.Projectiles.Melee.Swords;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class TheFly : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Fly");
			Tooltip.SetDefault("Swarm your foes with flies like flies swarm a rotting corpse.");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.BeamSword);
			Item.shootSpeed *= 0.75f;
			Item.width = 38;
			Item.height = 38;
			Item.damage = 18;
			Item.DamageType = DamageClass.Melee;
			Item.value = Item.sellPrice(silver: 15);
			Item.rare = ItemRarityID.Green;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<DecayFlyFriendly>();
			Item.shootSpeed = 10f;

		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.IronBroadsword)
			.AddIngredient(ItemID.ShadowScale, 5)
			.AddTile(16)
			.Register();

			CreateRecipe()
           .AddIngredient(ItemID.LeadBroadsword)
           .AddIngredient(ItemID.ShadowScale, 5)
           .AddTile(16)
           .Register();
		}
	}
}