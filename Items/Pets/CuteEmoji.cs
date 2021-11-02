using MultidimensionMod.Buffs.Pets;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Pets
{
	public class CuteEmoji : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cute Emoji");
			Tooltip.SetDefault("Summons Smiley's adopted son.");
			DisplayName.AddTranslation(GameCulture.German, "Niedlicher Emoji");
			Tooltip.AddTranslation(GameCulture.German, "Beschw�rt Smiley's adoptierten Sohn.");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = ModContent.ProjectileType<Projectiles.Pets.SmileyJr>();
			item.buffType = ModContent.BuffType<SmileyJrBuff>();
			item.width = 32;
			item.height = 32;
			item.value = Item.sellPrice(silver: 25);
			item.rare = ItemRarityID.Orange;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Materials.DarkMatterClump>(), 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}