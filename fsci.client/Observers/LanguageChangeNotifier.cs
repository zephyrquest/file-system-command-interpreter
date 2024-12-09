namespace fsci.client.Observers;

public class LanguageChangeNotifier : ILanguageChangeNotifier
{
    private readonly List<ILanguageObserver> _languageObservers = new();
    
    public void AddObserver(ILanguageObserver observer)
    {
        _languageObservers.Add(observer);
    }

    public void RemoveObserver(ILanguageObserver languageObserver)
    {
        _languageObservers.Remove(languageObserver);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _languageObservers)
        {
            observer.Translate();
        }
    }
}