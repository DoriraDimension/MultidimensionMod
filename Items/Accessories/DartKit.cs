using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using MultidimensionMod.Common.Players;

namespace MultidimensionMod.Items.Accessories
{
    public class DartKit : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 36;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 0, 0, 0);
            Item.rare = ItemRarityID.LightRed;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thorns = 1.70f;
            player.GetModPlayer<MDPlayer>().DartKitBoost = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ThornScarf>())
            .AddIngredient(ItemID.VialofVenom, 2)
            .AddIngredient(ItemID.Deathweed, 3)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}