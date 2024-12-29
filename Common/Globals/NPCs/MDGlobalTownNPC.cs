using MultidimensionMod.Items.Ammo;
using MultidimensionMod.Items.Summons;
using MultidimensionMod.NPCs.TownNPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using MultidimensionMod.Common.Systems;

namespace MultidimensionMod
{
    public class MDGlobalTownNPC : GlobalNPC
    {

        public override void ModifyShop(NPCShop shop)
        {
            if (ModContent.GetInstance<MDConfig>().NPCItemSelling)
            {
                if (shop.NpcType == NPCID.ArmsDealer)
                {
                    shop.Add(new Item(ItemID.Handgun)
                    {
                        shopCustomPrice = Item.buyPrice(0, 10, 0, 0)
                    }, Condition.DownedEowOrBoc);           
                }
                if (shop.NpcType == NPCID.Dryad)
                {
                    shop.Add(new Item(ItemID.SlimeCrown)
                    {
                        shopCustomPrice = Item.buyPrice(0, 1, 50)
                    }, Condition.DownedKingSlime);

                    shop.Add(new Item(ItemID.SuspiciousLookingEye)
                    {
                        shopCustomPrice = Item.buyPrice(0, 4, 10)
                    }, Condition.DownedEyeOfCthulhu);

                    shop.Add(new Item(ItemID.WormFood)
                    {
                        shopCustomPrice = Item.buyPrice(0, 6, 40)
                    }, Condition.DownedEaterOfWorlds);

                    shop.Add(new Item(ItemID.BloodySpine)
                    {
                        shopCustomPrice = Item.buyPrice(0, 6, 40)
                    }, Condition.DownedBrainOfCthulhu);
                }

                if (shop.NpcType == NPCID.Steampunker)
                {
					shop.Add(new Item(ModContent.ItemType<SporeSolution>())
                    {
                        shopCustomPrice = Item.buyPrice(0, 0, 15)
                    });
                    shop.Add(new Item(ModContent.ItemType<MelterSolution>())
                    {
                        shopCustomPrice = Item.buyPrice(0, 0, 15)
                    });
                    shop.Add(new Item(ModContent.ItemType<FreezerSolution>())
                    {
                        shopCustomPrice = Item.buyPrice(0, 0, 15)
                    });
                    shop.Add(new Item(ItemID.MechanicalWorm)
                    {
                        shopCustomPrice = Item.buyPrice(0, 14, 40)
                    }, Condition.DownedDestroyer);

                    shop.Add(new Item(ItemID.MechanicalEye)
                    {
                        shopCustomPrice = Item.buyPrice(0, 14, 40)
                    }, Condition.DownedTwins);

                    shop.Add(new Item(ItemID.MechanicalSkull)
                    {
                        shopCustomPrice = Item.buyPrice(0, 14, 40)
                    }, Condition.DownedSkeletronPrime);
                }

                if (shop.NpcType == NPCID.WitchDoctor)
                {
                    shop.Add(new Item(ItemID.Abeemination)
                    {
                        shopCustomPrice = Item.buyPrice(0, 6, 20)
                    }, Condition.DownedQueenBee);

                    shop.Add(new Item(ModContent.ItemType<PlantMurderStarterSet>())
                    {
                        shopCustomPrice = Item.buyPrice(0, 17, 50)
                    }, Condition.DownedPlantera);

                    shop.Add(new Item(ItemID.LihzahrdPowerCell)
                    {
                        shopCustomPrice = Item.buyPrice(0, 16, 50)
                    }, Condition.DownedGolem);
                }

                if (shop.NpcType == NPCID.Clothier)
                {
                    shop.Add(new Item(ItemID.ClothierVoodooDoll)
                    {
                        shopCustomPrice = Item.buyPrice(0, 10)
                    }, Condition.DownedSkeletron);

                    shop.Add(new Item(ItemID.DeerThing)
                    {
                        shopCustomPrice = Item.buyPrice(0, 10)
                    }, Condition.DownedDeerclops);

                    shop.Add(new Item(ItemID.GuideVoodooDoll)
                    {
                        shopCustomPrice = Item.buyPrice(0, 7, 10)
                    }, Condition.Hardmode);

                    shop.Add(new Item(ModContent.ItemType<MothAttractor>())
                    {
                        shopCustomPrice = Item.buyPrice(0, 5, 50)
                    }, Condition.DownedPlantera);
                }

                if (shop.NpcType == NPCID.Wizard)
                {
                    shop.Add(new Item(4988)
                    {
                        shopCustomPrice = Item.buyPrice(0, 8, 30)
                    }, Condition.DownedQueenSlime);

                    shop.Add(new Item(4961)
                    {
                        shopCustomPrice = Item.buyPrice(0, 10, 0)
                    }, Condition.DownedEmpressOfLight);

                    shop.Add(new Item(ItemID.CelestialSigil)
                    {
                        shopCustomPrice = Item.buyPrice(1, 50)
                    }, Condition.DownedMoonLord);
                }

                if (shop.NpcType == NPCID.Truffle)
                {
                    shop.Add(new Item(ItemID.TruffleWorm)
                    {
                        shopCustomPrice = Item.buyPrice(0, 10)
                    }, Condition.DownedDukeFishron);
                }

                if (shop.NpcType == NPCID.Cyborg)
                {
                    shop.Add(new Item(ModContent.ItemType<MartianCellphone>())
                    {
                        shopCustomPrice = Item.buyPrice(0, 12)
                    }, Condition.DownedMartians);
                }

                if (shop.NpcType == NPCID.Princess)
                {
                    shop.Add(new Item(ItemID.TeleportationPylonVictory)
                    {
                        shopCustomPrice = Item.buyPrice(5, 0, 0, 0)
                    }, Condition.DownedMoonLord);
                }
            }
        }

        public override void GetChat(NPC npc, ref string chat)
        {
            int Dappercap = NPC.FindFirstNPC(ModContent.NPCType<MushroomHeir>());
            if (npc.type == NPCID.Truffle)
            {
                if (Main.rand.NextBool(10) && Dappercap != -1)
                {
                    chat = Language.GetTextValue("Mods.MultidimensionMod.VanillaNPCDialogue.Truffle.Dapper1");
                    if (Main.rand.NextBool(15) && DownedSystem.downedFungus)
                        chat = Language.GetTextValue("Mods.MultidimensionMod.VanillaNPCDialogue.Truffle.Dapper2");
                }
                if (Main.rand.NextBool(10))
                    chat = Language.GetTextValue("Mods.MultidimensionMod.VanillaNPCDialogue.Truffle.Umos1");
                if (Main.rand.NextBool(10))
                    chat = Language.GetTextValue("Mods.MultidimensionMod.VanillaNPCDialogue.Truffle.Umos2");
                if (Main.rand.NextBool(10))
                    chat = Language.GetTextValue("Mods.MultidimensionMod.VanillaNPCDialogue.Truffle.Umos3");
                if (Main.rand.NextBool(12) && DownedSystem.downedFungus)
                    chat = Language.GetTextValue("Mods.MultidimensionMod.VanillaNPCDialogue.Truffle.UmosDead");
                if (Main.rand.NextBool(15) && NPC.downedMoonlord)
                    chat = Language.GetTextValue("Mods.MultidimensionMod.VanillaNPCDialogue.Truffle.Unimush1");
                if (Main.rand.NextBool(15) && NPC.downedMoonlord)
                    chat = Language.GetTextValue("Mods.MultidimensionMod.VanillaNPCDialogue.Truffle.Unimush2");
                if (Main.rand.NextBool(15) && NPC.downedMoonlord)
                    chat = Language.GetTextValue("Mods.MultidimensionMod.VanillaNPCDialogue.Truffle.Unimush3");
            }
            if (npc.type == NPCID.Wizard)
            {
                if (Main.rand.NextBool(12))
                    chat = Language.GetTextValue("Mods.MultidimensionMod.VanillaNPCDialogue.Wizard.Carces");
            }
        }

        public static int AngelerInt = 0;

        public override void OnChatButtonClicked(NPC npc, bool firstButton)
        {
            int Amount = 0;
            if (DownedSystem.consumedTheFish || DownedSystem.usedLicense)
            {
                Amount = 1;
            }
            if (DownedSystem.consumedTheFish && DownedSystem.usedLicense)
            {
                Amount = 2;
            }
            if (Main.anglerQuestFinished && AngelerInt < Amount)
            {
                AngelerInt += 1;
                if (Main.netMode == 0)
                {
                    Main.AnglerQuestSwap();
                }
                else if (Main.netMode == 1)
                {
                    ModPacket packet = base.Mod.GetPacket();
                    packet.Write((byte)3);
                    packet.Send();
                }
            }
        }
    }
}