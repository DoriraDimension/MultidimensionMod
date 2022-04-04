using System.Collections.Generic;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class Lifelight : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lifelight");
			Tooltip.SetDefault("The awakened form of the Light's Bane that shows that even the most evil being can become good.");
			DisplayName.AddTranslation(GameCulture.German, "Lebenslicht");
			Tooltip.AddTranslation(GameCulture.German, "Die erwachte Version des Schrecken des Tags, es zeigt das selbst die böseste Kreatur gut werden kann.");
		}

		public override void SetDefaults()
		{
			item.damage = 36;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = Item.sellPrice(silver: 46);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.crit = 8;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(5))
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, (14));
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, (57));
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LightsBane);
			recipe.AddIngredient(ItemID.SunplateBlock, 15);
			recipe.AddIngredient(ItemID.Bone, 4);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>(), 10);
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}