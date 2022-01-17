using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private Transform enemyPosition;
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform cube;

    void Update()
    {
        //InputHandle();
        Moving();
    }

    private void Moving()
    {
        cube.position = Vector3.MoveTowards(cube.position,
            Vector3.Lerp(cube.position, enemyPosition.position, 2f),5f*Time.deltaTime);

        if (Vector3.Distance(cube.position,enemyPosition.position)<0.001f)
        {
            Destroy(cube.gameObject);
        }
    }
    private void InputHandle()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject missile = Instantiate(missilePrefab, shootingPoint.position, shootingPoint.rotation);
            Shoot(missile);
        }
        
    }

    private void Shoot(GameObject missile)
    {
        missile.transform.position = Vector3.MoveTowards(missile.transform.position,
            Vector3.Lerp(missile.transform.position, enemyPosition.position, 1f),1f*Time.deltaTime);
            
        Debug.Log(missile.transform.position);
    }

    private void MissileMovement()
    {
        
    }
    
}
