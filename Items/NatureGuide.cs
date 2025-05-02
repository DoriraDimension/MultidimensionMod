using Microsoft.Xna.Framework;
using MultidimensionMod.Common.Players;
using MultidimensionMod.Rarities;
using MultidimensionMod.Tiles.Furniture.VoidMatter;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items
{
    public class NatureGuide : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 32;
            Item.rare = ItemRarityID.Orange;
            Item.value = 0;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.cordage = true;
            if (!hideVisual)
            {
                player.dontHurtCritters = true;
                player.dontHurtNature = true;
            }
            player.GetModPlayer<MDPlayer>().herbBook = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(Common.Globals.Items.Recipes.PeaceGuide)
                .AddIngredient(ItemID.CordageGuide)
                .AddIngredient(ModContent.ItemType<HerbGuide>())
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}