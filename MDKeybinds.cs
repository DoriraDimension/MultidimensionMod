using Terraria.ModLoader;

namespace MultidimensionMod
{
	public class MDKeybinds : ModSystem
	{
		public static ModKeybind RoseScarfKey 
		{ 
			get; 
			private set; 
		}
		public static ModKeybind ArmorAbility
		{
			get;
			private set;
		}

		public override void Load()
		{
			RoseScarfKey = KeybindLoader.RegisterKeybind(Mod, "Rose Venom", "Y");
			ArmorAbility = KeybindLoader.RegisterKeybind(Mod, "Armor Ability", "C");
		}

		public override void Unload()
		{
			RoseScarfKey = null;
			ArmorAbility = null;
		}
	}
}