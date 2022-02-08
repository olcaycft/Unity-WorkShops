using System;
using UnityEngine;

namespace ShooterScene
{
    public class Missile : MonoBehaviour,IMissileDamage
    {
        //[SerializeField] private GameObject missilePrefab;
        [SerializeField] private float speed = 10f;
        [SerializeField] private int damage = 1;
        [SerializeField] private int tempDamage = 1;

        private void Awake()
        {
            Weapon.UpDamage += UpDamage;
        }
        public void OnObjectSpawn()
        {
            damage = tempDamage;
        }
        private void Update()
        {
            HandleForwardMovement();
        }

        private void HandleForwardMovement()
        {
            gameObject.transform.position += Vector3.forward * Time.deltaTime * speed;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("FinishLine"))
            {
                Destroy(gameObject);
            }
        }

        private void UpDamage()
        {
            tempDamage++;
        }
    }
}