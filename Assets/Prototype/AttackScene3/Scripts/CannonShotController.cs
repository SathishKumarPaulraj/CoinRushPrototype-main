using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShotController : MonoBehaviour
{

    /*public GameObject _CannonBall;
    public Transform _shotPosition;
    public float _blastPower;*/
    public Rigidbody _bulletPrefab;
    public GameObject Cursor;
    public LayerMask layer;
    public Transform _shotPoint;
   // public GameObject _PositionPoints;
    public List<GameObject> _TargetPoints = new List<GameObject>();
   // List<TargetPoints> _TargetPosition = new List<TargetPoints>();
    public GameObject _TargetPrefab;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
        TargetInstantiation();
    }


    // Update is called once per frame
    void Update()
    {

       
        LaunchProjectile();

       /* if (Input.GetMouseButtonDown(0))
        {
            GameObject _CreatedCannonBall = Instantiate(_CannonBall, _shotPosition.position, _shotPosition.rotation);
            _CreatedCannonBall.GetComponent<Rigidbody>().velocity = _shotPosition.transform.up * _blastPower;
        }    */
    }

    void TargetInstantiation()
    {
        //GameObject newPosition = _TargetPoints[Random.Range(0, _TargetPoints.Count)];   

      //  GameObject TargetMark = Instantiate(_TargetPrefab, newPosition.transform.position, newPosition.transform.rotation);

        Vector3[] spawnPositions = new[] { new Vector3(-6f, 8f, -44f), new Vector3(-9.2f, 19.7f, -19.7f), new Vector3(0.2f, 34.1f, -10f), new Vector3(11f, 18.9f, -23f), new Vector3(6.1f, 11.4f, -41.7f) };
        Quaternion spawnRotation = Quaternion.identity;
        for (int i = 0; i < 6; i++)
        {
            Instantiate(_TargetPrefab, spawnPositions[i], spawnRotation);
        }
    }

    void LaunchProjectile()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(camRay, out hit, 100f, layer))
        {
            Cursor.SetActive(true);
            Cursor.transform.position = hit.point + Vector3.up * 0.1f;

            Vector3 Vo = CalculateVelocity(hit.point, _shotPoint.position, 1f);

            transform.rotation = Quaternion.LookRotation(Vo);

            if (Input.GetMouseButtonDown(0))
            {
                Rigidbody obj = Instantiate(_bulletPrefab, _shotPoint.position, Quaternion.identity);
                obj.velocity = Vo;
            }

        }
        else
        {
            Cursor.SetActive(false);
        }
    }

     Vector3 CalculateVelocity(Vector3 target, Vector3 origin,float time)
    {
        //Define 
        Vector3 _distance = target - origin;
        Vector3 _distanceXZ = _distance;
        _distanceXZ.y = 0f;

        //Distance Value

        float sY = _distance.y;
        float sXZ = _distanceXZ.magnitude;

        float Vxz = sXZ / time;
        float Vy = sY / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = _distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;

    }
}
