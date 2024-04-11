using MultidimensionMod.Tiles.MusicBoxes;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using System;
using MultidimensionMod.Items.Materials;

namespace MultidimensionMod.Items.Placeables.MusicBoxes
{
    public class MonarchBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Monarch"), ModContent.ItemType<MonarchBox>(), ModContent.TileType<MonarchBoxPlaced>());
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
            Item.createTile = ModContent.TileType<MonarchBoxPlaced>();
            Item.width = 32;
            Item.height = 30;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.MusicBox)
            .AddIngredient(ModContent.ItemType<Mushmatter>(), 4)
            .AddIngredient(ItemID.Mushroom, 40)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}