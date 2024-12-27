using Terraria.ModLoader;
using Terraria.ID;
using MultidimensionMod.Tiles.MusicBoxes;
using Terraria.GameContent.Creative;
using MultidimensionMod.Items.Placeables.Biomes.Mire;
using MultidimensionMod.Items.Materials;

namespace MultidimensionMod.Items.Placeables.MusicBoxes
{
    public class MireBox : ModItem
	{
		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Mire Surface Music Box");
            //Tooltip.SetDefault(@"Plays 'Moonlit Marsh' by Charlie Debnam");
            MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Sounds/Music/ShroudedMireNight"), ModContent.ItemType<MireBox>(), ModContent.TileType<MireBoxPlaced>());
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
			Item.createTile = ModContent.TileType<MireBoxPlaced>();
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
               .AddIngredient(ModContent.ItemType<Bogwood>(), 40)
			   .AddIngredient(ModContent.ItemType<MirePod>(), 10)
               .AddTile(TileID.Sawmill)
               .Register();
        }
    }
}
