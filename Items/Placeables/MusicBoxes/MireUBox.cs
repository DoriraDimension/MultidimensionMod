using Terraria.ModLoader;
using Terraria.ID;
using MultidimensionMod.Items.Placeables.Biomes.Mire;
using MultidimensionMod.Tiles.MusicBoxes;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Placeables.MusicBoxes
{
    public class MireUBox : ModItem
	{
		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Mire Underground Music Box");
            //Tooltip.SetDefault(@"Plays 'The Deepest Reaches' by Charlie Debnam");
            MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Sounds/Music/LakeDepths"), ModContent.ItemType<MireUBox>(), ModContent.TileType<MireUBoxPlaced>());
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public override void SetDefaults()
		{
			Item.useStyle = 1;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<MireUBoxPlaced>();
			Item.width = 24;
			Item.height = 24;
			Item.rare = 4;
			Item.value = 10000;
			Item.accessory = true;
		}
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.MusicBox)
            .AddIngredient(ModContent.ItemType<Depthstone>(), 30)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
