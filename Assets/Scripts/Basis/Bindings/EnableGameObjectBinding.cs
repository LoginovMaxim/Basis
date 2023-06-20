using System;
using UnityEngine;
using UnityWeld.Binding;
using UnityWeld.Binding.Internal;

namespace Basis.Bindings
{
    public class EnableGameObjectBinding : AbstractMemberBinding
    {
        [SerializeField]
        private string viewAdapterTypeName;
        [SerializeField]
        private AdapterOptions viewAdapterOptions;
        [SerializeField]
        private string viewModelPropertyName;
        private PropertyWatcher viewModelWatcher;

        public string ViewAdapterTypeName
        {
            get => this.viewAdapterTypeName;
            set => this.viewAdapterTypeName = value;
        }

        public AdapterOptions ViewAdapterOptions
        {
            get => this.viewAdapterOptions;
            set => this.viewAdapterOptions = value;
        }

        public string ViewModelPropertyName
        {
            get => this.viewModelPropertyName;
            set => this.viewModelPropertyName = value;
        }

        public bool GameObjectActive
        {
            set => gameObject.SetActive(value);
        }

        public override void Connect()
        {
            PropertyEndPoint source = this.MakeViewModelEndPoint(this.viewModelPropertyName, (string) null, (AdapterOptions) null);
            PropertySync propertySync = new PropertySync(source, new PropertyEndPoint((object) this, "GameObjectActive", AbstractMemberBinding.CreateAdapter(this.viewAdapterTypeName), this.viewAdapterOptions, "view", (Component) this), (PropertyEndPoint) null, (Component) this);
            this.viewModelWatcher = source.Watch((Action) (() => propertySync.SyncFromSource()));
            propertySync.SyncFromSource();
        }

        public override void Disconnect()
        {
            if (this.viewModelWatcher == null)
                return;
            this.viewModelWatcher.Dispose();
            this.viewModelWatcher = (PropertyWatcher) null;
        }
    }
}