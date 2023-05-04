using App.UI.Screens.Logics;
using UnityEngine;

namespace Example.Match.UI.GameplayScreen
{
    public class SampleGameplayScreen : BaseScreen<SampleGameplayScreenViewModel>, ISampleGameplayScreen
    {
        public SampleGameplayScreen(SampleGameplayScreenViewModel screenViewModel, int id) : base(screenViewModel, id)
        {
        }

        protected override void OnShow()
        {
            Debug.Log("Show gameplay screen");
        }

        protected override void OnHide()
        {
            Debug.Log("Hide gameplay screen");
        }
    }
}