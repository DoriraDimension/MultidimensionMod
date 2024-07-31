using MultidimensionMod.NPCs.Mire;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace MultidimensionMod.Items.Critters
{
    public class MoonMorphoItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.value = Item.buyPrice(silver: 30);
            Item.rare = ItemRarityID.Blue;
            Item.bait = 16;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = Item.useAnimation = 20;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.consumable = true;
            Item.autoReuse = true;
            Item.makeNPC = ModContent.NPCType<MoonMorpho>();
        }
    }
}