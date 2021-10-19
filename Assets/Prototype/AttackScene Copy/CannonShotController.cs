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

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
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
