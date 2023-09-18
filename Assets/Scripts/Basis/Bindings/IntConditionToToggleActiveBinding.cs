using System;
using UnityEngine;
using UnityWeld.Binding;
using UnityWeld.Binding.Internal;

namespace Basis.Bindings
{
    [AddComponentMenu("Unity Weld/ToggleActive By Int Condition Binding")]
	public sealed class IntConditionToToggleActiveBinding : AbstractMemberBinding
	{
		public string ViewAdapterTypeName
        {
            get => viewAdapterTypeName;
            set => viewAdapterTypeName = value; 
        }

        [SerializeField]
        private string viewAdapterTypeName;
        
        public AdapterOptions ViewAdapterOptions
        {
            get => viewAdapterOptions; 
            set => viewAdapterOptions = value; 
        }

        [SerializeField]
        private AdapterOptions viewAdapterOptions;

        public string ViewModelPropertyName
        {
            get => viewModelPropertyName; 
            set => viewModelPropertyName = value; 
        }

        [SerializeField]
        private string viewModelPropertyName;

        private PropertyWatcher viewModelWatcher;

        [SerializeField] private int intTriggerToActive;

        public int IntTriggerToActive
        {
            get => intTriggerToActive;
            set => intTriggerToActive = value;
        }

        [SerializeField] private Condition conditionChecker;

        public Condition ConditionChecker
        {
            get => conditionChecker;
            set => conditionChecker = value;
        }
        
        public int TriggerChildrenActive
        {
            set
            {
                var active = true;
                switch (ConditionChecker)
                {
                    case Condition.Less:
                        active = value < intTriggerToActive;
                        break;
                    case Condition.LessOrEquals:
                        active = value <= intTriggerToActive;
                        break;
                    case Condition.Equals:
                        active = value == intTriggerToActive;
                        break;
                    case Condition.NotEquals:
                        active = value != intTriggerToActive;
                        break;
                    case Condition.MoreOrEquals:
                        active = value >= intTriggerToActive;
                        break;
                    case Condition.More:
                        active = value > intTriggerToActive;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
               
                SetAllChildrenActive(active);
            }
        }


        public override void Connect()
        {
            TriggerChildrenActive = 0;
            var viewModelEndPoint = MakeViewModelEndPoint(viewModelPropertyName, null, null);

            var propertySync = new PropertySync(
                viewModelEndPoint,
                new PropertyEndPoint(
                    this,
                    "TriggerChildrenActive",
                    CreateAdapter(viewAdapterTypeName),
                    viewAdapterOptions,
                    "view",
                    this
                ),
                null,
                this
            );

            viewModelWatcher = viewModelEndPoint.Watch(
                () => propertySync.SyncFromSource()
            );

            propertySync.SyncFromSource();
        }

        public override void Disconnect()
        {
            if (viewModelWatcher != null)
            {
                viewModelWatcher.Dispose();
                viewModelWatcher = null;
            }
        }

        private void SetAllChildrenActive(bool active)
        {
            foreach (Transform child in transform)
            {
                //if (child != transform)
                    child.gameObject.SetActive(active);
            }
        }
        
        public enum Condition
        {
            Less,
            LessOrEquals,
            Equals,
            NotEquals,
            MoreOrEquals,
            More,
        }
	}
}