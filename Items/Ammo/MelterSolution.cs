using MultidimensionMod.Projectiles.Solutions;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Ammo
{
    public class MelterSolution : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 14;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Orange;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 3, 0);
            Item.ammo = AmmoID.Solution;
            Item.shoot = ModContent.ProjectileType<MelterSpray>() - ProjectileID.PureSpray;
        }
    }
}
