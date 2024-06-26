using MultidimensionMod.Tiles.Biomes.ShroomForest;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

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
            Item.createTile = ModContent.TileType<Mycelium>();
            Item.consumable = true;		
        }

        public override bool CanUseItem(Player p)
        {
            Tile tile = Framing.GetTileSafely(Player.tileTargetX, Player.tileTargetY);
            if (tile != null && tile.HasTile && tile.TileType == TileID.Dirt)
            {
                WorldGen.destroyObject = true;
                TileID.Sets.BreakableWhenPlacing[TileID.Dirt] = true;
                return base.CanUseItem(p);
            }
            return false;
        }

        public override bool? UseItem(Player p)
        {
            WorldGen.destroyObject = false;
            TileID.Sets.BreakableWhenPlacing[TileID.Dirt] = false;
            return base.UseItem(p);
        }
    }
}