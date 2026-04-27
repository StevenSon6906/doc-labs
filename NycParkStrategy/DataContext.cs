using NycParkStrategy.Strategies;

namespace NycParkStrategy;

public class DataContext
{
    private IOutputStrategy _strategy;

    public DataContext(IOutputStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IOutputStrategy strategy)
    {
        _strategy = strategy;
    }

    public void Output(object data)
    {
        _strategy.Write(data);
    }

    public void Close()
    {
        _strategy.Close();
    }
}