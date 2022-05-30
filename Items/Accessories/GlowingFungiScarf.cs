﻿using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class GlowingFungiScarf : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glowing Fungi Scarf");
			Tooltip.SetDefault("A scarf made out of several mushrooms, it glows.\nIncreases ranged damage by 5%.\nIncreases max life by 10 when in a glowing mushroom biome\nIncreases max life by 25 and damage reduction by 5% when in a glowing mushroom biome in hardmode.");
		}

		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 48;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 36);
			Item.rare = ItemRarityID.Green;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
		    if (player.ZoneGlowshroom && Main.hardMode)
			{
				player.statLifeMax2 += 25;
				player.endurance += 0.05f;
			}
			else if (player.ZoneGlowshroom)
            {
				player.statLifeMax2 += 10;
            }
			player.GetDamage(DamageClass.Ranged) += 0.05f;
		    Lighting.AddLight((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f), 0.15f, 0.6f, 0.8f);


		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<Mushmatter>(), 10)
			.AddIngredient(ItemID.GlowingMushroom, 25)
			.AddTile(16)
			.Register();
		}
	}
}