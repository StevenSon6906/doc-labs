namespace NycParkStrategy.Strategies;

public interface IOutputStrategy
{
    void Write(object data);
    void Close() { }
}