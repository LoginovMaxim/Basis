namespace Basis.UI.Splashes
{
    public interface ISplash
    {
        void Show();
        void AddProgressService(IProgress progress);
    }
}