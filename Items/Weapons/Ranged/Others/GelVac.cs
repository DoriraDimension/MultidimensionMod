using System.Collections.Generic;
using MultidimensionMod.Projectiles.Ranged;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Others
{
	public class GelVac : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Gel Vac");
			// Tooltip.SetDefault("Normally not used for combat, more of a rancher tool.\nShoots different kind of adorable slimes.");
		}

		public override void SetDefaults()
		{
			Item.damage = 27;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 58;
			Item.height = 30;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(silver: 58);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Gel;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.SlimeGun)
			.AddIngredient(ItemID.Gel, 100)
			.AddIngredient(ItemID.Cloud, 25)
			.AddTile(220)
			.Register();
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = Main.rand.Next(new int[] { ModContent.ProjectileType<PinkSlime>(), ModContent.ProjectileType<HoneySlime>(), ModContent.ProjectileType<FireSlime>() });
		}
	}
}
