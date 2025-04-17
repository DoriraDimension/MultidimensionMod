using MultidimensionMod.Tiles.Biomes.Mire;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.Audio;
using Terraria.DataStructures;


namespace MultidimensionMod.Items.Placeables.Biomes.Mire
{
    public class MireSeeds : ModItem
	{
		public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Dank Seeds");
            //Tooltip.SetDefault("Plants Mire grass");
            ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<AbyssGrassSeeds>();
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0, 0, 50);
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.consumable = true;		
        }

        public override bool? UseItem(Player player)
        {
            Tile tile = Framing.GetTileSafely(Player.tileTargetX, Player.tileTargetY);

            if (tile.HasTile && tile.TileType == ModContent.TileType<DarkmudPlaced>() && player.IsInTileInteractionRange(Player.tileTargetX, Player.tileTargetY, TileReachCheckSettings.Simple))
            {
                Main.tile[Player.tileTargetX, Player.tileTargetY].TileType = (ushort)ModContent.TileType<MireGrass>();
                SoundEngine.PlaySound(SoundID.Dig, player.Center);

                return true;
            }

            return false;
        }
    }
}