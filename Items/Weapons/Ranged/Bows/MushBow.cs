using MultidimensionMod.Items.Materials;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class MushBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Mush Bow");
			// Tooltip.SetDefault("A bow made of juicy fungi flesh.");
		}

		public override void SetDefaults()
		{
			Item.damage = 18;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 24;
			Item.height = 42;
			Item.useTime = 39;
			Item.useAnimation = 39;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 3);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 6f;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<Mushmatter>(), 14)
			.AddIngredient(ItemID.GlowingMushroom, 20)
			.AddTile(16)
			.Register();
		}
	}
}