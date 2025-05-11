using BasisCore.Launchers;
using Zenject;

namespace Basis.Core.Launchers
{
    public sealed class TestInitialLaunchGraph : LaunchGraph, IInitializable
    {
        public void Initialize()
        {
            Test1();
            //Test2();
        }

        private void Test1()
        {
            var correctLauncher = new CorrectLauncher();
            var incorrectLauncher = new IncorrectLauncher(LauncherType.Required);
            
            var correctNode = new LaunchNode(correctLauncher, LauncherType.Required, ExecutionMode.Sequential);
            var incorrectNode = new LaunchNode(incorrectLauncher, LauncherType.Required, ExecutionMode.Sequential);
            
            _roots.Add(correctNode);
            correctNode.AddChildNode(incorrectNode);
        }

        private void Test2()
        {
            var correctLauncher = new CorrectLauncher();
            var incorrectLauncher = new IncorrectLauncher(LauncherType.Required);
            
            var correctNode = new LaunchNode(correctLauncher, LauncherType.Required, ExecutionMode.Sequential);
            var incorrectNode = new LaunchNode(incorrectLauncher, LauncherType.Required, ExecutionMode.Sequential);
            
            _roots.Add(correctNode);
            _roots.Add(correctNode);
            correctNode.AddChildNode(incorrectNode);
            
            LauncherManager.Instance.StartLaunchGraph(this);
        }
    }
}