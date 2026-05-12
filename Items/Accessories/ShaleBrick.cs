using MultidimensionMod.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
    public class ShaleBrick : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 30;
            Item.accessory = true;
            Item.rare = ItemRarityID.Pink;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MDPlayer>().SBrick = true;
            player.buffImmune[BuffID.WindPushed] = true;
            player.noKnockback = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<TheBrick>())
            //.AddIngredient(ModContent.ItemType<Shalestone>(), 50)
            .AddIngredient(ItemID.Obsidian, 50)
            .AddIngredient(ItemID.PearlstoneBlock, 5)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}