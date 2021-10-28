using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPrefab : MonoBehaviour
{
    
    public void OnCollisionEnter(Collision collision)
    {
        Camera.main.transform.parent = null;
        Destroy(this.gameObject,.0f);
       
    }
}
