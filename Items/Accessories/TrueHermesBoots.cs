using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MultidimensionMod.Common.Players;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
    [AutoloadEquip(EquipType.Wings)]
    public class TrueHermesBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(130, 7f, 1.5f);
        }

        public override void SetDefaults()
        {
            Item.width = 46;
            Item.height = 50;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.rare = ItemRarityID.LightRed;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.85f; // Falling glide speed
            ascentWhenRising = 0.15f; // Rising speed
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 2.5f;
            constantAscend = 0.135f;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.accRunSpeed = 7.25f;
            player.desertBoots = true;
            player.GetModPlayer<MDPlayer>().FlurryAdd = true;
            player.GetModPlayer<MDPlayer>().SailfishAdd = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.HermesBoots)
            .AddIngredient(ItemID.SandBoots)
            .AddIngredient(ItemID.FlurryBoots)
            .AddIngredient(ItemID.SailfishBoots)
            .AddIngredient(ItemID.SoulofFlight, 20)
            .AddCondition(Language.GetOrRegister("Mods.MultidimensionMod.MiscText.EnabledBootsCondition"), () => ModContent.GetInstance<MDConfig>().BootAccessoryAdditions)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}