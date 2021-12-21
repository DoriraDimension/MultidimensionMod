using System.Collections.Generic;
using MultidimensionMod.Items.Materials;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Others
{
	public class CursedMaw : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Maw");
			Tooltip.SetDefault("A weapon modeled after Eater of Souls, it spits a few cursed fireballs.");
			DisplayName.AddTranslation(GameCulture.German, "Verfluchtes Maul");
			Tooltip.AddTranslation(GameCulture.German, "Eine Waffe die nach Seelenfressern deigned wurde, sie spuckt ein paar verfluchte Feuerbälle.");
		}

		public override void SetDefaults()
		{
			item.damage = 64;
			item.ranged = true;
			item.width = 44;
			item.height = 24;
			item.useTime = 12;
			item.useAnimation = 54;
			item.reuseDelay = 40;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item34;
			item.autoReuse = true;
			item.shoot = ProjectileID.CursedFlameFriendly;
			item.shootSpeed = 10f;
			item.crit = 4;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.mod == "Terraria" && item.Name == "ItemName")
				{
					item.overrideColor = MDRarity.RelicWeapon;
				}
			}
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 1 + Main.rand.Next(1);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<OldTaintedMandible>());
			recipe.AddIngredient(ModContent.ItemType<OldTaintedCurseContainer>());
			recipe.AddIngredient(ItemID.RottenChunk, 20);
			recipe.AddIngredient(ItemID.CursedFlame, 8);
			recipe.AddTile(377);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
