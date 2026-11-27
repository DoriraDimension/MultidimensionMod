using MultidimensionMod.Common.Players;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Accessories
{
    public class HoneyMushroom : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 44;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 0, 20, 0);
            Item.rare = ItemRarityID.Green;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MDPlayer>().HoneyHealthy = true;
            player.GetModPlayer<MDPlayer>().hiveNugget = true;
            player.sticky = false;
            if (player.honeyWet)
            {
                player.ignoreWater = true;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<HealthyCap>())
            .AddIngredient(ModContent.ItemType<HiveNugget>())
            .AddIngredient(ModContent.ItemType<Mushmatter>(), 3)
            .AddIngredient(ItemID.BeeWax, 5)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
        }
    }
}