namespace Radon.DTOs.Interfaces
{
    public interface IFactory<T>
    {
        T Create(string[] args);
    }
}
