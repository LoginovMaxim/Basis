using BasisCore.Runtime.UI.Screens;

namespace Project.Meta.UI.Shop
{
    public sealed class ShopScreenController : BaseScreenController<ShopScreenModel, ShopScreenView>, IShopScreenController
    {
        public ShopScreenController(
            ShopScreenModel screenModel, 
            ShopScreenView screenView, 
            IScreenAnimationService screenAnimationService) : 
            base(screenModel, screenView, screenAnimationService)
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