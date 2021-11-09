using MultidimensionMod.Projectiles.Spears;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class WingedAnnoyance : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Annoy your enemies until they go away.");
			DisplayName.AddTranslation(GameCulture.German, "Geflügelte Belästigung");
			Tooltip.AddTranslation(GameCulture.German, "Nerve deine gegner bis sie verschwinden");
		}

		public override void SetDefaults()
		{
			item.damage = 10;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 33;
			item.useTime = 33;
			item.shootSpeed = 4.1f;
			item.knockBack = 7f;
			item.width = 56;
			item.height = 56;
			item.scale = 1f;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(silver: 2);

			item.melee = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.autoReuse = false;

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<WingedAnnoyanceProj>();
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LeadBar, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
