using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class DormantKing : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dormant King");
			Tooltip.SetDefault("A blade forged by a long shattered cult who worshipped a unknown deity, it slows enemies down for 5 seconds.");
			DisplayName.AddTranslation(GameCulture.German, "Ruhender König");
			Tooltip.AddTranslation(GameCulture.German, "Ein Schwert das von einem lange zerbrochenen Kult geschmiedet wurde die eine unbekannte Gottheit verehrten, es verlangsamt gegner wenn getroffen für 5 Sekunden.");
		}

		public override void SetDefaults()
		{
			item.damage = 56;
			item.melee = true;
			item.width = 46;
			item.height = 46;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = 1;
			item.knockBack = 4;
			item.autoReuse = true;
			item.value = Item.sellPrice(silver: 84);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.crit = 1;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Slow, 320);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<CursedDesert>());
			recipe.AddIngredient(ItemID.AncientBattleArmorMaterial);
			recipe.AddRecipeGroup("AdamantiteBars", 5);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}