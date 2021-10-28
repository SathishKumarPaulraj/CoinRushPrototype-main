using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCameraController : MonoBehaviour
{
    
    public float rotationSpeed = 10;
  //  int? i = null;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        staticMovement();
    }

    /// <summary>
    /// This moves the Camera Left and Right 
    /// </summary>
    public void staticMovement()
    {
        Vector3 rotation = transform.eulerAngles;

        rotation.y += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime; 

        transform.eulerAngles = rotation;
        
    }
}
