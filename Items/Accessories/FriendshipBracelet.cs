using MultidimensionMod.Common.Globals.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
    public class FriendshipBracelet : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 34;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense += 5 * (int)player.slotsMinions;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Leather, 5)
            .AddIngredient(ItemID.Cobweb, 10)
            .AddRecipeGroup(Recipes.EvilSample, 5)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}