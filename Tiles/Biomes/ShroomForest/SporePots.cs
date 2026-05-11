using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MultidimensionMod.Dusts;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ObjectData;

namespace MultidimensionMod.Tiles.Biomes.ShroomForest
{
    public class SporePots : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileOreFinderPriority[Type] = (short)100;
            Main.tileWaterDeath[Type] = false;
            Main.tileCut[Type] = true;
            Main.tileSpelunker[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.RandomStyleRange = 3;
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(47, 79, 79));
            DustType = ModContent.DustType<MushroomDust>();
            HitSound = SoundID.Shatter;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {

        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            EntitySource_TileBreak source = new(i, j);
            if (Main.rand.NextBool(500))
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                    Projectile.NewProjectile(source, (i + 1.5f) * 16f, j * 16f, 0f, 0f, ProjectileID.CoinPortal, 0, 0, Main.myPlayer);
            }
            else if (Main.getGoodWorld && Main.rand.NextBool(4))
                Projectile.NewProjectile(new EntitySource_TileBreak(i, j), i * 16 + 16, j * 16 + 8, (float)Main.rand.Next(-100, 101) * 0.002f, 0f, ProjectileID.Bomb, 0, 0f, Player.FindClosest(new Vector2(i * 16, j * 16), 16, 16));
            else
            {
                if (Main.expertMode ? Main.rand.Next(45) < 2 : Main.rand.NextBool(45))
                {
                    switch (Main.rand.Next(11))
                    {
                        case 0:
                            yield return new Item(ItemID.MiningPotion);
                            break;
                        case 1:
                            yield return new Item(ItemID.IronskinPotion);
                            break;
                        case 2:
                            yield return new Item(ItemID.NightOwlPotion);
                            break;
                        case 3:
                            yield return new Item(ItemID.ShinePotion);
                            break;
                        case 4:
                            yield return new Item(ItemID.SwiftnessPotion);
                            break;
                        case 5:
                            yield return new Item(ItemID.CalmingPotion);
                            break;
                        case 6:
                            yield return new Item(ItemID.BuilderPotion);
                            break;
                    }
                }
                else if (Main.rand.NextBool(25))
                {
                    yield return new Item(ItemID.RecallPotion);
                }
                else if (Main.netMode != NetmodeID.MultiplayerClient && Main.rand.NextBool(30))
                {
                    yield return new Item(ItemID.WormholePotion);
                }
                else
                {
                    switch (Main.rand.Next(8))
                    {
                        case 0:
                            yield return new Item(ItemID.Heart);
                            if (Main.rand.NextBool(2))
                                yield return new Item(ItemID.Heart);
                            break;
                        case 1:
                            if (Main.tile[i, j].LiquidAmount == 255 && Main.tile[i, j].LiquidType == LiquidID.Water)
                                yield return new Item(ItemID.Glowstick, Main.rand.Next(Main.expertMode ? 5 : 4, Main.expertMode ? 18 : 12));
                            else
                                yield return new Item(ItemID.Torch, Main.rand.Next(Main.expertMode ? 5 : 4, Main.expertMode ? 18 : 12));
                                //Item.NewItem(source, i * 16, j * 16, 32, 16, ModContent.ItemType<MushroomTorch>(), Main.rand.Next(Main.expertMode ? 5 : 4, Main.expertMode ? 18 : 12));
                            break;
                        case 2:
                            yield return new Item(ItemID.Bomb, Main.rand.Next(1, Main.expertMode ? 7 : 4));
                            break;
                        case 3:
                            for (int k = 0; k < Main.rand.Next(1, 4); k++)
                            {
                                if (Main.rand.NextBool(2))
                                    yield return new Item(ItemID.CopperCoin, Main.rand.Next(1, 99));
                            }
                            for (int k = 0; k < Main.rand.Next(1, 4); k++)
                            {
                                if (Main.rand.NextBool(2))
                                    yield return new Item(ItemID.SilverCoin, Main.rand.Next(1, 50));
                            }
                            for (int k = 0; k < Main.rand.Next(1, 3); k++)
                            {
                                if (Main.rand.NextBool(4))
                                    yield return new Item(ItemID.GoldCoin, Main.rand.Next(1, 3));
                            }
                            break;
                        case 4:
                            if (Main.rand.NextBool(4))
                            {
                                yield return new Item(ItemID.HealingPotion);
                            }
                            else
                            {
                                yield return new Item(ItemID.LesserHealingPotion);
                            }
                            break;
                        case 5:
                            yield return new Item(ItemID.Shuriken, Main.rand.Next(10, 20));
                            break;
                        case 6:
                            yield return new Item(ItemID.ThrowingKnife, Main.rand.Next(10, 20));
                            break;
                        case 7:

                            break;
                    }
                }
            }
            Vector2 losVector = new(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
            Gore.NewGore(new EntitySource_TileBreak(i, j), new Vector2(i * 16, j * 16), losVector, ModContent.Find<ModGore>("MultidimensionMod/SporePotGore1").Type);
            if (Main.rand.NextBool(2))
                Gore.NewGore(new EntitySource_TileBreak(i, j), new Vector2(i * 16, j * 16), losVector, ModContent.Find<ModGore>("MultidimensionMod/SporePotGore2").Type);
        }
    }
}