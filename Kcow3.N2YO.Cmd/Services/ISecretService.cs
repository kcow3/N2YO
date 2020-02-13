namespace Kcow3.N2YO.Cmd.Services
{
    public interface ISecretService
    {
        string GetApiKey();
        double GetObserverLng();
        double GetObserverLat();
    }
}
