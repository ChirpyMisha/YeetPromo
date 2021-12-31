using IPA.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace YeetPromo
{
	class PromoYeeter : IInitializable, IDisposable
	{
		private static FieldAccessor<MainMenuViewController, Button>.Accessor PromoButton = FieldAccessor<MainMenuViewController, Button>.GetAccessor("_musicPackPromoButton");

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
				Plugin.Log.Error("DabYeeter couldn't initialize. mainMenuView == null");

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
			
			Plugin.Log.Warn("PromoYeeter, FindPromoButton, Couldn't find MusicPackPromoBanner");
			return false;
		}

		private void ScarePromoButton()
		{
			promoButton.SetActive(false);
			Plugin.Log.Info("Promo Yeeter scared the promo button");
		}
	}
}
