using UnityEditor;

namespace Basis.Editor.Utils
{
    public static class PlaySceneUtils
    {
        [MenuItem("Basis/Play bootstrap")]
        public static void PlayMetaScene()
        {
            if (EditorApplication.isPlaying)
            {
                EditorApplication.isPlaying = false;
                return;
            }
     
            EditorApplication.SaveCurrentSceneIfUserWantsTo();
            EditorApplication.OpenScene("Assets/Scenes/Bootstrap.unity");
            EditorApplication.isPlaying = true;
        }
    }
}