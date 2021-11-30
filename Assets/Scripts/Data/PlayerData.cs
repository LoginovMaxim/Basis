using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class PlayerData : IData
    {
        public event Action DataChanged;

        public string Name
        {
            get => name;
            set
            {
                if (name == value)
                    return;

                name = value;
                DataChanged?.Invoke();
            }
        }
        
        public int Level
        {
            get => level;
            set
            {
                if (level == value)
                    return;

                level = value;
                DataChanged?.Invoke();
            }
        }
        
        public int Experience
        {
            get => experience;
            set
            {
                if (experience == value)
                    return;

                experience = value;
                DataChanged?.Invoke();
            }
        }

        [SerializeField] private string name;
        [SerializeField] private int level;
        [SerializeField] private int experience;
    }
}