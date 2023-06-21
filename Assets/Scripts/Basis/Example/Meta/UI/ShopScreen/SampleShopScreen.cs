using Basis.App.UI.Screens.Logics;
using UnityEngine;

namespace Basis.Example.Meta.UI.ShopScreen
{
    public sealed class SampleShopScreen : BaseScreen<SampleShopScreenViewModel>, ISampleShopScreen
    {
        public SampleShopScreen(SampleShopScreenViewModel screenViewModel, int id) : base(screenViewModel, id)
        {
        }

        public override void OnShow()
        {
            Debug.Log("Show shop screen");
        }

        public override void OnHide()
        {
            Debug.Log("Hide shop screen");
        }
    }
}