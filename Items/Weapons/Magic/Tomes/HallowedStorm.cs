using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Tomes
{
	public class HallowedStorm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hallowed Storm");
			Tooltip.SetDefault("Summons prism shards around you as long as you hold down the mouse button\nAll shards fly towards the cursor upon releasing the button.");
		}

		public override void SetDefaults()
		{
			Item.damage = 32;
			Item.DamageType = DamageClass.Magic;
			Item.knockBack = 1f;
			Item.mana = 6;
			Item.width = 40;
			Item.height = 38;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.autoReuse = true;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.value = Item.sellPrice(silver: 10);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item9;
			Item.noMelee = true;
			Item.shoot = ModContent.ProjectileType<PrismShards>();
			Item.channel = true;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine Item in list)
			{
				if (Item.Mod == "Terraria" && Item.Name == "ItemName")
				{
					Item.OverrideColor = MDRarity.BossItem;
				}
			}
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer);
			return player.ownedProjectileCounts[Item.shoot] < 20;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			position = player.position;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<EmpressSoul>())
			.AddIngredient(ModContent.ItemType<Dimensium>(), 20)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}