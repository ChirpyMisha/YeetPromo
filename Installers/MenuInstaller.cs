using Zenject;

namespace YeetPromo
{
	class MenuInstaller : Installer
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<PromoYeeter>().AsSingle();
		}
	}
}
