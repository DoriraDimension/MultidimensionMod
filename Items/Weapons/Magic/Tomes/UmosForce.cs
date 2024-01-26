using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
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

namespace MultidimensionMod.Items.Weapons.Magic.Tomes
{
    public class UmosForce : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }


        public override void SetDefaults()
        {
            Item.damage = 38;
            Item.DamageType = DamageClass.Magic;
            Item.width = 50;
            Item.height = 39;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 0.5f;
            Item.noUseGraphic = true;
            Item.value = Item.sellPrice(0, 0, 55, 0);
            Item.rare = ItemRarityID.Green;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<ConsumedBook>();
            Item.shootSpeed = 1f;
            Item.channel = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.UmosForce.Lore"))
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
                Projectile.NewProjectile(source, player.Center.X, player.Center.Y, 1, 1, ModContent.ProjectileType<ConsumedBook>(), damage, 0);
            }
            if (player.ownedProjectileCounts[Item.shoot] <= 0 || player.ownedProjectileCounts[ModContent.ProjectileType<LightSphereMouse>()] <= 0)
            {
                Projectile.NewProjectile(source, player.Center.X, player.Center.Y, 0, -16, ModContent.ProjectileType<UmosLightSphere>(), damage, knockback, player.whoAmI);
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
            .AddIngredient(ModContent.ItemType<UmosShower>())
            .AddIngredient(ModContent.ItemType<Mushmatter>(), 5)
            .AddIngredient(ItemID.SoulofLight, 9)
            .AddIngredient(ModContent.ItemType<Dimensium>(), 7)
            .AddTile(ModContent.TileType<DimensionalForge>())
            .Register();
        }
    }
}