using MultidimensionMod.Projectiles.Melee.Swords;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Tiles;
using MultidimensionMod.Rarities;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class Vulkanus : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Evil Ember, Vulkanus");
			// Tooltip.SetDefault("Throw a blade of molten rock, the blade explodes into volcanic rocks on impact\nThis weapon belonged to Vertrarius, the strongest warrior of the dark forces, he is powerful and doesn't let any wound get to him\nVertrarius is not evil, he simply fights the Hallow out of boredom, violence is the most entertaining thing to him");
		}

		public override void SetDefaults()
		{
			Item.damage = 68;
			Item.DamageType = DamageClass.Melee;
			Item.width = 60;
			Item.height = 70;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.reuseDelay = 25;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 7f;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ModContent.RarityType<BossSoulItem>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.shoot = ModContent.ProjectileType<VulkanusThrow>();
			Item.shootSpeed = 16f;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, (6));
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