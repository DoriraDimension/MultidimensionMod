using MultidimensionMod.Common.Players;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
    public class FrocketSlammer : ModItem
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
            player.fireWalk = true;
            player.noFallDmg = true;
            player.rocketBoots = 2;
            player.maxFallSpeed *= 1.6f;
            player.GetModPlayer<MDPlayer>().Frocket = true;
            player.GetModPlayer<ToadLeapPlayer>().LegEquipped = true;
        }

        public override void UpdateVanity(Player player)
        {
            player.vanityRocketBoots = 3;
        }

        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            return incomingItem.type != ModContent.ItemType<ImpactTreads>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ImpactTreads>())
            .AddIngredient(ModContent.ItemType<ToadLeg>())
            .AddIngredient(ModContent.ItemType<GlowingMushmatter>(), 4)
            .AddIngredient(ItemID.Bone, 10)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
        }
    }
}