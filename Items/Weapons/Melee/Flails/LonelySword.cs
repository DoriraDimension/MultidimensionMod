using MultidimensionMod.Projectiles.Melee.Flails;
using MultidimensionMod.Tiles.Furniture.VoidMatter;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;

namespace MultidimensionMod.Items.Weapons.Melee.Flails
{
	public class LonelySword : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 32;
			Item.DamageType = DamageClass.Melee;
			Item.width = 70;
			Item.height = 114;
			Item.useTime = 23;
			Item.useAnimation = 23;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 4;
            Item.noUseGraphic = true;
            Item.channel = true;
            Item.noMelee = true;
            Item.value = Item.sellPrice(0, 1, 50, 0);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<RisingLightFlail>();
			Item.shootSpeed = 8f;
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