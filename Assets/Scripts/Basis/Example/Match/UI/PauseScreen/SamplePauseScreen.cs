using Basis.App.UI.Screens.Logics;
using UnityEngine;

namespace Basis.Example.Match.UI.PauseScreen
{
    public sealed class SamplePauseScreen : BaseScreen<SamplePauseScreenViewModel>, ISamplePauseScreen
    {
        public SamplePauseScreen(SamplePauseScreenViewModel screenViewModel, int id) : base(screenViewModel, id)
        {
        }

        protected override void OnShow()
        {
            Debug.Log("Show pause screen");
        }

        protected override void OnHide()
        {
            Debug.Log("Show pause screen");
        }
    }
}