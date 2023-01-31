using Terraria.GameContent.UI;

namespace MultidimensionMod
{
	public class MDCurrency : CustomCurrencySingleCoin
	{
		public MDCurrency(int coinItemID, long currencyCap, string CurrencyTextKey) : base(coinItemID, currencyCap)
		{
			this.CurrencyTextKey = CurrencyTextKey;
			CurrencyTextColor = MDColors.DoriraColor;
		}
	}
}
