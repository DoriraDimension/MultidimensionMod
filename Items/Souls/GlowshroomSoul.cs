using MultidimensionMod.Rarities.Souls;
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
using MultidimensionMod.Common.Systems;
using MultidimensionMod.NPCs.Friendly;
using MultidimensionMod.NPCs.Bosses.MushroomMonarch;
using Terraria.Audio;

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

    public class MemorySystem : ModSystem
    {
        public static bool seenMemory;
        public static bool seenSecondMemory;

        public override void OnWorldLoad()
        {
            seenMemory = false;
            seenSecondMemory = false;
        }

        public override void OnWorldUnload()
        {
            seenMemory = false;
            seenSecondMemory = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            var downed = new List<string>();

            if (seenMemory)
                downed.Add("seenMemory");
            if (seenSecondMemory)
                downed.Add("seenSecondMemory");

            tag["memory"] = downed;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            var downed = tag.GetList<string>("memory");

            seenMemory = downed.Contains("seenMemory");
            seenSecondMemory = downed.Contains("seenSecondMemory");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = seenMemory;
            flags[0] = seenSecondMemory;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            seenMemory = flags[0];
            seenSecondMemory = flags[0];
        }
    }
}