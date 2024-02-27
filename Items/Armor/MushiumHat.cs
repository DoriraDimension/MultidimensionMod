using MultidimensionMod.Items.Materials;
using MultidimensionMod.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;


namespace MultidimensionMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
	public class MushiumHat : ModItem
	{

        public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Mushium Hat");
            //Tooltip.SetDefault("1% Increased life regeneration");
        }

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 16;
			Item.value = 90;
			Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 25, 0);
            Item.defense = 3;
		}

        public override void Load()
        {
            // The code below runs only if we're not loading on a server
            if (Main.netMode == NetmodeID.Server)
                return;

            // Add equip textures
            EquipLoader.AddEquipTexture(Mod, $"MultidimensionMod/Items/Armor/MushiumShirtIndigo_{EquipType.Body}", EquipType.Body, this);
            EquipLoader.AddEquipTexture(Mod, $"MultidimensionMod/Items/Armor/MushiumPantsIndigo_{EquipType.Legs}", EquipType.Legs, this);
        }


        public override void UpdateEquip(Player player)
        {
            player.statLifeMax2 += 5;
            player.statManaMax2 += 10;
            player.GetDamage(DamageClass.Generic) += 0.02f;
        }

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<MushiumShirt>() && legs.type == ModContent.ItemType<MushiumPants>();
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = Language.GetTextValue("Mods.MultidimensionMod.SetBonuses.MushiumSet");
			player.GetModPlayer<MDPlayer>().MushiumSet = true;
            if (player.GetModPlayer<MDPlayer>().IndigoMode)
			{
				player.manaRegenBonus += 3;
                player.maxTurrets += 1;
				player.statDefense -= 4;
            }
			else if (!player.GetModPlayer<MDPlayer>().IndigoMode)
			{
				player.lifeRegen += 3;
				player.statDefense += 4;
            }

        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Mushmatter>(), 2)
            .AddIngredient(ModContent.ItemType<GlowingMushmatter>(), 2)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }

    public class IndigoModePlayer : ModPlayer
    {
        public override void FrameEffects()
        {
            // TODO: Need new hook, FrameEffects doesn't run while paused.
            if (Player.GetModPlayer<MDPlayer>().MushiumSet && Player.GetModPlayer<MDPlayer>().IndigoMode)
            {
                var indigoTexture = ModContent.GetInstance<MushiumHat>();
                Player.body = EquipLoader.GetEquipSlot(Mod, indigoTexture.Name, EquipType.Body);
                Player.legs = EquipLoader.GetEquipSlot(Mod, indigoTexture.Name, EquipType.Legs);
            }
            if (Player.GetModPlayer<MDPlayer>().MushiumSet && Player.GetModPlayer<MDPlayer>().IndigoMode)
            {
                var indigoTexture = ModContent.GetInstance<MushiumPants>();
                Player.head = EquipLoader.GetEquipSlot(Mod, indigoTexture.Name, EquipType.Head);
            }
        }
    }
}