using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private Vector3 destination;
    
    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
    }

    public Vector3 GetDestination()
    {
        return destination;
    }
}
