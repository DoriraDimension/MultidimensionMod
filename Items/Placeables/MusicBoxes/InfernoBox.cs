using MultidimensionMod.Tiles.MusicBoxes;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Placeables.Biomes.Inferno;

namespace MultidimensionMod.Items.Placeables.MusicBoxes
{
    public class InfernoBox : ModItem
    {
        public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Inferno Surface Music Box");
            //Tooltip.SetDefault(@"Plays 'Flame-Razed Rock' by Karamitasu");
            MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Sounds/Music/DragonHoardDay"), ModContent.ItemType<InfernoBox>(), ModContent.TileType<InfernoBoxPlaced>());
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<InfernoBoxPlaced>();
			Item.width = 24;
			Item.height = 24;
			Item.rare = ItemRarityID.LightRed;
			Item.value = 10000;
			Item.accessory = true;
		}
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.MusicBox)
            .AddIngredient(ModContent.ItemType<Razewood>(), 40)
            .AddIngredient(ModContent.ItemType<DragonScale>(), 10)
            .AddTile(TileID.Sawmill)
            .Register();
        }
    }
}
