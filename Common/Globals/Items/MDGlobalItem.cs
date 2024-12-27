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

namespace MultidimensionMod.Common.Globals.Items
{
	public class MDGlobalItem : GlobalItem
	{
        public override bool InstancePerEntity => true;
        public bool hasShimmerTransmutation;

		public override void SetStaticDefaults()
        {
            //Makes these items shimmer into another item (They will no longer decraft if previously possible)
			ItemID.Sets.ShimmerTransformToItem[ItemID.FallenStar] = ModContent.ItemType<Cassiopeia>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.IceSlimeBanner] = ModContent.ItemType<FrostburnSlimeBanner>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.MagicMirror] = ModContent.ItemType<MirrorOfOrigin>();
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

                for (float i = 0f; i < 1f; i += 0.25f)
                {
                    float radians = (i + time) * MathHelper.TwoPi;

                    spriteBatch.Draw(itemTexture, drawPos + new Vector2(0f, 16f).RotatedBy(radians) * time, itemFrame, new Color(223, 98, 223, 50), 0f, origin, scale, SpriteEffects.None, 0);
                }

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
            }
            if (item.type == ItemID.Deathweed)
            {
                TooltipLine line = new(Mod, "DeathweedTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.DeathweedTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
            }
            if (item.type == ItemID.Fireblossom)
            {
                TooltipLine line = new(Mod, "FireblossomTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.FireblossomTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
            }
            if (item.type == ItemID.Daybloom)
            {
                TooltipLine line = new(Mod, "DaybloomTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.DaybloomTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
            }
            if (item.type == ItemID.Moonglow)
            {
                TooltipLine line = new(Mod, "MoonglowTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.MoonglowTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
            }
            if (item.type == ItemID.Shiverthorn)
            {
                TooltipLine line = new(Mod, "ShiverthornTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.ShiverthornTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
            }
            if (item.type == ItemID.Waterleaf)
            {
                TooltipLine line = new(Mod, "WaterleafTip", Language.GetTextValue("Mods.MultidimensionMod.VanillaTooltipEdits.WaterleafTip"))
                {
                    OverrideColor = Color.White
                };
                tooltips.Add(line);
            }
        }
    }
}