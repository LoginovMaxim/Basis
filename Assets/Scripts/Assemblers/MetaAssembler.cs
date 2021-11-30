using Monos;
using UnityEngine;
using ViewModels;
using Zenject;

namespace Assemblers
{
    public class MetaAssembler : Assembler
    {
        [SerializeField] private string _gameSceneName;
        
        private SceneLoader _sceneLoader;
        
        [Inject]
        public void Inject(
            SceneLoader sceneLoader,
            Localization localization)
        {
            _sceneLoader = sceneLoader;
            
            InitializeAssemblerParts(
                localization);
        }

        public void LoadGameScene()
        {
            _sceneLoader.LoadScenes(_gameSceneName);
        }
    }
}