using System;
using UnityEngine;

namespace ShooterScene
{
    public class Missile : MonoBehaviour
    {
        //[SerializeField] private GameObject missilePrefab;
        [SerializeField] private float speed = 10f;
        [SerializeField] private int damage = 1;

        private void Awake()
        {
            Weapon.UpDamage += UpDamage;
        }

        private void OnDestroy()
        {
            Weapon.UpDamage -= UpDamage;
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
            damage++;
        }
    }
}