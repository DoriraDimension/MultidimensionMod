using MultidimensionMod.Tiles.Biomes.Mire;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using MultidimensionMod.Tiles.Biomes.Inferno;
using System;


namespace MultidimensionMod.Items.Placeables.Biomes.Mire
{
    public class AbyssGrassSeeds : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Dank Seeds");
            //Tooltip.SetDefault("Plants Mire grass");
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
            Item.createTile = ModContent.TileType<AbyssGrass>();
            Item.consumable = true;
        }

        public override bool CanUseItem(Player p)
        {
            Tile tile = Framing.GetTileSafely(Player.tileTargetX, Player.tileTargetY);
            if (tile != null && tile.HasTile && tile.TileType == ModContent.TileType<DarkmudPlaced>())
            {
                WorldGen.destroyObject = true;
                TileID.Sets.BreakableWhenPlacing[ModContent.TileType<DarkmudPlaced>()] = true;
                return base.CanUseItem(p);
            }
            return false;
        }

        public override bool? UseItem(Player p)
        {
            WorldGen.destroyObject = false;
            TileID.Sets.BreakableWhenPlacing[ModContent.TileType<DarkmudPlaced>()] = false;
            return base.UseItem(p);
        }
    }
}