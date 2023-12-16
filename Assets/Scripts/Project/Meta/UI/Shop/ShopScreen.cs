using BasisCore.Runtime.UI.Screens;

namespace Project.Meta.UI.Shop
{
    public sealed class ShopScreen : BaseScreen<ShopScreenViewModel>, IShopScreen
    {
        public ShopScreen(
            IScreenAnimationService screenAnimationService, 
            ShopScreenViewModel screenViewModel) : 
            base(screenAnimationService, screenViewModel)
        {
        }

        protected override void OnShow()
        {
        }

        protected override void OnHide()
        {
        }
    }
}