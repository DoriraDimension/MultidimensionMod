using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;

namespace MultidimensionMod.Items.Accessories
{
	public class StinkyPaste : ModItem
	{
		public static readonly SoundStyle Stink = new SoundStyle("MultidimensionMod/Sounds/Custom/Stinky");
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 30;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.UseSound = Stink;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 20, 0);
			Item.rare = ItemRarityID.Green;
			Item.buffType = (BuffID.Stinky);
			Item.buffTime = 14400;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Summon) += 0.06f;
		}
	}
}