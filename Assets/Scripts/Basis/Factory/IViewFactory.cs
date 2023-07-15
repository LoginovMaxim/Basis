namespace Basis.Factory
{
    public interface IViewFactory<TViewObject, TViewPayload>
    {
        void CreateView(int entityId, TViewPayload viewPayload);
        void ReleaseView(int entityId);
    }
}