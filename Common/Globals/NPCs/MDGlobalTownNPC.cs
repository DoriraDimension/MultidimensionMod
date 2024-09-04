using MultidimensionMod.Items.Ammo;
using MultidimensionMod.Items.Summons;
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

                    shop.Add(new Item(ModContent.ItemType<MoonRuneStone>())
                    {
                        shopCustomPrice = Item.buyPrice(0, 13, 30)
                    }, Condition.DownedCultist);

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
            }
        }
    }
}