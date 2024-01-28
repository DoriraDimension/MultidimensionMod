using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Rarities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.Collections.Generic;
using Terraria.Localization;
using System;
using MultidimensionMod.NPCs.Bosses.FeudalFungus;
using Terraria.Audio;
using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework.Graphics;

namespace MultidimensionMod.Items.Weapons.Magic.Tomes
{
    public class UmosShower : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }


        public override void SetDefaults()
        {
            Item.damage = 19;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 10;
            Item.width = 48;
            Item.height = 32;
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 0.5f;
            Item.noUseGraphic = true;
            Item.value = Item.sellPrice(0, 0, 55, 0);
            Item.rare = ItemRarityID.Green;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<UmosBook>();
            Item.shootSpeed = 1f;
            Item.channel = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.UmosShower.Lore"))
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

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.ownedProjectileCounts[type] < 1)
            {
                Projectile.NewProjectile(source, player.Center.X, player.Center.Y, 1, 1, ModContent.ProjectileType<UmosBook>(), damage, 0);
            }
            if (player.statLife <= player.statLifeMax2 / 2)
            {
                for (int i = 0; i < 8; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(player.velocity.X / 2, -20).RotatedByRandom(MathHelper.ToRadians(60));
                    int makeNice = Projectile.NewProjectile(player.GetSource_FromThis(), player.Center.X, player.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<PureRadianceShotFriendly>(), damage, 0);
                    SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/RadianceShot"), player.position);
                }
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(player.velocity.X / 2, -20).RotatedByRandom(MathHelper.ToRadians(60));
                    int makeNice = Projectile.NewProjectile(player.GetSource_FromThis(), player.Center.X, player.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<Mushshot2Friendly>(), (int)((double)((float)damage) * 1.5), 0);
                    SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/Blurb"), player.position);
                }
            }
            return false;
        }

        public override void UseItemFrame(Player player)
        {
            player.bodyFrame.Y = 5 * player.bodyFrame.Height;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Book)
            .AddIngredient(ModContent.ItemType<GlowingMushmatter>(), 4)
            .AddTile(TileID.Bookcases)
            .Register();
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Weapons/Magic/Tomes/UmosShower_Glow").Value;
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