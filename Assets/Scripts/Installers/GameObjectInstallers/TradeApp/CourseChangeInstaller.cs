using Presenters.CryptoCourse.BitcoinCryptoCourseChange;
using Presenters.CryptoCourse.EtheriumCryptoCourseChange;
using Presenters.CryptoCourse.SolanaCourseCryptoChange;
using Zenject;

namespace Installers.GameObjectInstallers.TradeApp
{

    public class CourseChangeInstaller : MonoInstaller<CourseChangeInstaller>
    {
        public override void InstallBindings()
        {
            BindBitcoin();
            BindEtherium();
            BindSolana();
        }

        private void BindSolana()
        {
            Container.Bind<SolanaCourseCryptoChangePresenter>()
                .AsSingle()
                .NonLazy();
        }

        private void BindEtherium()
        {
            Container.Bind<EtheriumCourseCryptoChangePresenter>()
                .AsSingle()
                .NonLazy();
        }

        private void BindBitcoin()
        {
            Container.Bind<BitcoinCourseCryptoChangePresenter>()
                .AsSingle()
                .NonLazy();
        }
    }

}