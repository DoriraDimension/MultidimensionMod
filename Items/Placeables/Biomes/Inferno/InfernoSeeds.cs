using MultidimensionMod.Tiles.Biomes.Inferno;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Placeables.Biomes.Inferno
{
    public class InfernoSeeds : ModItem
	{
		public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Scorched Seeds");
            //Tooltip.SetDefault("Plants Inferno grass");
            ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
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
            Item.createTile = ModContent.TileType<InfernoGrass>();
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