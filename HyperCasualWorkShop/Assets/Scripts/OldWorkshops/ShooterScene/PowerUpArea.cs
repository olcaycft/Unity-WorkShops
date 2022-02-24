using System;
using UnityEngine;

namespace ShooterScene
{
    public class PowerUpArea : MonoBehaviour
    {
        private Collider _collider;
        private Collider collider => _collider = GetComponent<Collider>();

        private Collider[] results;
        
        [SerializeField] private int speedUpCount = 0;
        private Vector3 size;
        public static event Action SpeedUp;
        public static event Action MissileCountUp;
        private void Awake()
        {
            Vector3 size = collider.bounds.size;
            results = new Collider[10];
        }


        /*private void CollisionChecker()
        {
            int amount = Physics.OverlapBoxNonAlloc(transform.position, size/2, results);
            for (int i = 0; i < amount; i++)
            {
                GameObject hit = results[i].gameObject;
                if (hit.gameObject.CompareTag("SpeedUp"))
                {
                    speedUpCount++;
                    Debug.Log("hey");
                }
            }

            SpeedUp?.Invoke(speedUpCount);
        }*/
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("SpeedUp"))
            {
                speedUpCount++;
                Debug.Log("hey");
                SpeedUp?.Invoke();
            }

            if (other.gameObject.CompareTag("CountUp"))
            {
                MissileCountUp?.Invoke();
            }
        }
    }
}