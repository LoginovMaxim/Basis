using App.UI.Screens.Logics;
using UnityEngine;

namespace Example.Meta.UI.ShopScreen
{
    public sealed class SampleShopScreen : BaseScreen<SampleShopScreenViewModel>, ISampleShopScreen
    {
        public SampleShopScreen(SampleShopScreenViewModel screenViewModel, int id) : base(screenViewModel, id)
        {
        }

        protected override void OnShow()
        {
            Debug.Log("Show shop screen");
        }

        protected override void OnHide()
        {
            Debug.Log("Hide shop screen");
        }
    }
}