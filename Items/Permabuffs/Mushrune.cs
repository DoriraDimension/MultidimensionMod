using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MultidimensionMod.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Permabuffs
{
    internal class Mushrune : ModItem
    {
        public static readonly int MaxUsage = 1;
        public static readonly int ManaPerCrystal = 50;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ManaPerCrystal, MaxUsage);

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ManaCrystal);
            Item.width = 34;
            Item.height = 38;
            Item.rare = ItemRarityID.Cyan;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Thunder;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ConsumedManaCrystals == Player.ManaCrystalMax;
        }

        public override bool? UseItem(Player player)
        {
            if (player.GetModPlayer<PermabuffPlayer>().mushrune >= MaxUsage)
            {
                return null;
            }

            player.UseManaMaxIncreasingItem(ManaPerCrystal);

            player.GetModPlayer<PermabuffPlayer>().mushrune++;

            return true;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Permabuffs/Mushrune_Glow").Value;
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