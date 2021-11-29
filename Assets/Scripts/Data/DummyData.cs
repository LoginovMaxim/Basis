using System;

namespace Data
{
    public class DummyData : IData
    {
        public event Action DataChanged;
    }
}