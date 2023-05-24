using MultidimensionMod.Projectiles.Summon.Whips;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Summon
{
	public class MadnessWhip : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 24;
			Item.width = 66;
			Item.height = 40;
			Item.useTime = 19;
			Item.useAnimation = 19;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.value = Item.sellPrice(0, 0, 30, 0);
			Item.rare = ItemRarityID.Green;
			Item.DefaultToWhip(ModContent.ProjectileType<MadnessWhipProj>(), 24, 2, 3);
			Item.shootSpeed = 6;

		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<MadnessFragment>(), 5)
				.AddTile(TileID.Anvils)
				.Register();
		}

		public override bool MeleePrefix()
		{
			return true;
		}
	}
}
