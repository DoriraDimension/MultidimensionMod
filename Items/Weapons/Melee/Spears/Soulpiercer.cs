using MultidimensionMod.Projectiles.Spears;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class Soulpiercer : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Doesnt affect soulless beings.");
			DisplayName.AddTranslation(GameCulture.German, "Seelen Durchbohrer");
			Tooltip.AddTranslation(GameCulture.German, "Wirkt sich nicht auf seelenlose Wesen aus.");
		}

		public override void SetDefaults() {
			item.damage = 15;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 28;
			item.useTime = 28;
			item.shootSpeed = 3.2f;
			item.knockBack = 7f;
			item.width = 54;
			item.height = 56;
			item.scale = 1f;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(silver: 15);

			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = false; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<SoulpiercerProj>();
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
