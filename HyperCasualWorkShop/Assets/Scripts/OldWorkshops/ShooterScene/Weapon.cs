using System;
using System.Collections;
using UnityEngine;

namespace ShooterScene
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Missile missile;
        [SerializeField] private float spawnRate = 1f;
        [SerializeField] private int missileSpawnCount = 1;
        public static event Action UpDamage;

        private void Awake()
        {
            StartCoroutine(nameof(GenerateMissileRoutine), 3f);
            PowerUpArea.SpeedUp += SpeedUp;
            PowerUpArea.MissileCountUp += MissileCountUp;
        }

        private void SpeedUp()
        {
            spawnRate -= 0.1f;
        }

        private void MissileCountUp()
        {
            missileSpawnCount++;
        }

        private IEnumerator GenerateMissileRoutine()
        {
            while (true)
            {
                for (int i = 0; i < missileSpawnCount; i++)
                {
                    var pos = transform.position;
                    pos.x +=i-0.75f;
                    Missile tempMissile = Instantiate(missile,pos,Quaternion.identity);
                    tempMissile.OnObjectSpawn();
                }
                yield return new WaitForSeconds(spawnRate);
            }
            
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("DamageUpper"))
            {
                UpDamage?.Invoke();
                Destroy(other.gameObject);
                //observer for up damage
            }
        }
    }
}

