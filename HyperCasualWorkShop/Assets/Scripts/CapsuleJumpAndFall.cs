using UnityEngine;

namespace CapsulePlayer
{
    public class CapsuleJumpAndFall : MonoBehaviour
    {
        [SerializeField] private Transform floorPos;
        [SerializeField]private float fallTimer = 0;
        private float fallCD = 0.2f;
        [SerializeField] private bool waitBeforeFall = false;
        private float floorPosY => floorPos.position.z;

        private void Update()
        {
            HandleInput();

            if (waitBeforeFall)
            {
                Fall();
            }
        }

        private void HandleInput()
        {
            if (Input.GetMouseButton(0))
            {
                transform.position += Vector3.up * Time.deltaTime * 4f;
            }
            else
            {
                if (!waitBeforeFall && transform.position.y > floorPosY + 1f)
                {
                    fallTimer += Time.deltaTime;
                    if (fallTimer>=fallCD)
                    {
                        waitBeforeFall = true;
                        fallTimer -= fallCD;
                    }
                }
            }
        }

        private void Fall()
        {
            if (transform.position.y > floorPosY + 1f && waitBeforeFall)
            {
                transform.position -= Vector3.down * Time.deltaTime * -9.8f;
            }
            else if (transform.position.y <= floorPosY + 1f && waitBeforeFall)
            {
                waitBeforeFall = false;
            }
        }
    }
}