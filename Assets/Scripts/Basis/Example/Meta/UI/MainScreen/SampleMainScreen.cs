using Basis.App.UI.Screens.Logics;
using UnityEngine;

namespace Basis.Example.Meta.UI.MainScreen
{
    public sealed class SampleMainScreen : BaseScreen<SampleMainScreenViewModel>, ISampleMainScreen
    {
        public SampleMainScreen(SampleMainScreenViewModel screenViewModel, int id) : base(screenViewModel, id)
        {
        }

        public override void OnShow()
        {
            Debug.Log("Show main screen");
        }

        public override void OnHide()
        {
            Debug.Log("Hide main screen");
        }
    }
}