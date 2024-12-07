﻿using MultidimensionMod.Tiles.MusicBoxes;
using MultidimensionMod.Items.Materials;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using System;
using MultidimensionMod.Items.Placeables.Biomes.FrozenUnderworld;

namespace MultidimensionMod.Items.Placeables.MusicBoxes
{
    public class FungusMenuBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Sounds/Music/FungusMenu"), ModContent.ItemType<FungusMenuBox>(), ModContent.TileType<FungusMenuBoxPlaced>());
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
            Item.createTile = ModContent.TileType<FungusMenuBoxPlaced>();
            Item.width = 32;
            Item.height = 30;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ShroomForestBox>())
            .AddIngredient(ItemID.MusicBoxMushrooms)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
        }
    }
}