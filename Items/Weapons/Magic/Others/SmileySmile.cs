using MultidimensionMod.Projectiles.Magic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles.Furniture.VoidMatter;

namespace MultidimensionMod.Items.Weapons.Magic.Others
{
	public class SmileySmile : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 36;
			Item.DamageType = DamageClass.Magic;
			Item.width = 28;
			Item.height = 26;
			Item.useTime = 26;
			Item.useAnimation = 26;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.mana = 5;
			Item.knockBack = 1;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.DD2_SonicBoomBladeSlash;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<DarkBolt>();
			Item.shootSpeed = 15f;
		}

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<PaleMatter>(), 5)
                .AddTile(ModContent.TileType<EmptyKingsFabricatorPlaced>())
                .Register();
        }
    }
}
