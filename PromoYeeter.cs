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

		public PromoYeeter(MainMenuViewController mainMenuView)
		{
			this.mainMenuView = mainMenuView;
		}

		public void Initialize()
		{
			Plugin.Log.Notice("DabYeeter initting");

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
			{
				GameObject promoObj = GameObject.Find("MusicPackPromoBanner");
				if (promoObj != null)
					promoObj.SetActive(false);
				else
					Plugin.Log.Notice("PromoYeeter, MainMenuView_didActivateEvent, Couldn't find MusicPackPromoBanner");
			}
		}
	}
}
