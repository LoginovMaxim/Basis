using System;

namespace Basis.Configs.BinaryConfigs
{
    public sealed class SerializationBinder : System.Runtime.Serialization.SerializationBinder
    {
        private readonly string _prevSubString;
        private readonly string _nextSubString;

        public SerializationBinder(string prevSubString, string nextSubString)
        {
            _prevSubString = prevSubString;
            _nextSubString = nextSubString;
        }

        public override void BindToName(Type type, out string assemblyName, out string typeName)
        {
            assemblyName = type.Assembly.FullName.Replace(_prevSubString, _nextSubString);
            typeName = type.FullName.Replace(_prevSubString, _nextSubString);
        }

        public override Type BindToType(string assemblyName, string typeName)
        {
            var fullTypeName = $"{ typeName.Replace(_prevSubString, _nextSubString) }, { assemblyName.Replace(_prevSubString, _nextSubString) }";
            return Type.GetType(fullTypeName);
        }
    }
}