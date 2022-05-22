using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class FishronCleaver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fishron Cleaver");
			Tooltip.SetDefault("A big cleaver, designed like a mutated ocean creature, it was seen as a sign of strength.\nReleases typhoons on enemy hits.");
		}

		public override void SetDefaults()
		{
			Item.damage = 83;
			Item.DamageType = DamageClass.Melee;
			Item.width = 98;
			Item.height = 94;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.crit = 9;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			Projectile.NewProjectile(Item.GetSource_ItemUse(player.HeldItem), target.position.X + 0f + (float)Main.rand.Next(0, 151), player.position.Y + 0f, 0f, -6f, ProjectileID.Typhoon, (int)((double)((float)Item.damage) * 0.5), 0f, Main.myPlayer);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<FishCleaver>())
			.AddIngredient(ModContent.ItemType<TidalQuartz>(), 15)
			.AddCondition(Recipe.Condition.NearWater)
			.Register();
		}
	}
}