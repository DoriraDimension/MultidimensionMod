using MultidimensionMod.Tiles.MusicBoxes;
using MultidimensionMod.Items.Summons;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using System;
using MultidimensionMod.Items.Materials;

namespace MultidimensionMod.Items.Placeables.MusicBoxes
{
    public class ShroomForestBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Shroom"), ModContent.ItemType<ShroomForestBox>(), ModContent.TileType<ShroomForestBoxPlaced>());
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
            Item.createTile = ModContent.TileType<ShroomForestBoxPlaced>();
            Item.width = 32;
            Item.height = 30;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.MusicBox)
            .AddIngredient(ModContent.ItemType<IntimidatingMushroom>())
            .AddIngredient(ItemID.Mushroom, 100)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}