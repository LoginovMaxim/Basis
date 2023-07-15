using Basis.UI.Screens;

namespace Project.App.Data
{
    public static class Constants
    {
        public static class MetaBundleKeys
        {
            public const string MetaSceneKey = "Meta";
        }
        
        public static class MatchBundleKeys
        {
            public const string MatchSceneKey = "Match";
        }
        
        public static class LevelBundleKeys
        {
            public const string LevelSceneKey = "Level-{0}";
        }
        
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