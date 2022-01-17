using UnityEngine;

public class SetDestination : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.SetDestination(transform.position);
    }
}
