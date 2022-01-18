using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Guns
{
	public class ImpulseSniperRifle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Impulse Sniper Rifle");
			Tooltip.SetDefault("[c/00EAFF:'How did this become top seller?']\nTurns bullets into a fast piercing laser impulse");
			// just a disclaimer how I have done that, you can also use [i: <itemid> ] for item displaying
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-19,2); // so that eye is on the scope
		}

		public override void SetDefaults()
		{
			item.damage = 203;
			item.crit = 31; // 35% total
			item.ranged = true; // a gun
			item.melee = false; // not a melee
			item.noMelee = true; // turning off hitbox damage
			item.width = 120;
			item.height = 32;
			item.autoReuse = true; // autouse on
			item.useTime = 40; // slower than sniper rifle
			item.useAnimation = 41;
			item.useStyle = 5;
			item.knockBack = 11.5f; // insane
			item.value = Item.sellPrice(gold: 8);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item115;
			item.useAmmo = AmmoID.Bullet;
			item.shoot = 638; // luminite bullet, laser was scraped
			item.shootSpeed = 32.5f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = 638; // turning any bullet into luminite bullet
            return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SniperRifle, 1); // 1 sniper rifle
			recipe.AddIngredient(ItemID.Nanites, 24); // 24 nanites
			recipe.AddIngredient(ItemID.SpectreBar, 10); // 10 spectre bars
			recipe.AddIngredient(ItemID.ShroomiteBar, 12); // 12 shroomite bars
			recipe.AddTile(412); // Mythril Anvil tier
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}