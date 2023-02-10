namespace Editor.Configs
{
    public interface ISheetRow
    {
        int Length { get; }
        object this[string name] { get; }
        object GetValue(string name);
        object GetValueByIndex(int i);
        string GetValueAsString(string name);
        bool GetValueAsBool(string name);
        int GetValueAsInt(string name);
        float GetValueAsFloat(string name);
    }
}