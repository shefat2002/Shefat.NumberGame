namespace Shefat.NumberGame.Services;

public interface INumberService
{
    Task<int[]> GenerateNumbersAsync(int count);
}