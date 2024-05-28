using Terraria.ModLoader;
using Terraria.ID;
using MultidimensionMod.Tiles.MusicBoxes;
using Terraria.GameContent.Creative;
using MultidimensionMod.Items.Placeables.Biomes.Mire;

namespace MultidimensionMod.Items.Placeables.MusicBoxes
{
    public class MireDayBox : ModItem
	{
		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Mire Day Music Box");
            //Tooltip.SetDefault(@"Plays 'Clouded in Mystery' by Charlie Debnam");
            MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Sounds/Music/ShroudedMireDay"), ModContent.ItemType<MireDayBox>(), ModContent.TileType<MireDayBoxPlaced>());
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
			Item.createTile = ModContent.TileType<MireDayBoxPlaced>();
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
            .AddIngredient(ModContent.ItemType<Bogwood>(), 60)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
