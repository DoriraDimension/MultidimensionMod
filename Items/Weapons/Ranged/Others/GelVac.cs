using System.Collections.Generic;
using MultidimensionMod.Projectiles.Ranged;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Others
{
	public class GelVac : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gel Vac");
			Tooltip.SetDefault("Normally not used for combat, more of a rancher tool.\nShoots different kind of adorable slimes.");
			DisplayName.AddTranslation(GameCulture.German, "Gel Vac");
			Tooltip.AddTranslation(GameCulture.German, "Normalerweise nicht für den Kampf genutzt, ist mehr ein Rancher Werkzeug.\nVerschießt verschiedene niedliche Schleime");
		}

		public override void SetDefaults()
		{
			item.damage = 27;
			item.ranged = true;
			item.width = 58;
			item.height = 30;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = Item.sellPrice(silver: 58);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 12f;
			item.useAmmo = AmmoID.Gel;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SlimeGun);
			recipe.AddIngredient(ItemID.Gel, 100);
			recipe.AddIngredient(ItemID.Cloud, 25);
			recipe.AddTile(220);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = Main.rand.Next(new int[] { ModContent.ProjectileType<PinkSlime>(), ModContent.ProjectileType<HoneySlime>(), ModContent.ProjectileType<FireSlime>() });
			return true;
		}
	}
}
