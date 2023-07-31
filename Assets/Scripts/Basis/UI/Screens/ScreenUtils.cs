using UnityEngine;

namespace Basis.UI.Screens
{
    public static class ScreenUtils
    {
        public static Vector2 ScreenCenterPosition = new Vector2(Screen.width / 2f, Screen.height / 2f);
        public static Vector2 ScreenLeftPosition = new Vector2(Screen.width / 2f - Screen.width, Screen.height / 2f);
        public static Vector2 ScreenRightPosition = new Vector2(Screen.width / 2f + Screen.width, Screen.height / 2f);
        public static Vector2 ScreenUpPosition = new Vector2(Screen.width / 2f, Screen.height / 2f + Screen.height);
        public static Vector2 ScreenDownPosition = new Vector2(Screen.width / 2f, Screen.height / 2f - Screen.height);
    }
}