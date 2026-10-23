using MultidimensionMod.Common.Players;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
    public class ShimmerproofTackleBag : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 36;
            Item.value = Item.sellPrice(0, 2);
            Item.rare = ItemRarityID.Yellow;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MDPlayer>().shimmerproofHook = true;
            player.accLavaFishing = true;
            player.accFishingLine = true;
            player.accTackleBox = true;
            player.fishingSkill += 13;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.LavaproofTackleBag)
            .AddIngredient(ModContent.ItemType<ShimmerproofFishingHook>())
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
        }
    }
}