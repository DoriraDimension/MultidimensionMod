using MultidimensionMod.Projectiles.SwordProjectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class TheFly : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Fly");
			Tooltip.SetDefault("Swarm your foes with flies like flies swarm a rotting corpse.");
			DisplayName.AddTranslation(GameCulture.German, "Die Fliege");
			Tooltip.AddTranslation(GameCulture.German, "Umschwärme deine Gegner mit Fliegen, wie Fliegen eine verottende Leiche umschwärmen");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.BeamSword);
			item.shootSpeed *= 0.75f;
			item.width = 38;
			item.height = 38;
			item.damage = 18;
			item.melee = true;
			item.value = Item.sellPrice(silver: 15);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;

		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = ModContent.ProjectileType<DecayFlyFriendly>();
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBroadsword);
			recipe.AddIngredient(ItemID.ShadowScale, 5);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LeadBroadsword);
			recipe.AddIngredient(ItemID.ShadowScale, 5);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}