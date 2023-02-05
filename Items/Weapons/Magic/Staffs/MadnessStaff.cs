using System.Collections.Generic;
using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Items.Materials;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Staffs
{
	public class MadnessStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mindbursting Madness");
			Tooltip.SetDefault("A staff made from the flesh of creatures that attampted ascension\nHurls a bouncing sphere that becomes stronger after it bounces.");
		}

		public override void SetDefaults()
		{
			Item.damage = 26;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 6;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 13);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<MadnessSphere>();
			Item.shootSpeed = 10f;
			Item.crit = 8;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<MadnessFragment>(), 11)
			.AddTile(16)
			.Register();
		}
	}
}