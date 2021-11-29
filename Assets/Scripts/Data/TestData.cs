using System;

namespace Data
{
    [Serializable]
    public class TestData : ITestData
    {
        public event Action SomethingHappened;
        
        public string StringValue
        {
            get => _stringValue;
            set
            {
                if (_stringValue == value)
                    return;

                _stringValue = value;
                SomethingHappened?.Invoke();
            }
        }
        
        public int IntValue
        {
            get => _intValue;
            set
            {
                if (_intValue == value)
                    return;

                _intValue = value;
                SomethingHappened?.Invoke();
            }
        }
        
        private int _intValue = 10;
        private string _stringValue = "Moscow";
    }
}