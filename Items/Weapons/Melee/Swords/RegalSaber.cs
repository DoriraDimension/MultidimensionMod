using System.Collections.Generic;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Tiles;
using MultidimensionMod.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class RegalSaber : ModItem
	{
		public int Grow = 0;
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Regal Saber");
			// Tooltip.SetDefault("A sword born from the soul of the king of all slimes, it might not be a very powerful sword but it emits a regal aura.");
		}

		public override void SetDefaults()
		{
			Item.damage = 11;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 50;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 2;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(silver: 30);
			Item.rare = ModContent.RarityType<BossSoulItem>();
			Item.UseSound = SoundID.Item1;
			Item.crit = 31;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(137, 480);
		}

		public override bool? UseItem(Player player)
		{
			Grow += 1;
			if (Grow == 1)
            {
				Item.scale = 1.5f;
				Item.damage = 13;
            }
			if (Grow == 2)
            {
				Item.scale = 2f;
				Item.damage = 15;
            }
			if (Grow == 3)
            {
				Item.scale = 3f;
				Item.damage = 17;
            }
			if (Grow >= 4)
			{
				Item.damage = 11;
				Item.scale = 1f;
				Item.noMelee = false;
				Item.noUseGraphic = false;
				Grow = 0;
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<KingSlimeSoul>())
			.AddIngredient(ModContent.ItemType<Dimensium>(), 10)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}