using MultidimensionMod.Items;
using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Items.Pets;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using MultidimensionMod.Utilities;
using MultidimensionMod.Base;
using MultidimensionMod.Items.Permabuffs;
using MultidimensionMod.Common.Players;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Fishing;
using System.Linq;
using Terraria.GameContent.ItemDropRules;
using MultidimensionMod.Items.Placeables.Biomes.Mire;
using MultidimensionMod.Items.Placeables.Biomes.FrozenUnderworld;
using MultidimensionMod.Items.Placeables.Biomes.Inferno;

namespace MultidimensionMod.Common.Globals.Items
{
	public class MDGlobalItem : GlobalItem
	{
        public override bool InstancePerEntity => true;
        public bool hasShimmerTransmutation;

		public override void SetStaticDefaults()
        {
            //Makes these items shimmer into another item (They will no longer decraft if previously possible in vanilla)
            ItemID.Sets.ShimmerTransformToItem[ItemID.FallenStar] = ModContent.ItemType<Cassiopeia>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.IceSlimeBanner] = ModContent.ItemType<FrostburnSlimeBanner>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.MagicMirror] = ModContent.ItemType<MirrorOfOrigin>();
            #region Shimmerproof Fishing Hook
            ItemID.Sets.ShimmerTransformToItem[ItemID.AmanitaFungifin] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Angelfish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Batfish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.BloodyManowar] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Bonefish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.BumblebeeTuna] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Bunnyfish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.CapnTunabeard] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Catfish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Cloudfish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Clownfish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Cursedfish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.DemonicHellfish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Derpfish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Dirtfish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.DynamiteFish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.EaterofPlankton] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.FallenStarfish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Fishotron] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Fishron] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.GuideVoodooFish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Harpyfish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Hungerfish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Ichorfish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.InfectedScabbardfish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Jewelfish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.MirageFish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Mudfish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.MutantFlinxfin] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Pengfish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Pixiefish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.ScarabFish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.ScorpioFish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Slimefish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Spiderfish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.TheFishofCthulu] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.TropicalBarracuda] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.TundraTrout] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.UnicornFish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.Wyverntail] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.ZombieFish] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<SelfSimilarStarfish>()] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<PenroseFish>()] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<Pufftail>()] = ModContent.ItemType<ShimmerProofFishingHook>();
            ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<FishroomMonarch>()] = ModContent.ItemType<ShimmerProofFishingHook>();
            #endregion
        }
		public override void SetDefaults(Item item)
		{
			Player player = Main.LocalPlayer;
			if (item.type == ItemID.SpiritFlame) //Changes the sound when using the Spirit Flame because I don't like the original sound :HoldingBackTearsWhileEatingOreos:
			{
				item.UseSound = SoundID.Item103;
			}
			if (item.type == ItemID.Handgun) //Nerfs Handgun as it was re-tiered
			{
				item.damage = 19;
				item.useTime = 20;
				item.useAnimation = 20;
			}
			#region Edible Herbs
            //Give every vanilla herb a unique effect for the funsies
			if (item.type == ItemID.Blinkroot)
            {
				item.useStyle = ItemUseStyleID.EatFood;
				item.useAnimation = 15;
				item.useTime = 15;
				item.UseSound = SoundID.Item2;
				item.consumable = true;
				item.buffType = (11); //Shine
				item.buffTime = 1800;
            }
			if (item.type == ItemID.Deathweed)
			{
				item.useStyle = ItemUseStyleID.EatFood;
				item.useAnimation = 15;
				item.useTime = 15;
				item.UseSound = SoundID.Item2;
				item.consumable = true;
				item.buffType = (70); //Venom
				item.buffTime = 1800;
			}
			if (item.type == ItemID.Fireblossom)
			{
				item.useStyle = ItemUseStyleID.EatFood;
				item.useAnimation = 15;
				item.useTime = 15;
				item.UseSound = SoundID.Item2;
				item.consumable = true;
				item.buffType = (124); //Warmth
				item.buffTime = 1800;
			}
			if (item.type == ItemID.Daybloom)
			{
				item.useStyle = ItemUseStyleID.EatFood;
				item.useAnimation = 15;
				item.useTime = 15;
				item.UseSound = SoundID.Item2;
				item.consumable = true;
				item.buffType = (2); //Life Regen
				item.buffTime = 1800;
			}
			if (item.type == ItemID.Moonglow)
			{
				item.useStyle = ItemUseStyleID.EatFood;
				item.useAnimation = 15;
				item.useTime = 15;
				item.UseSound = SoundID.Item2;
				item.consumable = true;
				item.buffType = (20); //Poison
				item.buffTime = 1800;
			}
			if (item.type == ItemID.Shiverthorn)
			{
				item.useStyle = ItemUseStyleID.EatFood;
				item.useAnimation = 15;
				item.useTime = 15;
				item.UseSound = SoundID.Item2;
				item.consumable = true;
				item.buffType = (46); //Chilled
				item.buffTime = 1800;
			}
			if (item.type == ItemID.Waterleaf)
			{
				item.useStyle = ItemUseStyleID.EatFood;
				item.useAnimation = 15;
				item.useTime = 15;
				item.UseSound = SoundID.Item2;
				item.consumable = true;
				item.healLife = 10;
				item.buffType = (BuffID.PotionSickness);
				item.buffTime = 600;
			}
			#endregion
            if (ALLists.TransmutableItems.TrueForAll(x => item.type != x))
            {
                item.AL().hasShimmerTransmutation = true; //Marks all items in the above list as having a shimmer transmutation
            }

        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (item.type == ModContent.ItemType<NatureGuide>())
            {
                if (item.favorited)
                {
                    player.dontHurtCritters = true;
                    player.dontHurtNature = true;
                }
                player.cordage = true;
            }
        }

        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            //Adds Awakened Light herbs to the Herb Bag loot pool
            if (item.type == ItemID.HerbBag)
            {
                int[] herbs = new int[6]
                {
                    ModContent.ItemType<global::MultidimensionMod.Items.Materials.DreamLilyItem>(),
                    ModContent.ItemType<DreamLilySeeds>(),
                    ModContent.ItemType<global::MultidimensionMod.Items.Materials.DragonToothItem>(),
                    ModContent.ItemType<DragonToothSeeds>(),
                    ModContent.ItemType<global::MultidimensionMod.Items.Materials.IceblossomItem>(),
                    ModContent.ItemType<IceblossomSeeds>()
                };
                foreach (IItemDropRule herbBagAdditions in itemLoot.Get(includeGlobalDrops: false))
                {
                    HerbBagDropsItemDropRule herbRule = herbBagAdditions as HerbBagDropsItemDropRule;
                    if (herbRule != null)
                    {
                        HashSet<int> itemSet = new HashSet<int>(herbRule.dropIds);
                        itemSet.UnionWith(herbs);
                        herbRule.dropIds = itemSet.ToArray();
                        break;
                    }
                }
            }
        }

        public override bool PreDrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            //Based on Calamity Brimstone Locus code and Mod of Redemption Treasure Bag drawcode, credit goes to them
            if (!item.AL().hasShimmerTransmutation) //For some reason this needs to be false, I'm stupid and may fix this later lol
            {
                Texture2D itemTexture = TextureAssets.Item[item.type].Value;
                Rectangle itemFrame = (Main.itemAnimations[item.type] == null) ? itemTexture.Frame() : Main.itemAnimations[item.type].GetFrame(itemTexture);

                if (!Main.LocalPlayer.HasInInventory(ModContent.ItemType<MirrorOfOrigin>())) //Don't run drawcode if player doesn't have the Mirror of Origin
                    return true;

                Vector2 frameOrigin = itemFrame.Size() / 2f;
                Vector2 offset = new(item.width / 2 - frameOrigin.X, item.height - itemFrame.Height);
                Vector2 drawPos = item.position - Main.screenPosition + frameOrigin + offset;

                float time = Main.GlobalTimeWrappedHourly;

                time %= 4f;
                time /= 2f;

                if (time >= 1f)
                {
                    time = 2f - time;
                }

                time = time * 0.5f + 0.5f;

                for (float i = 0f; i < 1f; i += 0.34f)
                {
                    float radians = (i + time) * MathHelper.TwoPi;

                    spriteBatch.Draw(itemTexture, position + new Vector2(0f, 8f).RotatedBy(radians) * time, itemFrame, new Color(197, 121, 255, 77), 0f, frameOrigin, scale, SpriteEffects.None, 0);
                }

                return true;
            }
            return true;
        }

        public override bool CanUseItem(Item item, Player player)
        {
			if (item.type == ItemID.Waterleaf) //Waterleaf needs some Potion Sickness, since it heals now
            {
				return !player.HasBuff(BuffID.PotionSickness);
            }
			return true;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.PickaxeAxe || item.type == ItemID.Drax) //Add tooltip that mentions dense chaos biome blocks being minable with this
            {
                TooltipLine line = new(Mod, "DraxTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.DraxDenseBlockTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
            }
            if (item.type == ItemID.Picksaw) //Add tooltip that mentions Dank Depthstone and Volcanic Rock being minable with this
            {
                tooltips.RemoveAll(TooltipLine => TooltipLine.Name.Equals("Tooltip0"));
                TooltipLine line = new(Mod, "PicksawTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.PicksawChaosCaveTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
            }
            //Gives every herb a tooltip that describes what they do more or less vaguely
            if (item.type == ItemID.Blinkroot)
            {
                TooltipLine line = new(Mod, "BlinkrootTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.BlinkrootTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
                if (Main.LocalPlayer.HasInInventory(ModContent.ItemType<HerbGuide>()) || Main.LocalPlayer.HasInInventory(ModContent.ItemType<NatureGuide>()) || Main.LocalPlayer.GetModPlayer<MDPlayer>().herbBook)
                {
                    if (Main.keyState.PressingShift())
                    {
                        TooltipLine bloomLine = new(Mod, "BlinkrootBloomTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.BlinkrootBloomTip"))
                        {
                            OverrideColor = Color.Orange
                        };
                        tooltips.Add(bloomLine);
                    }
                    else
                    {
                        TooltipLine shiftLine = new(Mod, "HoldShift", Language.GetTextValue("Mods.MultidimensionMod.SpecialTooltips.Blooming"))
                        {
                            OverrideColor = Color.Gray,
                        };
                        tooltips.Add(shiftLine);
                    }
                }
            }
            if (item.type == ItemID.Deathweed)
            {
                TooltipLine line = new(Mod, "DeathweedTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.DeathweedTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
                if (Main.LocalPlayer.HasInInventory(ModContent.ItemType<HerbGuide>()) || Main.LocalPlayer.HasInInventory(ModContent.ItemType<NatureGuide>()) || Main.LocalPlayer.GetModPlayer<MDPlayer>().herbBook)
                {
                    if (Main.keyState.PressingShift())
                    {
                        TooltipLine bloomLine = new(Mod, "DeathweedBloomTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.DeathweedBloomTip"))
                        {
                            OverrideColor = Color.Purple
                        };
                        tooltips.Add(bloomLine);
                    }
                    else
                    {
                        TooltipLine shiftLine = new(Mod, "HoldShift", Language.GetTextValue("Mods.MultidimensionMod.SpecialTooltips.Blooming"))
                        {
                            OverrideColor = Color.Gray,
                        };
                        tooltips.Add(shiftLine);
                    }
                }
            }
            if (item.type == ItemID.Fireblossom)
            {
                TooltipLine line = new(Mod, "FireblossomTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.FireblossomTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
                if (Main.LocalPlayer.HasInInventory(ModContent.ItemType<HerbGuide>()) || Main.LocalPlayer.HasInInventory(ModContent.ItemType<NatureGuide>()) || Main.LocalPlayer.GetModPlayer<MDPlayer>().herbBook)
                {
                    if (Main.keyState.PressingShift())
                    {
                        TooltipLine bloomLine = new(Mod, "FireblossomBloomTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.FireblossomBloomTip"))
                        {
                            OverrideColor = Color.OrangeRed
                        };
                        tooltips.Add(bloomLine);
                    }
                    else
                    {
                        TooltipLine shiftLine = new(Mod, "HoldShift", Language.GetTextValue("Mods.MultidimensionMod.SpecialTooltips.Blooming"))
                        {
                            OverrideColor = Color.Gray,
                        };
                        tooltips.Add(shiftLine);
                    }
                }
            }
            if (item.type == ItemID.Daybloom)
            {
                TooltipLine line = new(Mod, "DaybloomTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.DaybloomTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
                if (Main.LocalPlayer.HasInInventory(ModContent.ItemType<HerbGuide>()) || Main.LocalPlayer.HasInInventory(ModContent.ItemType<NatureGuide>()) || Main.LocalPlayer.GetModPlayer<MDPlayer>().herbBook)
                {
                    if (Main.keyState.PressingShift())
                    {
                        TooltipLine bloomLine = new(Mod, "DaybloomBloomTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.DaybloomBloomTip"))
                        {
                            OverrideColor = Color.Yellow
                        };
                        tooltips.Add(bloomLine);
                    }
                    else
                    {
                        TooltipLine shiftLine = new(Mod, "HoldShift", Language.GetTextValue("Mods.MultidimensionMod.SpecialTooltips.Blooming"))
                        {
                            OverrideColor = Color.Gray,
                        };
                        tooltips.Add(shiftLine);
                    }
                }
            }
            if (item.type == ItemID.Moonglow)
            {
                TooltipLine line = new(Mod, "MoonglowTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.MoonglowTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
                if (Main.LocalPlayer.HasInInventory(ModContent.ItemType<HerbGuide>()) || Main.LocalPlayer.HasInInventory(ModContent.ItemType<NatureGuide>()) || Main.LocalPlayer.GetModPlayer<MDPlayer>().herbBook)
                {
                    if (Main.keyState.PressingShift())
                    {
                        TooltipLine bloomLine = new(Mod, "MoonglowBloomTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.MoonglowBloomTip"))
                        {
                            OverrideColor = Color.LightBlue
                        };
                        tooltips.Add(bloomLine);
                    }
                    else
                    {
                        TooltipLine shiftLine = new(Mod, "HoldShift", Language.GetTextValue("Mods.MultidimensionMod.SpecialTooltips.Blooming"))
                        {
                            OverrideColor = Color.Gray,
                        };
                        tooltips.Add(shiftLine);
                    }
                }
            }
            if (item.type == ItemID.Shiverthorn)
            {
                TooltipLine line = new(Mod, "ShiverthornTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.ShiverthornTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
                if (Main.LocalPlayer.HasInInventory(ModContent.ItemType<HerbGuide>()) || Main.LocalPlayer.HasInInventory(ModContent.ItemType<NatureGuide>()) || Main.LocalPlayer.GetModPlayer<MDPlayer>().herbBook)
                {
                    if (Main.keyState.PressingShift())
                    {
                        TooltipLine bloomLine = new(Mod, "ShiverthornBloomTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.ShiverthornBloomTip"))
                        {
                            OverrideColor = Color.CornflowerBlue
                        };
                        tooltips.Add(bloomLine);
                    }
                    else
                    {
                        TooltipLine shiftLine = new(Mod, "HoldShift", Language.GetTextValue("Mods.MultidimensionMod.SpecialTooltips.Blooming"))
                        {
                            OverrideColor = Color.Gray,
                        };
                        tooltips.Add(shiftLine);
                    }
                }
            }
            if (item.type == ItemID.Waterleaf)
            {
                TooltipLine line = new(Mod, "WaterleafTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.WaterleafTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
                if (Main.LocalPlayer.HasInInventory(ModContent.ItemType<HerbGuide>()) || Main.LocalPlayer.HasInInventory(ModContent.ItemType<NatureGuide>()) || Main.LocalPlayer.GetModPlayer<MDPlayer>().herbBook)
                {
                    if (Main.keyState.PressingShift())
                    {
                        TooltipLine bloomLine = new(Mod, "ShiverthornBloomTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.WaterleafBloomTip"))
                        {
                            OverrideColor = Color.DeepSkyBlue
                        };
                        tooltips.Add(bloomLine);
                    }
                    else
                    {
                        TooltipLine shiftLine = new(Mod, "HoldShift", Language.GetTextValue("Mods.MultidimensionMod.SpecialTooltips.Blooming"))
                        {
                            OverrideColor = Color.Gray,
                        };
                        tooltips.Add(shiftLine);
                    }
                }
            }
            if (item.type == ItemID.RodofDiscord || item.type == ItemID.Clentaminator || item.type == ItemID.BottomlessBucket || item.type == ItemID.BottomlessShimmerBucket)
            {
                if (Main.LocalPlayer.HasInInventory(ModContent.ItemType<MirrorOfOrigin>()))
                {

                    TooltipLine line = new(Mod, "ShimmerablePostMoonLord", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.ShimmerablePostMoonLord"))
                    {
                        OverrideColor = Color.White
                    };
                    tooltips.Add(line);
                }
            }
        }
    }
}