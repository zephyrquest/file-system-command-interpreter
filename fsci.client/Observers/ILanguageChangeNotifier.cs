namespace fsci.client.Observers;

public interface ILanguageChangeNotifier
{
    void AddObserver(ILanguageObserver observer);
    void RemoveObserver(ILanguageObserver observer);
    void NotifyObservers();
}