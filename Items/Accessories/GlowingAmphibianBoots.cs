using MultidimensionMod.Common.Players;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
    public class GlowingAmphibianBoots : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 46;
            Item.height = 46;
            Item.accessory = true;
            Item.rare = ItemRarityID.Orange;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.autoJump = true;
            player.extraFall += 18;
            Player.jumpSpeed += 1;
            player.GetModPlayer<ToadLeapPlayer>().LegEquipped = true;
            player.GetModPlayer<MDPlayer>().GABoots = true;
            player.GetModPlayer<MDPlayer>().SailfishAdd = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.AmphibianBoots)
            .AddIngredient(ModContent.ItemType<ToadLeg>())
            .AddIngredient(ModContent.ItemType<GlowingMushmatter>(), 4)
            .AddIngredient(ItemID.Bone, 10)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
        }
    }
}