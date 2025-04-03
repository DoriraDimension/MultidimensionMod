using MultidimensionMod.Projectiles.Summon.Whips;
using MultidimensionMod.Tiles.Furniture.VoidMatter;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Localization;
using MultidimensionMod.Buffs.Minions;

namespace MultidimensionMod.Items.Weapons.Summon
{
	public class VoidArm : ModItem
	{
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(VoidArmWhipTag.TagDamage);
        public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.value = Item.sellPrice(0, 0, 70, 0);
			Item.rare = ItemRarityID.Orange;
			Item.DefaultToWhip(ModContent.ProjectileType<VoidArmProj>(), 22, 6, 7);

		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 10)
				.AddTile(ModContent.TileType<EmptyKingsFabricatorPlaced>())
				.Register();
		}

		public override bool MeleePrefix()
		{
			return true;
		}
	}
}