using MultidimensionMod.Tiles.MusicBoxes;
using MultidimensionMod.Items.Summons;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using System;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Placeables.Biomes.ShroomForest;

namespace MultidimensionMod.Items.Placeables.MusicBoxes
{
    public class ShroomForestNightBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Sounds/Music/ShroomNight"), ModContent.ItemType<ShroomForestNightBox>(), ModContent.TileType<ShroomForestBoxNightPlaced>());
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
            Item.createTile = ModContent.TileType<ShroomForestBoxNightPlaced>();
            Item.width = 32;
            Item.height = 30;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.MusicBox)
            .AddIngredient(ModContent.ItemType<MyceliumSeeds>(), 10)
            .AddIngredient(ItemID.Mushroom, 50)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}