using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles.Furniture.VoidMatter;
using MultidimensionMod.Projectiles.Ranged;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
    public class BorealGreatbow : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 41;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 24;
            Item.height = 30;
            Item.useTime = 80;
            Item.useAnimation = 80;
            Item.reuseDelay = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 14;
            Item.value = Item.sellPrice(0, 0, 70, 0);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 20f;
            Item.useAmmo = AmmoID.Arrow;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
             type = ModContent.ProjectileType<FrostGreatarrow>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<VikingRelic>(), 4)
            .AddIngredient(ItemID.BorealWood, 12)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}