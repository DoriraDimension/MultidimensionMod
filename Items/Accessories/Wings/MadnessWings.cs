using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories.Wings
{
    // This is a basic wings item.
    // By default wings only support 4 frames of animation, see ExampleCustomDrawWings.cs for an example of custom wing animation.
    [AutoloadEquip(EquipType.Wings)]
    public class MadnessWings : ModItem
    {

        public override void SetStaticDefaults()
        {
            // These wings use the same values as the solar wings
            // Fly time: 180 ticks = 3 seconds
            // Fly speed: 9
            // Acceleration multiplier: 2.5
            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(130, 7f, 1.5f);
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 30;
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.85f; // Falling glide speed
            ascentWhenRising = 0.15f; // Rising speed
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 2.5f;
            constantAscend = 0.135f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SoulofFlight, 20)
                .AddIngredient<Blight2>()
                .AddIngredient(ModContent.ItemType<Dimensium>(), 10)
                .AddCondition(Language.GetOrRegister("Mods.MultidimensionMod.MiscText.MadnessDriveCondition"), () => RememberAnalysis.AnalysedMadnessDrive && ModContent.GetInstance<DimensionalForgeTileEntity>().IsEquippedWithMadnessDrive)
                .AddTile<DimensionalForge>()
                .Register();
        }
    }
}