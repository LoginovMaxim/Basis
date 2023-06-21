using Basis.App.UI.Screens.Logics;
using UnityEngine;

namespace Basis.Example.Match.UI.GameplayScreen
{
    public class SampleGameplayScreen : BaseScreen<SampleGameplayScreenViewModel>, ISampleGameplayScreen
    {
        public SampleGameplayScreen(SampleGameplayScreenViewModel screenViewModel, int id) : base(screenViewModel, id)
        {
        }

        public override void OnShow()
        {
            Debug.Log("Show gameplay screen");
        }

        public override void OnHide()
        {
            Debug.Log("Hide gameplay screen");
        }
    }
}