using MultidimensionMod.Tiles.Furniture;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture
{
    public class MadnessMonolith : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<MadnessMonolithPlaced>();
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
            Item.vanity = true;
        }

        /*public override void UpdateEquip(Player player)
        {
            Player
            if (player.whoAmI == Main.myPlayer)
            {
                SkyManager.Instance.Activate("MadnessMoonSky");
                player.ManageSpecialBiomeVisuals("MultidimensionMod:Madness", true);
            }
        }

        public override void UpdateVanity(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                SkyManager.Instance.Activate("MadnessMoonSky");
                player.ManageSpecialBiomeVisuals("MultidimensionMod:Madness", true);
            }
        }*/

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Materials.MadnessFragment>(), 20)
                .AddIngredient(ModContent.ItemType<Materials.Blight2>())
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
