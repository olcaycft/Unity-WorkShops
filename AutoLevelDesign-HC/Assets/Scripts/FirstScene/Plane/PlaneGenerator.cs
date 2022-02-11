using UnityEngine;

namespace FirstScene.Plane
{
    public class PlaneGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject planePrefab;
        [SerializeField] private GameObject obstaclePrefab;
        [SerializeField] private Vector3 nextPlaneStartPoint;
        private int planeCount = 10;

        private void Awake()
        {
            GeneratePlane();
        }

        private void GeneratePlane()
        {
            for (int i = 0; i < planeCount; i++)
            {
                GameObject plane = Instantiate(planePrefab, nextPlaneStartPoint, Quaternion.identity);
                nextPlaneStartPoint = plane.transform.GetChild(4).transform.position;
                if (i % 2 == 0)
                {
                    int randomObstaclePlace = Random.Range(5, 8);
                    Instantiate(obstaclePrefab, plane.transform.GetChild(randomObstaclePlace).transform.position,
                        Quaternion.identity);
                }
            }
        }
    }
}