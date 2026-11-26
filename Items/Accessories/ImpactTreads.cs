using MultidimensionMod.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
    public class ImpactTreads : ModItem
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
            player.GetModPlayer<MDPlayer>().ImpactTreads = true;
        }

        public override void UpdateVanity(Player player)
        {
            player.vanityRocketBoots = 1;
        }

        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            return incomingItem.type != ModContent.ItemType<FrocketSlammer>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.RocketBoots)
            .AddIngredient(ItemID.ObsidianHorseshoe)
            .AddIngredient(ItemID.MeteoriteBar, 18)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}