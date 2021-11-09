using MultidimensionMod.Projectiles.Spears;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class ShiningRejection : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Reject your enemies until they go away.");
			DisplayName.AddTranslation(GameCulture.German, "Scheinende Ablehnung");
			Tooltip.AddTranslation(GameCulture.German, "Lehne deine Gegner ab bis sie verschwinden.");
		}

		public override void SetDefaults()
		{
			item.damage = 14;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 30;
			item.useTime = 30;
			item.shootSpeed = 3.7f;
			item.knockBack = 6.5f;
			item.width = 64;
			item.height = 64;
			item.scale = 1f;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(silver: 10);
			item.melee = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.autoReuse = false;
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<ShiningRejectionProj>();
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumBar, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
