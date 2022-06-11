using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Melee.Swords;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class TundranaScythe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Tundrana Scythe");
			Tooltip.SetDefault("A scythe from a world beyhond the freezing fog of the Frozen Underworld, it was once used by some sort of royal guard.\nShoot piss");
		}

		public override void SetDefaults()
		{
			Item.damage = 79;
			Item.DamageType = DamageClass.Melee;
			Item.width = 76;
			Item.height = 76;
			Item.useTime = 42;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(gold: 3);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<TundraSickle>();
			Item.shootSpeed = 12f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			return true;
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
			.AddIngredient(ItemID.IceSickle, 1)
			.AddIngredient(ItemID.FrostCore, 2)
			.AddIngredient(ModContent.ItemType<TidalQuartz>(), 5)
			.AddTile(134)
			.Register();
		}
	}
}