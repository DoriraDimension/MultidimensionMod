using MultidimensionMod.Projectiles.Summon.Sentries;
using MultidimensionMod.Base;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System.Collections.Generic;
using Terraria.Localization;
using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework.Graphics;

namespace MultidimensionMod.Items.Weapons.Summon
{
    public class RadianceTalisman : ModItem
    {
        public static readonly SoundStyle UseSound = new SoundStyle("MultidimensionMod/Sounds/Custom/HallowedCry");
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Summon;
            Item.mana = 50;
            Item.width = 22;
            Item.height = 46;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.value = Item.sellPrice(gold: 1);
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Prayer>();
            Item.rare = ItemRarityID.Green;
            Item.UseSound = UseSound;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.RadianceTalisman.Lore")) //Mush Mon and Dappercap are the only true sentient red mushrooms due to Feudal sharing its light with them
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
            Tile tile = Framing.GetTileSafely(Player.tileTargetX, Player.tileTargetY);
            if (tile.HasUnactuatedTile && Main.tileSolid[tile.TileType] && !Main.tileCut[tile.TileType])
                return false;

            return true;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            int floor = BaseWorldGen.GetFirstTileFloor((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16);
            position = new Vector2(Main.MouseWorld.X, floor * 16 - 24);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer, player.direction);
            projectile.originalDamage = Item.damage;
            player.UpdateMaxTurrets();
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<GlowingMushmatter>(), 5)
            .AddTile(TileID.Anvils)
            .Register();
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Weapons/Summon/RadianceTalisman_Glow").Value;
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