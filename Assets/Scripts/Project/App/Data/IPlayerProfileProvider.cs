namespace Basis.Data
{
    public interface IPlayerProfileProvider
    {
        public string Id { get; }
        public string Name { get; }
        public int Level { get; }
        public int Experience { get; }
        public int Soft { get; }
        public int Hard { get; }
    }
}