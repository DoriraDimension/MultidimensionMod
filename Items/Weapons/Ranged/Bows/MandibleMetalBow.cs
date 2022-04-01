using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Ranged;
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
			DisplayName.SetDefault("Antlion Mandible Bow");
			Tooltip.SetDefault("A bow that was restored from old relics, its a metal base reinforced with Antlion Mandibles.\nShoots two Mandibles.");
			DisplayName.AddTranslation(GameCulture.German, "Mandible Metall Bogen");
			Tooltip.AddTranslation(GameCulture.German, "Ein Bogen der aus alten Relikten restauriert wurde, es ist eine Metall BAsis verstärkt mit Ameisenlöwn Kiefern.\nSchießt zwei Mandibeln.");
		}

		public override void SetDefaults()
		{
			item.damage = 19;
			item.ranged = true;
			item.width = 22;
			item.height = 34;
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
			item.shootSpeed = 8f;
			item.useAmmo = AmmoID.Arrow;
			item.crit = 2;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 2; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
				int nah = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<Mandible>(), damage, knockBack, player.whoAmI);
				Main.projectile[nah].noDropItem = true;
			}
			return false;
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