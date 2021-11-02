using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class CursedDesert : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Desert");
			Tooltip.SetDefault("A sword forged in the dark caves of the desert by a long shattered cult, it slows down enemies on hit for 2 seconds.");
			DisplayName.AddTranslation(GameCulture.German, "Verfluchte Wüste");
			Tooltip.AddTranslation(GameCulture.German, "Ein Schwert das in den dunklen Höhlen der Wüste von einem lange zerbrochenen Kult geschmiedet wurde, es verlangsamt gegner wenn getroffen für 2 Sekunden.");
		}

		public override void SetDefaults()
		{
			item.damage = 23;
			item.melee = true;
			item.width = 46;
			item.height = 46;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 3;
			item.autoReuse = true;
			item.value = Item.sellPrice(silver: 17);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.crit = 1;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Slow, 120);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumBroadsword);
			recipe.AddIngredient(ItemID.Deathweed, 2);
			recipe.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>(), 4);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldBroadsword);
			recipe.AddIngredient(ItemID.Deathweed, 2);
			recipe.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>(), 4);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}