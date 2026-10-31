using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using MultidimensionMod.Tiles.Furniture;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.Localization;
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
                .AddIngredient(ModContent.ItemType<MadnessFragment>(), 20)
                .AddIngredient(ModContent.ItemType<Blight2>())
                .AddIngredient(ModContent.ItemType<Dimensium>(), 5)
                .AddCondition(Language.GetOrRegister("Mods.MultidimensionMod.MiscText.MadnessDriveCondition"), () => RememberAnalysis.AnalysedMadnessDrive && ModContent.GetInstance<DimensionalForgeTileEntity>().IsEquippedWithMadnessDrive)
                .AddTile(ModContent.TileType<DimensionalForge>())
                .Register();
        }
    }
}
