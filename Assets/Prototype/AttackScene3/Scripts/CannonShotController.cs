using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CannonShotController : MonoBehaviour
{
    [SerializeField] private GameManager mGameManager;
    public Rigidbody _bulletPrefab;
    public GameObject Cursor;
    public LayerMask layer;
    public Transform _shotPoint;
    public List<GameObject> _TargetPoints = new List<GameObject>();
    public List<GameObject> _spawnedTargetPoints = new List<GameObject>();
    public GameObject _TargetPrefab;
    public GameObject _multiplierPrefab;
    public GameObject _multiplierGameObject;
    public float _MultiplierSwitchTime = 1.0f;
    public GameObject _bullet;


    private Camera cam;
    private int cachedTargetPoint = -1;


    private void Awake()
    {
        mGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        for (int i = 0; i< mGameManager._BuildingDetails.Count ; i++ )
        {
            Instantiate(mGameManager._BuildingDetails[i], mGameManager._PositionDetails[i], mGameManager._RotationList[i]);
        }    
        
    }

    private void Start()
    {
        cam = Camera.main;
      
        TargetInstantiation();
        MultiplierInstantiation();
        InvokeRepeating("DoMultiplierSwitching", 1f, _MultiplierSwitchTime);
    }

    // Update is called once per frame
    void Update()
    {   
           
    }

    /// <summary>
    /// This Function helps in moving the 2X Multiplier randomly Over the buildings
    /// </summary>
    void DoMultiplierSwitching()
    {
        if (_multiplierGameObject == null)
        {
            GameObject newMultiplier = _TargetPoints[0];
            _multiplierGameObject = Instantiate(_multiplierPrefab, newMultiplier.transform.position, newMultiplier.transform.rotation);

        }

        if (cachedTargetPoint != -1)
            _spawnedTargetPoints[cachedTargetPoint].SetActive(true); 

        int rand = Random.Range(0, _TargetPoints.Count);
        cachedTargetPoint = rand;
        _spawnedTargetPoints[cachedTargetPoint].SetActive(false);
        _multiplierGameObject.transform.localPosition = _spawnedTargetPoints[cachedTargetPoint].transform.localPosition;
        _multiplierGameObject.transform.localRotation = _spawnedTargetPoints[cachedTargetPoint].transform.localRotation;
    }


    /// <summary>
    /// This helps in Instantiating the Target Mark on the Buildings.
    /// </summary>    
    void TargetInstantiation()
    {
        for (int i = 0; i < _TargetPoints.Count; i++)
        {
            GameObject go = Instantiate(_TargetPrefab, _TargetPoints[i].transform.position, Quaternion.identity);
            _spawnedTargetPoints.Add(go);
        }
    }

    /// <summary>
    /// This Helps in Instantiating the 2X Multiplier 
    /// </summary>    
    void MultiplierInstantiation()
    {
        GameObject newMultiplier = _TargetPoints[0];
        _multiplierGameObject = Instantiate(_multiplierPrefab, newMultiplier.transform.position, newMultiplier.transform.rotation);   
    }



    /*  void LaunchProjectile()
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
      } */


    /// <summary>
    ///  Calcuate the Projectile  of the Bullet from from Origin to Target
    /// </summary>
    /// <param name="target"></param>
    /// <param name="origin"></param>
    /// <param name="time"></param>
    /// <returns></returns>
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


    /// <summary>
    /// This gets the Target mark Transform Details during on mouse Down click 
    /// </summary>
    /// <param name="trans"></param>
    public void AssignTarget(Transform trans)
    {
        CancelInvoke("DoMultiplierSwitching");
        Camera cam = Camera.main;
        this.gameObject.transform.LookAt(trans);
        Rigidbody _bullet =  Instantiate(_bulletPrefab, _shotPoint.transform.position, _shotPoint.transform.rotation);
        _bullet.velocity = CalculateVelocity(trans.transform.position,_shotPoint.transform.position, 1f);
        Camera.main.transform.parent = _bullet.transform;
        Destroy(_bullet, .8f);
    }
   
}
