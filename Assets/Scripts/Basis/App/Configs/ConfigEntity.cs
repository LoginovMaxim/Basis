using System;

namespace Basis.App.Configs
{
    [Serializable] public abstract class ConfigEntity : IConfigEntity
    {
        public string Id;

        #region IConfigEntity

        string IConfigEntity.Id => Id;

        #endregion
    }
}