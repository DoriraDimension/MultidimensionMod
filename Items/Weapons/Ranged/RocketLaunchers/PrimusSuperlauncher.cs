using System.Collections.Generic;
using MultidimensionMod.Projectiles.Ranged;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using MultidimensionMod.Rarities;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.Audio;

namespace MultidimensionMod.Items.Weapons.Ranged.RocketLaunchers
{
	public class PrimusSuperlauncher : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Primus Superlauncher");
			Tooltip.SetDefault("Shoots several Prime weapon based rockets.");
		}

		public override void SetDefaults()
		{
			Item.damage = 49;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 58;
			Item.height = 26;
			Item.useTime = 16;
			Item.useAnimation = 56;
			Item.reuseDelay = 45;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(gold: 7);
			Item.rare = ModContent.RarityType<BossSoulItem>();
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Rocket;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			SoundEngine.PlaySound(SoundID.Item11, player.position);
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<PrimeSoul>())
			.AddIngredient(ModContent.ItemType<Dimensium>(), 15)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = Main.rand.Next(new int[] { ModContent.ProjectileType<PrimusVice>(), ModContent.ProjectileType<PrimusSaw>(), ModContent.ProjectileType<PrimusLaser>(), ModContent.ProjectileType<PrimusCannon>() });
		}
	}
}
