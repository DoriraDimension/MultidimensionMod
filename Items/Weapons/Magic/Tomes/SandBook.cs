using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Items.Materials;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Tomes
{
	public class SandBook : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dune Chaser");
			Tooltip.SetDefault("Old desert magic used by ancient magicians, it shoots a bouncing ball of sand.");
			DisplayName.AddTranslation(GameCulture.German, "Dünen Verfolger");
			Tooltip.AddTranslation(GameCulture.German, "Alte Wüstenmagie die von uralten Magiern benutzt wurde, es schießt einen hüpfenden Sandball.");
		}

		public override void SetDefaults()
		{
			item.damage = 16;
			item.magic = true;
			item.mana = 9;
			item.width = 24;
			item.height = 30;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = Item.sellPrice(silver: 12);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<SandBallz>();
			item.shootSpeed = 9f;
			item.crit = 8;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>(), 5);
			recipe.AddIngredient(ItemID.SandBlock, 25);
			recipe.AddIngredient(ItemID.AntlionMandible, 2);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
