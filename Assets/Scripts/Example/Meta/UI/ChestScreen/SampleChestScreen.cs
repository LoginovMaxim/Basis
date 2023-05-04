using App.UI.Screens.Logics;
using UnityEngine;

namespace Example.Meta.UI.ChestScreen
{
    public class SampleChestScreen : BaseScreen<SampleChestScreenViewModel>, ISampleChestScreen
    {
        public SampleChestScreen(SampleChestScreenViewModel screenViewModel, int id) : base(screenViewModel, id)
        {
        }

        protected override void OnShow()
        {
            Debug.Log("Show chest screen");
        }

        protected override void OnHide()
        {
            Debug.Log("Show chest screen");
        }
    }
}