using MultidimensionMod.Tiles.Biomes.ShroomForest;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.DataStructures;

namespace MultidimensionMod.Items.Placeables.Biomes.ShroomForest
{
    public class MyceliumSeeds : ModItem
	{
		public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Mycelium Seeds");
            //Tooltip.SetDefault("Plants Mycelium");
            ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
        }		
		
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0, 0, 50);
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.consumable = true;		
        }

        public override bool? UseItem(Player player)
        {
            Tile tile = Framing.GetTileSafely(Player.tileTargetX, Player.tileTargetY);

            if (tile.HasTile && tile.TileType == TileID.Dirt && player.IsInTileInteractionRange(Player.tileTargetX, Player.tileTargetY, TileReachCheckSettings.Simple))
            {
                Main.tile[Player.tileTargetX, Player.tileTargetY].TileType = (ushort)ModContent.TileType<Mycelium>();
                SoundEngine.PlaySound(SoundID.Dig, player.Center);

                return true;
            }

            return false;
        }
    }
}