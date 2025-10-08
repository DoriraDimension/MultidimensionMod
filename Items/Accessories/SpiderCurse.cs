using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MultidimensionMod.Common.Players;
using Terraria.Audio;
using Terraria.DataStructures;

namespace MultidimensionMod.Items.Accessories
{
	public class SpiderCurse : ModItem
	{

        public override void Load()
        {
            // The code below runs only if we're not loading on a server
            if (Main.netMode == NetmodeID.Server)
                return;

            // Add equip textures
            EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Head}", EquipType.Head, this);
            EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Body}", EquipType.Body, this);
            EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Legs}", EquipType.Legs, this);
        }

        // Called in SetStaticDefaults
        private void SetupDrawing()
        {
            // Since the equipment textures weren't loaded on the server, we can't have this code running server-side
            if (Main.netMode == NetmodeID.Server)
                return;

            int equipSlotHead = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Head);
            int equipSlotBody = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body);
            int equipSlotLegs = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Legs);

            ArmorIDs.Head.Sets.DrawHead[equipSlotHead] = false;
            ArmorIDs.Body.Sets.HidesTopSkin[equipSlotBody] = true;
            ArmorIDs.Body.Sets.HidesArms[equipSlotBody] = true;
            ArmorIDs.Legs.Sets.HidesBottomSkin[equipSlotLegs] = true;
        }

        public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            SetupDrawing();
        }

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 34;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 1, 50, 0);
			Item.rare = ItemRarityID.LightRed;
            Item.hasVanityEffects = true;
        }

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.spikedBoots += 2;
			player.buffImmune[BuffID.Webbed] = true;
            player.GetModPlayer<MDPlayer>().EggPouch = true;
            var p = player.GetModPlayer<SpiderCurseVisualPlayer>();
            p.SpiderCurseVisuals = true;
            p.SpiderCurseHideVanity = hideVisual;
        }

        public override void UpdateVanity(Player player)
        {
            var p = player.GetModPlayer<SpiderCurseVisualPlayer>();
            p.SpiderCurseHideVanity = false;
            p.SpiderCurseForceVanity = true;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Accessories/SpiderCurse_Glow").Value;
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

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<EggPouch>())
            .AddIngredient(ItemID.TigerClimbingGear)
            .AddIngredient(ItemID.SpiderFang, 10)
            .AddIngredient(ItemID.Cobweb, 25)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }

    public class SpiderCurseVisualPlayer : ModPlayer
    {
        public bool SpiderCurseVisualsPrevious;
        public bool SpiderCurseVisuals;             // If true, an accessory granting potential effects is equipped
        public bool SpiderCurseHideVanity;            // If true, the item is in a hidden accessory slot
        public bool SpiderCurseForceVanity;           //	If true, the vanity is forced because the item is in a vanity slot, not the stats.
        public bool SpiderCurseVanityEffects => SpiderCurseForceVanity || (Player.GetModPlayer<MDPlayer>().EggPouch && !SpiderCurseHideVanity); // This helper property controls if the audio and visual effects of the vanity should be applied.

        public override void ResetEffects()
        {
            SpiderCurseVisualsPrevious = SpiderCurseVisuals;
            SpiderCurseVisuals = SpiderCurseHideVanity = SpiderCurseForceVanity = false;
        }

        public override void FrameEffects()
        {
            // TODO: Need new hook, FrameEffects doesn't run while paused.
            if (SpiderCurseVanityEffects)
            {
                var spood = ModContent.GetInstance<SpiderCurse>();
                Player.head = EquipLoader.GetEquipSlot(Mod, spood.Name, EquipType.Head);
                Player.body = EquipLoader.GetEquipSlot(Mod, spood.Name, EquipType.Body);
                Player.legs = EquipLoader.GetEquipSlot(Mod, spood.Name, EquipType.Legs);
            }
        }

        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
            if (SpiderCurseVanityEffects)
            {
                modifiers.DisableSound();
            }
        }

        public override void OnHurt(Player.HurtInfo info)
        {
            if (SpiderCurseVanityEffects)
            {
                SoundEngine.PlaySound(SoundID.NPCHit29, Player.position);
            }
        }
    }
}