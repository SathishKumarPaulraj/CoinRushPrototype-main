using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position.x);
        Debug.Log(transform.position);
        Debug.Log(player.GetComponent<Transform>().position);

        transform.position = transform.position + new Vector3(0, 0, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0, 0, 10f * Time.deltaTime);
    }
}
