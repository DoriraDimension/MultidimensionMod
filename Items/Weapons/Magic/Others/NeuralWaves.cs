using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Tiles;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Others
{
	public class NeuralWaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Neural Waves");
			Tooltip.SetDefault("A forbidden technique that transforms the user's thoughts into energy waves that burst out in all directions.\nIt is one of the forbidden techniques of old times, when the Creators did'nt knew the morals of life.\nAs told in old secret records, the spell gets stronger the more malicious the user's thoughts are, resulting in a devastating shockwave.");
			Item.staff[Item.type] = true;
		}


		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 10;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 10;
			Item.useAnimation = 100;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.noUseGraphic = true;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<NeuralWave>();
			Item.shootSpeed = 15f;
			Item.crit = 8;
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
				for (int i = 0; i < 3; i++)
				{
					Projectile.NewProjectile(source, position, new Vector2(Main.rand.NextFloat(-10, 10), Main.rand.NextFloat(-3, 3)), type, damage, 0f, Main.myPlayer);
				}
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<BrainSoul>())
			.AddIngredient(ModContent.ItemType<Dimensium>(), 10)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}