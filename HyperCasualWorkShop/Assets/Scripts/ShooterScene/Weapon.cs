using System;
using System.Collections;
using UnityEngine;

namespace ShooterScene
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]private GameObject missile;
        [SerializeField] private float spawnRate = 1f;
        public static event Action UpDamage;

        private void Awake()
        {
            StartCoroutine(nameof(GenerateMissileRoutine), 3f);
        }


        private IEnumerator GenerateMissileRoutine()
        {
            while (true)
            {
                Instantiate(missile,transform.position,Quaternion.identity);
                yield return new WaitForSeconds(spawnRate);
            }
            
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("DamageUpper"))
            {
                Destroy(other.gameObject);
                //observer for up damage
                UpDamage?.Invoke();
            }
        }
    }
}

