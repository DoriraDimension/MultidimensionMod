using MultidimensionMod.NPCs.Bosses.FeudalFungus;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.Localization;


namespace MultidimensionMod.Items.Summons
{
    public class ConfusingMushroom : ModItem
    {

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Confusing Looking Mushroom");
            ItemID.Sets.SortingPriorityBossSpawns[Item.type] = 13;
            //Tooltip.SetDefault(@"Summons the Feudal Fungus Can only be used in a glowing mushroom biome");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 22;
            Item.maxStack = 20;
            Item.value = 1000;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.ZoneGlowshroom && !NPC.AnyNPCs(ModContent.NPCType<FeudalFungus>()))
            {
                return true;
            }
            return false;
        }

        public override bool? UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<FeudalFungus>());
            SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/HallowedCry"), player.position);
            return true;
        }

        public void SpawnBoss(Player player, string name, string displayName)
        {

        }
    }
}