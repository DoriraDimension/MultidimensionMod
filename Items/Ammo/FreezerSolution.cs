using MultidimensionMod.Projectiles.Solutions;
using Terraria.GameContent.Creative;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Ammo
{
    public class FreezerSolution : ModItem
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 14;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Orange;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 15, 0);
            Item.ammo = AmmoID.Solution;
            Item.shoot = ModContent.ProjectileType<FreezerSpray>() - ProjectileID.PureSpray;
        }
    }
}
