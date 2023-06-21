using Basis.App.UI.Screens.Logics;
using UnityEngine;

namespace Basis.Example.Meta.UI.ChestScreen
{
    public class SampleChestScreen : BaseScreen<SampleChestScreenViewModel>, ISampleChestScreen
    {
        public SampleChestScreen(SampleChestScreenViewModel screenViewModel, int id) : base(screenViewModel, id)
        {
        }

        public override void OnShow()
        {
            Debug.Log("Show chest screen");
        }

        public override void OnHide()
        {
            Debug.Log("Show chest screen");
        }
    }
}