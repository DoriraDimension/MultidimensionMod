using MultidimensionMod.Rarities.Souls;
using MultidimensionMod.Common.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria.ModLoader.IO;
using MultidimensionMod.NPCs.Friendly;
using MultidimensionMod.NPCs.Bosses.MushroomMonarch;
using Terraria.Audio;
using Terraria.Localization;

namespace MultidimensionMod.Items.Souls
{
    public class GlowshroomSoul : ModItem
    {
        public static readonly SoundStyle UseSound = new SoundStyle("MultidimensionMod/Sounds/Custom/HallowedCry");
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 24;
            Item.rare = ModContent.RarityType<GlowshroomSoulRarity>();
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.UseSound = UseSound;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (MemorySystem.seenMemory)
            {
                TooltipLine line = new(Mod, "MemorySeen", Language.GetTextValue("Mods.MultidimensionMod.Items.GlowshroomSoul.MemorySeen"))
                {
                    OverrideColor = Color.White,
                };
                tooltips.Add(line);
            }
            else
            {
                TooltipLine line = new(Mod, "MemoryNotSeen", Language.GetTextValue("Mods.MultidimensionMod.Items.GlowshroomSoul.MemoryNotSeen"))
                {
                    OverrideColor = Color.White,
                };
                tooltips.Add(line);
            }
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.GlowshroomSoul.Lore"))
                {
                    OverrideColor = Color.LightGray
                };
                tooltips.Add(line);
            }
            else
            {
                TooltipLine line = new(Mod, "HoldShift", Language.GetTextValue("Mods.MultidimensionMod.SpecialTooltips.Viewer"))
                {
                    OverrideColor = Color.Gray,
                };
                tooltips.Add(line);
            }
        }

        public override bool CanUseItem(Player player)
        {
            if (MemorySystem.seenMemory)
            {
                return false;
            }
            return true;
        }

        public override bool? UseItem(Player player)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<FungusMemory>()] < 1)
                Projectile.NewProjectile(player.GetSource_FromThis(), player.Center.X, player.Center.Y - 200, 0f, 0f, ModContent.ProjectileType<FungusMemory>(), 0, 0f);
            return true;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Souls/GlowshroomSoul").Value;
            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
                    Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
        }
    }
}