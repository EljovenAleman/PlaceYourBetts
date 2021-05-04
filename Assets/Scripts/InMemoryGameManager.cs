using System.Threading.Tasks;
using UnityEngine;

public class InMemoryGameManager : IGameManager
{    
    public Task<int> ReturnNumber()
    {
        System.Random numberGenerator = new System.Random();

        int randomNumber = numberGenerator.Next(0, 38);

        Debug.Log("Random number: "+randomNumber);

        return Task.FromResult(randomNumber);        
    }
}
