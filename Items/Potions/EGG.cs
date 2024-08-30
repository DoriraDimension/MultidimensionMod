using MultidimensionMod.Buffs.Potions;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using System;
using MultidimensionMod.Rarities;
using System.Reflection;
using Terraria.Audio;
using Terraria.IO;
using Terraria.Net;
using System.Threading;
using MultidimensionMod.Common.Systems;
using System.IO;

namespace MultidimensionMod.Items.Potions
{
    public class EGG : ModItem
    {
        public static int returnDelay
        {
            get;
            set;
        }

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 42;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item2;
            Item.maxStack = 1;
            Item.consumable = true;
            Item.rare = ModContent.RarityType<DeepGreen>();
            Item.value = Item.sellPrice(0, 0, 0, 0);
        }

        //Thanks for Wrath of the Gods for having a public example on how to achieve this
        public override bool? UseItem(Player player)
        {
            player.GetModPlayer<EggPlayer>().TheEggening = true;
            SoundEngine.PlaySound(new("MultidimensionMod/Sounds/NPC/Zerohit"), player.position);
            returnDelay = 1;
            return true;
        }
    }

    public class EggPlayer : ModPlayer
    {
        public bool TheEggening = false;
        public int EggeningDrawsNear = 0;

        public override void PostUpdate()
        {
            if (TheEggening)
            {
                EggeningDrawsNear++;
            }
            if (EggeningDrawsNear == 60)
            {
                TheEggening = false;
                EggeningDrawsNear = 0;
                if (Main.netMode != NetmodeID.Server)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(context =>
                    {
                        Main.menuMode = 10;
                        Main.gameMenu = true;
                        OblivionFuckOffTextSystem.UseEggText = true;
                        Main.ActivePlayerFileData.StopPlayTimer();
                        Player.SavePlayer(Main.ActivePlayerFileData);
                        Player.ClearPlayerTempInfo();
                        if (Main.netMode == NetmodeID.SinglePlayer)
                            WorldFile.CacheSaveTime();
                        if (Main.netMode == NetmodeID.SinglePlayer)
                            WorldFile.SaveWorld();
                        if (Main.netMode == NetmodeID.MultiplayerClient)
                        {
                            Netplay.Disconnect = true;
                            Main.netMode = NetmodeID.SinglePlayer;
                        }
                        else
                        {
                            Netplay.Disconnect = true;
                            Main.netMode = NetmodeID.SinglePlayer;
                        }
                        do
                            typeof(MenuLoader).GetMethod("OffsetModMenu", BindingFlags.Static | BindingFlags.NonPublic).Invoke(null, new object[] { Main.rand.Next(-2, 3) });
                        while (((ModMenu)typeof(MenuLoader).GetField("switchToMenu", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null)).FullName != Menus.ALVoidMenu.Instance.FullName);
                    }));
                }
            }
        }
    }
}
