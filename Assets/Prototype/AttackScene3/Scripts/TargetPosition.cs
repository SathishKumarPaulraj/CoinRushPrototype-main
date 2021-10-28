using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPosition : MonoBehaviour
{
    private GameManager mGameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnMouseDown()
    {
        GameObject _RevengeButton = GameObject.Find("RevengeButton");
        _RevengeButton.SetActive(false);
        GameObject Cannon = GameObject.Find("Cannon");
        Cannon.GetComponent<CannonShotController>().AssignTarget(this.gameObject.transform);
        Cannon.SetActive(false);
    }

    public void ScoreCalculation()
    {
        mGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }
}
