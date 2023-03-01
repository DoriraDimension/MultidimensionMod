using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Tiles;
using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Rarities;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Others
{
	public class Mythos : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lightstream Mythos");
			Tooltip.SetDefault("Spin a crystal halberd around you that generates up to 2 light rings that spin around you as well.\nIf both rings of light are present and you stop attacking, the holy magic within them will heal you for 10 HP\n+" +
                "This weapon belonged to Adel, the general of the Hallow, he was noble but also stubborn\nHe fought in the great war against his arch nemesis Vertrarius, that was until his soul was trapped inside the Wall of Flesh");
		}

		public override void SetDefaults()
		{
			Item.damage = 56;
			Item.DamageType = DamageClass.Magic;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.autoReuse = true;
			Item.knockBack = 4.5f;
			Item.width = 80;
			Item.height = 38;
			Item.value = Item.sellPrice(gold: 1);
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.channel = true;
			Item.rare = ModContent.RarityType<BossSoulItem>();
			Item.shoot = ModContent.ProjectileType<MythosStaff>();
			Item.shootSpeed = 0f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<WallSoul>())
			.AddIngredient(ModContent.ItemType<Dimensium>(), 15)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}