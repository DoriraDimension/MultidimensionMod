using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MultidimensionMod.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Collections.Generic;
using MultidimensionMod.Common.Systems;

namespace MultidimensionMod.Items.Permabuffs
{
    internal class AdvancedFishingLicense : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 38;
            Item.rare = ItemRarityID.LightRed;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item92;
            if (!DownedSystem.usedLicense)
            {
                Item.consumable = true;
            }
            else
            {
                Item.consumable = false;
            }
        }

        public override bool? UseItem(Player player)
        {
            if (!DownedSystem.usedLicense)
            {
                DownedSystem.usedLicense = true;
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.WorldData);
                }
            }
            return true;
        }
    }
}