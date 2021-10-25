using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnMouseDown()
    {
        GameObject Cannon = GameObject.Find("Cannon");
        Cannon.GetComponent<CannonShotController>().AssignTarget(this.gameObject.transform);
        Cannon.SetActive(false);
    }
}
