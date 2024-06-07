using MultidimensionMod.NPCs.Mire;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace MultidimensionMod.Items.Critters
{
    public class DarkdrifterItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.maxStack = 9999;
            Item.value = Item.buyPrice(silver: 30);
            Item.rare = ItemRarityID.Green;
            Item.bait = 22;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = Item.useAnimation = 20;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.consumable = true;
            Item.autoReuse = true;
            Item.makeNPC = ModContent.NPCType<Darkdrifter>();
        }
    }
}