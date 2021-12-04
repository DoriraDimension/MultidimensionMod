using System.Collections.Generic;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Ranged;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Guns
{
	public class MetalWormGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Handheld Destroyer");
			Tooltip.SetDefault("The rotten flesh fell off and it evolved to take on the place of the Destroyer.");
			DisplayName.AddTranslation(GameCulture.German, "Handheld Zerstörer");
			Tooltip.AddTranslation(GameCulture.German, "Das ferfaulte Fleisch ist abgefallen und es entwickelte sich um den Platz des Zerstörers einzunehmen.");
		}

		public override void SetDefaults()
		{
			item.damage = 89;
			item.ranged = true;
			item.width = 68;
			item.height = 22;
			item.useTime = 47;
			item.useAnimation = 47;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = Item.sellPrice(gold: 3);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item33;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 30f;
			item.useAmmo = AmmoID.Bullet;
			item.crit = 15;
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

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<SnipeWorm>());
			recipe.AddIngredient(ItemID.SoulofMight, 12);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = ModContent.ProjectileType<DestroyerDualLaser>();
			return true;
		}
	}
}