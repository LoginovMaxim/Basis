using System.Collections.Generic;
using Basis.UI.Popups.ViewModels;
using Basis.UI.Signals;
using Zenject;

namespace Basis.UI.Popups.Logics
{
    public sealed class IconPopup : IIconPopup
    {
        private readonly IconPopupViewModel.Pool _pool;
        
        public bool Spawned => _iconPopups.Count > 0;
        
        private Dictionary<int, IconPopupViewModel> _iconPopups = new Dictionary<int, IconPopupViewModel>();
        
        private static int _popupIndex;
        
        public IconPopup(IconPopupViewModel.Pool pool, SignalBus signalBus)
        {
            _pool = pool;
            signalBus.Subscribe<ClosePopupSignal>(x => Despawn(x.PopupIndex));
        }

        public void Spawn(IconPopupData iconPopupData)
        {
            iconPopupData.Index = ++_popupIndex;
            var viewModel = _pool.Spawn(iconPopupData);
            _iconPopups.Add(_popupIndex, viewModel);
        }

        public void Despawn(int index)
        {
            if (!_iconPopups.ContainsKey(index))
            {
                return;
            }
            
            _pool.Despawn(_iconPopups[index]);
            _iconPopups.Remove(index);
        }
    }
}