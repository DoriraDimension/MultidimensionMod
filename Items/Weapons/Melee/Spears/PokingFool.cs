using MultidimensionMod.Projectiles.Spears;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Spears
{
	public class PokingFool : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Poke your enemies until they go away.");
			DisplayName.AddTranslation(GameCulture.German, "Pieksender Narr");
			Tooltip.AddTranslation(GameCulture.German, "Piekse deine Gegner bis sie verschwinden.");
		}

		public override void SetDefaults() {
			item.damage = 6;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 35;
			item.useTime = 35;
			item.shootSpeed = 4.6f;
			item.knockBack = 6.5f;
			item.width = 46;
			item.height = 46;
			item.scale = 1f;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(copper: 80);

			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = false; 

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<PokingFoolProj>();
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CopperBar, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
