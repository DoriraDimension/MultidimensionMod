using MultidimensionMod.Projectiles.Ranged;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class BlackDragonBow : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Fires a high damage Dragonpiercer.\nRight click to shoot a wide spread of flames to incinerate your enemies.\nFatalis, Fatalis, heaven and earth are yours.");
			DisplayName.AddTranslation(GameCulture.German, "Schwarzer Drachen Bogen");
			Tooltip.AddTranslation(GameCulture.German, "Verschießt einen mächtigen Drachentöter pfeil.\nRechtsklicke um einen weiten Schwall aus Flammen zu schießen der deine Feinde einäschert.\nFatalis, Fatalis, heaven and earth are yours.");
		}

		public override void SetDefaults() {
			item.damage = 340;
			item.ranged = true; 
			item.width = 64; 
			item.height = 100; 
			item.useTime = 80; 
			item.useAnimation = 80;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; 
			item.knockBack = 4;
			item.value = Item.sellPrice(gold: 30);
			item.rare = ItemRarityID.Purple; 
			item.UseSound = SoundID.Item5; 
			item.autoReuse = true; 
			item.shoot = 10; 
			item.shootSpeed = 120f; 
			item.useAmmo = AmmoID.Arrow;
			item.crit = 44;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MoltenFury);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ItemID.SoulofFright, 30);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.useStyle = ItemUseStyleID.HoldingOut;
				item.useTime = 4;
				item.useAnimation = 20;
				item.UseSound = SoundID.Item34;
				item.autoReuse = true;
				item.damage = 98;
				item.shoot = ModContent.ProjectileType<ShradesDemise>();
				item.shootSpeed = 40f;
			}
			else
			{
				item.damage = 1200;
				item.ranged = true;
				item.useTime = 80;
				item.useAnimation = 80;
				item.useStyle = ItemUseStyleID.HoldingOut;
				item.noMelee = true;
				item.knockBack = 4;
				item.UseSound = SoundID.Item5;
				item.autoReuse = true;
				item.shoot = 10;
				item.shootSpeed = 120f;
				item.useAmmo = AmmoID.Arrow;
				item.crit = 30;
			}
			return base.CanUseItem(player);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
            {
				type = ModContent.ProjectileType<ShradesDemise>();

				Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
				if (Collision.CanHit(position, 3, 3, position + muzzleOffset, -6, 6))
				{
					position += muzzleOffset;
				}

				{
					float numberProjectiles = 10 + Main.rand.Next(1);
					float rotation = MathHelper.ToRadians(45);
					position += Vector2.Normalize(new Vector2(speedX, speedY)) * 60f;
					for (int i = 0; i < numberProjectiles; i++)
					{
						Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
						Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
					}
					return true;
				}
			}
			else
            {
				type = ModContent.ProjectileType<Dragonpiercer>();
			}
		}
	}
}
