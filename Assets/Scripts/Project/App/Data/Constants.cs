using Basis.UI.Screens;

namespace Project.App.Data
{
    public static class Constants
    {
        public static class ScreenAnimation
        {
            public const ScreenShowingType DefaultScreenShowingType = ScreenShowingType.FadeOut;
            public const ScreenHidingType DefaultScreenHidingType = ScreenHidingType.FadeIn;
        }
        
        public static class Scenes
        {
            public const string MetaScenePath = "Scenes/Meta";
            public const string MatchScenePath = "Scenes/Match";
            public const string LevelScenePath = "Scenes/Levels/Level-{0}/Level-{0}";
        }
    }
}