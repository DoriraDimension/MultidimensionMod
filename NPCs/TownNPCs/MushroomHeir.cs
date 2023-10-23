﻿using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Placeables;
using MultidimensionMod.Items.Pets;
using MultidimensionMod.Items.Summons;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Weapons.Melee.Others;
using MultidimensionMod.NPCs.Bosses.MushroomMonarch;
using MultidimensionMod.Items.Mushrooms;
using MultidimensionMod.Common.Systems;
using MultidimensionMod.Common.Globals;
using MultidimensionMod.Projectiles.Ranged;
using MultidimensionMod.Items.Quest;
using MultidimensionMod.Biomes;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.GameContent.Personalities;
using Terraria.Utilities;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework;

namespace MultidimensionMod.NPCs.TownNPCs
{
    [AutoloadHead]
    public class MushroomHeir : ModNPC
    {
        public const string ShopName = "Shop";

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
            NPCID.Sets.AttackFrameCount[NPC.type] = 3;
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 60;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
            NPC.Happiness
                .SetBiomeAffection<HallowBiome>(AffectionLevel.Like)
                .SetBiomeAffection<MushroomBiome>(AffectionLevel.Love)
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike)
                .SetBiomeAffection<ShroomForest>(AffectionLevel.Hate)
                .SetNPCAffection(NPCID.Truffle, AffectionLevel.Like)
                .SetNPCAffection(NPCID.Clothier, AffectionLevel.Dislike)
                .SetNPCAffection(ModContent.NPCType<MushroomMonarch>(), AffectionLevel.Hate)
                //.SetNPCAffection(ModContent.NPCType<MonarchSlep>(), AffectionLevel.Hate)
                .SetNPCAffection(NPCID.PartyGirl, AffectionLevel.Love)
            ;
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 24;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 25;
            NPC.defense = 999;
            NPC.lifeMax = 100;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = .5f;
            AnimationType = NPCID.Mechanic;
            SpawnModBiomes = new int[1] { ModContent.GetInstance<ShroomForest>().Type };
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Dappercap")
            });
        }

        public override bool CheckDead()
        {
            MDWorld.TposeTimer = 0;
            Main.NewText("Dappercap went into hiding.", Color.Red.R, Color.Red.G, Color.Red.B);
            NPC.SetDefaults(ModContent.NPCType<Dapperbox>());
            NPC.life = 1;

            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.WorldData);

            return false;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (player.active)
                {
                    if (DownedSystem.downedMonarch)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override List<string> SetNPCNameList()
        {
            //reference to the Dapperling mushroom
            return new List<string>() {
                "Deadly Dappercap"
            };
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();
            int SkeletronSlave = NPC.FindFirstNPC(NPCID.Clothier);
            int FungusBungus = NPC.FindFirstNPC(NPCID.Truffle);
            int dad = NPC.FindFirstNPC(ModContent.NPCType<MushroomMonarch>());
            //int uncle = NPC.FindFirstNPC(ModContent.NPCType<FeudalFungus>());
            if (dad >= 0)
            {
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dappercap.FatherDialogue"));
            }
            /*if (uncle >= 0)
            {
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dappercap.UncleDialogue"));
            }*/
            if ((FungusBungus & SkeletronSlave) >= 0 && Main.rand.NextBool(4))
            {
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dappercap.ClothTruffleDialogue", Main.npc[FungusBungus].GivenName, Main.npc[SkeletronSlave].GivenName));
            }
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dappercap.GenericDialogue1"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dappercap.GenericDialogue2"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dappercap.GenericDialogue3"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dappercap.GenericDialogue4"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dappercap.GenericDialogue5"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dappercap.GenericDialogue6"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dappercap.GenericDialogue7"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dappercap.AldinDialogue"));
            return chat;
        }

        public static string MadnessChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dappercap.MadnessTrade"));
            return chat;
        }

        public static string TradeFail()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dappercap.TradeFail1"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dappercap.TradeFail2"));
            return chat;
        }

        public static string TradeSuccess()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dappercap.TradeSuccess1"));
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dappercap.TradeSuccess2"));
            return chat;
        }

        public static string Food()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();
            chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Dappercap.DyeItemTrade"));
            return chat;
        }

        private static int ChatNumber = 0;

        public override void SetChatButtons(ref string button, ref string button2)
        {
            string talk1 = "I am?";
            string talk2 = "Understood";
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = "Give Rare Plant";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                shopName = "Shop";
            }
            if (!firstButton)
            {
                #region Alchemical Mushroom drop code that is too long so I made a region for it
                Player player = Main.LocalPlayer;
                var source = player.GetSource_OpenItem(Type);

                int Special = player.FindItem(ModContent.ItemType<MadnessShroom>());
                int Item = player.FindItem(3385);
                int Item2 = player.FindItem(3386);
                int Item3 = player.FindItem(3387);
                int Item4 = player.FindItem(3388);

                int DyeRed = player.FindItem(ItemID.RedHusk);
                int DyeOrange = player.FindItem(ItemID.OrangeBloodroot);
                int DyeYellow = player.FindItem(ItemID.YellowMarigold);
                int DyeGreen1 = player.FindItem(ItemID.GreenMushroom);
                int DyeGreen2 = player.FindItem(ItemID.LimeKelp);
                int DyeGreen3 = player.FindItem(ItemID.TealMushroom);
                int DyeBlue1 = player.FindItem(ItemID.CyanHusk);
                int DyeBlue2 = player.FindItem(ItemID.SkyBlueFlower);
                int DyeBlue3 = player.FindItem(ItemID.BlueBerries);
                int DyePurple1 = player.FindItem(ItemID.PurpleMucos);
                int DyePurple2 = player.FindItem(ItemID.VioletHusk);
                int DyePink = player.FindItem(ItemID.PinkPricklyPear);
                int DyeGray = player.FindItem(ItemID.BlackInk);

                if (Special >= 0)
                {
                    player.inventory[Special].stack--;
                    if (player.inventory[Special].stack <= 0)
                    {
                        player.inventory[Special] = new Item();
                    }

                    Main.npcChatText = MadnessChat();
                    player.QuickSpawnItem(source, ModContent.ItemType<Rainbow>());

                    SoundEngine.PlaySound(SoundID.Chat);
                    return;
                }
                else if (Item >= 0)
                {
                    player.inventory[Item].stack--;
                    if (player.inventory[Item].stack <= 0)
                    {
                        player.inventory[Item] = new Item();
                    }

                    Main.npcChatText = TradeSuccess();
                    int choice = Main.rand.Next(9);
                    if (choice == 0)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Red>(), 3);
                    }
                    else if (choice == 1)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Orange>(), 3);
                    }
                    else if (choice == 2)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Green>(), 3);
                    }
                    else if (choice == 3)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Brown>(), 3);
                    }
                    else if (choice == 4)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Gray>(), 3);
                    }
                    else if (choice == 5)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Blue>(), 3);
                    }
                    else if (choice == 6)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Pink>(), 3);
                    }
                    else if (choice == 7)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Purple>(), 3);
                    }
                    else if (choice == 8)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Yellow>(), 3);
                    }

                    SoundEngine.PlaySound(SoundID.Chat);
                    return;
                }
                else if (Item2 >= 0)
                {
                    player.inventory[Item2].stack--;
                    if (player.inventory[Item2].stack <= 0)
                    {
                        player.inventory[Item2] = new Item();
                    }

                    Main.npcChatText = TradeSuccess();
                    int choice = Main.rand.Next(9);
                    if (choice == 0)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Red>(), 3);
                    }
                    else if (choice == 1)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Orange>(), 3);
                    }
                    else if (choice == 2)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Green>(), 3);
                    }
                    else if (choice == 3)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Brown>(), 3);
                    }
                    else if (choice == 4)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Gray>(), 3);
                    }
                    else if (choice == 5)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Blue>(), 3);
                    }
                    else if (choice == 6)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Pink>(), 3);
                    }
                    else if (choice == 7)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Purple>(), 3);
                    }
                    else if (choice == 8)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Yellow>(), 3);
                    }

                    SoundEngine.PlaySound(SoundID.Chat);
                    return;
                }
                else if (Item3 >= 0)
                {
                    player.inventory[Item3].stack--;
                    if (player.inventory[Item3].stack <= 0)
                    {
                        player.inventory[Item3] = new Item();
                    }

                    Main.npcChatText = TradeSuccess();
                    int choice = Main.rand.Next(9);
                    if (choice == 0)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Red>(), 3);
                    }
                    else if (choice == 1)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Orange>(), 3);
                    }
                    else if (choice == 2)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Green>(), 3);
                    }
                    else if (choice == 3)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Brown>(), 3);
                    }
                    else if (choice == 4)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Gray>(), 3);
                    }
                    else if (choice == 5)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Blue>(), 3);
                    }
                    else if (choice == 6)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Pink>(), 3);
                    }
                    else if (choice == 7)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Purple>(), 3);
                    }
                    else if (choice == 8)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Yellow>(), 3);
                    }

                    SoundEngine.PlaySound(SoundID.Chat);
                    return;
                }
                else if (Item4 >= 0)
                {
                    player.inventory[Item4].stack--;
                    if (player.inventory[Item4].stack <= 0)
                    {
                        player.inventory[Item4] = new Item();
                    }

                    Main.npcChatText = TradeSuccess();
                    int choice = Main.rand.Next(9);
                    if (choice == 0)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Red>(), 3);
                    }
                    else if (choice == 1)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Orange>(), 3);
                    }
                    else if (choice == 2)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Green>(), 3);
                    }
                    else if (choice == 3)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Brown>(), 3);
                    }
                    else if (choice == 4)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Gray>(), 3);
                    }
                    else if (choice == 5)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Blue>(), 3);
                    }
                    else if (choice == 6)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Pink>(), 3);
                    }
                    else if (choice == 7)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Purple>(), 3);
                    }
                    else if (choice == 8)
                    {
                        player.QuickSpawnItem(source, ModContent.ItemType<Yellow>(), 3);
                    }

                    SoundEngine.PlaySound(SoundID.Chat);
                    return;
                }
                else if (DyeRed >= 0)
                {
                    player.inventory[DyeRed].stack--;
                    if (player.inventory[DyeRed].stack <= 0)
                    {
                        player.inventory[DyeRed] = new Item();
                    }

                    Main.npcChatText = Food();
                    player.QuickSpawnItem(source, ModContent.ItemType<Red>());

                    SoundEngine.PlaySound(SoundID.Chat);
                    return;
                }
                else if (DyeOrange >= 0)
                {
                    player.inventory[DyeOrange].stack--;
                    if (player.inventory[DyeOrange].stack <= 0)
                    {
                        player.inventory[DyeOrange] = new Item();
                    }

                    Main.npcChatText = Food();
                    player.QuickSpawnItem(source, ModContent.ItemType<Orange>());

                    SoundEngine.PlaySound(SoundID.Chat);
                    return;
                }
                else if (DyeYellow >= 0)
                {
                    player.inventory[DyeYellow].stack--;
                    if (player.inventory[DyeYellow].stack <= 0)
                    {
                        player.inventory[DyeYellow] = new Item();
                    }

                    Main.npcChatText = Food();
                    player.QuickSpawnItem(source, ModContent.ItemType<Yellow>());

                    SoundEngine.PlaySound(SoundID.Chat);
                    return;
                }
                else if (DyeGreen1 >= 0)
                {
                    player.inventory[DyeGreen1].stack--;
                    if (player.inventory[DyeGreen1].stack <= 0)
                    {
                        player.inventory[DyeGreen1] = new Item();
                    }

                    Main.npcChatText = Food();
                    player.QuickSpawnItem(source, ModContent.ItemType<Green>());

                    SoundEngine.PlaySound(SoundID.Chat);
                    return;
                }
                else if (DyeGreen2 >= 0)
                {
                    player.inventory[DyeGreen2].stack--;
                    if (player.inventory[DyeGreen2].stack <= 0)
                    {
                        player.inventory[DyeGreen2] = new Item();
                    }

                    Main.npcChatText = Food();
                    player.QuickSpawnItem(source, ModContent.ItemType<Green>());

                    SoundEngine.PlaySound(SoundID.Chat);
                    return;
                }
                else if (DyeGreen3 >= 0)
                {
                    player.inventory[DyeGreen3].stack--;
                    if (player.inventory[DyeGreen3].stack <= 0)
                    {
                        player.inventory[DyeGreen3] = new Item();
                    }

                    Main.npcChatText = Food();
                    player.QuickSpawnItem(source, ModContent.ItemType<Green>());

                    SoundEngine.PlaySound(SoundID.Chat);
                    return;
                }
                else if (DyeBlue1 >= 0)
                {
                    player.inventory[DyeBlue1].stack--;
                    if (player.inventory[DyeBlue1].stack <= 0)
                    {
                        player.inventory[DyeBlue1] = new Item();
                    }

                    Main.npcChatText = Food();
                    player.QuickSpawnItem(source, ModContent.ItemType<Blue>());

                    SoundEngine.PlaySound(SoundID.Chat);
                    return;
                }
                else if (DyeBlue2 >= 0)
                {
                    player.inventory[DyeBlue2].stack--;
                    if (player.inventory[DyeBlue2].stack <= 0)
                    {
                        player.inventory[DyeBlue2] = new Item();
                    }

                    Main.npcChatText = Food();
                    player.QuickSpawnItem(source, ModContent.ItemType<Blue>());

                    SoundEngine.PlaySound(SoundID.Chat);
                    return;
                }
                else if (DyeBlue3 >= 0)
                {
                    player.inventory[DyeBlue3].stack--;
                    if (player.inventory[DyeBlue3].stack <= 0)
                    {
                        player.inventory[DyeBlue3] = new Item();
                    }

                    Main.npcChatText = Food();
                    player.QuickSpawnItem(source, ModContent.ItemType<Blue>());

                    SoundEngine.PlaySound(SoundID.Chat);
                    return;
                }
                else if (DyePurple1 >= 0)
                {
                    player.inventory[DyePurple1].stack--;
                    if (player.inventory[DyePurple1].stack <= 0)
                    {
                        player.inventory[DyePurple1] = new Item();
                    }

                    Main.npcChatText = Food();
                    player.QuickSpawnItem(source, ModContent.ItemType<Purple>());

                    SoundEngine.PlaySound(SoundID.Chat);
                    return;
                }
                else if (DyePurple2 >= 0)
                {
                    player.inventory[DyePurple2].stack--;
                    if (player.inventory[DyePurple2].stack <= 0)
                    {
                        player.inventory[DyePurple2] = new Item();
                    }

                    Main.npcChatText = Food();
                    player.QuickSpawnItem(source, ModContent.ItemType<Purple>());

                    SoundEngine.PlaySound(SoundID.Chat);
                    return;
                }
                else if (DyeGray >= 0)
                {
                    player.inventory[DyeGray].stack--;
                    if (player.inventory[DyeGray].stack <= 0)
                    {
                        player.inventory[DyeGray] = new Item();
                    }

                    Main.npcChatText = Food();
                    player.QuickSpawnItem(source, ModContent.ItemType<Gray>());

                    SoundEngine.PlaySound(SoundID.Chat);
                    return;
                }
                else if (DyePink >= 0)
                {
                    player.inventory[DyePink].stack--;
                    if (player.inventory[DyePink].stack <= 0)
                    {
                        player.inventory[DyePink] = new Item();
                    }

                    Main.npcChatText = Food();
                    player.QuickSpawnItem(source, ModContent.ItemType<Pink>());

                    SoundEngine.PlaySound(SoundID.Chat);
                    return;
                }
                else
                {
                    Main.npcChatText = TradeFail();
                    Main.npcChatCornerItem = 0;
                    SoundEngine.PlaySound(SoundID.Chat);
                }
                #endregion
            }
        }

        public int America = 0;

        public override void AI()
        {
            /*if (NPC.ai[0] == 12f && NPC.ai[1] == NPCID.Sets.AttackTime[NPC.type])
            {
                SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/Gunshot"), NPC.position);
            }*/
        }

        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, ShopName)
            .Add(new Item(ModContent.ItemType<Blue>()) { shopCustomPrice = Item.buyPrice(gold: 10) })
            .Add(new Item(ModContent.ItemType<Brown>()) { shopCustomPrice = Item.buyPrice(gold: 10) })
            .Add(new Item(ModContent.ItemType<Gray>()) { shopCustomPrice = Item.buyPrice(gold: 10) })
            .Add(new Item(ModContent.ItemType<Green>()) { shopCustomPrice = Item.buyPrice(gold: 10) })
            .Add(new Item(ModContent.ItemType<Orange>()) { shopCustomPrice = Item.buyPrice(gold: 10) })
            .Add(new Item(ModContent.ItemType<Pink>()) { shopCustomPrice = Item.buyPrice(gold: 10) })
            .Add(new Item(ModContent.ItemType<Purple>()) { shopCustomPrice = Item.buyPrice(gold: 10) })
            .Add(new Item(ModContent.ItemType<Red>()) { shopCustomPrice = Item.buyPrice(gold: 10) })
            .Add(new Item(ModContent.ItemType<Yellow>()) { shopCustomPrice = Item.buyPrice(gold: 10) });
            npcShop.Register();
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Mushmatter>()));
        }

        public override bool CanGoToStatue(bool toKingStatue)
        {
            return true;
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 25;
            knockback = 2f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 20;
            randExtraCooldown = 20;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.Bullet;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 25f;
            randomOffset = 0f;
        }
    }
}