using MultidimensionMod.Items.Materials;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class MandibleMetalBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mandible Metal Bow");
			Tooltip.SetDefault("A bow that was restored from old relics, its a metal base reinforced with Antlion Mandibles.");
			DisplayName.AddTranslation(GameCulture.German, "Mandible Metall Bogen");
			Tooltip.AddTranslation(GameCulture.German, "Ein Bogen der aus alten Relikten restauriert wurde, es ist eine Metall BAsis verstärkt mit Ameisenlöwn Kiefern.");
		}

		public override void SetDefaults()
		{
			item.damage = 19;
			item.ranged = true;
			item.width = 22;
			item.height = 38;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = Item.sellPrice(silver: 34);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 12f;
			item.useAmmo = AmmoID.Arrow;
			item.crit = 2;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<OldDustyBowMiddlePiece>());
			recipe.AddIngredient(ModContent.ItemType<OldDustyBowArm>());
			recipe.AddIngredient(ItemID.AntlionMandible, 2);
			recipe.AddTile(377);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}