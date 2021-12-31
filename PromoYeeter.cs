using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

namespace YeetPromo
{
	class PromoYeeter : IInitializable, IDisposable
	{
		private MainMenuViewController mainMenuView;

		GameObject promoButton;

		public PromoYeeter(MainMenuViewController mainMenuView)
		{
			this.mainMenuView = mainMenuView;
		}

		public void Initialize()
		{
			if (mainMenuView != null)
				mainMenuView.didActivateEvent += MainMenuView_didActivateEvent;
			else
				Plugin.Log.Error(GetLogString("PromoYeeter couldn't initialize. mainMenuView == null"));

		}

		public void Dispose()
		{
			if (mainMenuView != null)
				mainMenuView.didActivateEvent -= MainMenuView_didActivateEvent;
		}
		private void MainMenuView_didActivateEvent(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
		{
			if (firstActivation) 
				MenuOnFirstActivation();
		}

		private void MenuOnFirstActivation()
		{
			if (FindPromoButton())
				ScarePromoButton();
		}

		private bool FindPromoButton()
		{
			promoButton = GameObject.Find("MusicPackPromoBanner");
			if (promoButton != null)
				return true;
			
			Plugin.Log.Warn(GetLogString("Couldn't find MusicPackPromoBanner."));
			return false;
		}

		private void ScarePromoButton()
		{
			promoButton.SetActive(false);
			Plugin.Log.Info("Promo Yeeter scared the promo button.");
		}

		private string GetLogString(string logMessage, [CallerMemberName] string callerMethodName = "")
		{
			return $"Class: PromoYeeter, Method: {callerMethodName}, Message: {logMessage}";
		}
	}
}
