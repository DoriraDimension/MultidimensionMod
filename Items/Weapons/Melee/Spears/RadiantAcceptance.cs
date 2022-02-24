using MultidimensionMod.Projectiles.Spears;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class RadiantAcceptance : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Radiant Acceptance");
			Tooltip.SetDefault("The awakened form of a rejective spear.\nAfter decades of rejection, you are finally accepted, now make the best of it.");
			DisplayName.AddTranslation(GameCulture.German, "Strahlende Akzeptanz");
			Tooltip.AddTranslation(GameCulture.German, "Die erwachte Form eines ablehnenden Speers.\nNach Dekaden der Ablehnung, du wurdest endlich akzeptiert, mach das beste drauß.");
		}

		public override void SetDefaults()
		{
			item.damage = 46;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 23;
			item.useTime = 23;
			item.shootSpeed = 5.0f;
			item.knockBack = 7.5f;
			item.width = 74;
			item.height = 74;
			item.scale = 1f;
			item.rare = ItemRarityID.LightRed;
			item.value = Item.sellPrice(gold: 1);
			item.melee = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<Acceptance>();
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<GildedRejection>());
			recipe.AddIngredient(ItemID.GoldDust, 5);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>(), 15);
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}