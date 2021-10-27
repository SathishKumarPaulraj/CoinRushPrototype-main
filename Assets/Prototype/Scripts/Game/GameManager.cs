using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingTypes
{
    Stable,
    Statue,
    Castle,
    Building,
    House
}
public class GameManager : MonoBehaviour
{
    public int _coins;
    public int _energy = 25;
    public int _shield;
    public float _minutes;

    public List<GameObject> _BuildingDetails;
    public List<BuildingTypes> _BuildingTypes;
    public List<Vector3> _PositionDetails;
    public List<Quaternion> _RotationList;
    public List<int> _BuildingUpgradationLevel;
    public List<int> _BuildingCost;

    public int _maxEnergy = 50;
    private bool mIsFull = true; 

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject); //Stays throughout the game
        StartCoroutine(AutomaticEnergyRefiller());
    }

    private void Update()
    {
        if(_energy == _maxEnergy)
        {
            mIsFull = false;
            return;
        }
        else
        {
            mIsFull = true;
        }
    }
    
    private IEnumerator AutomaticEnergyRefiller()
    {
        while (mIsFull)
        {
            yield return new WaitForSeconds(MinutesToSecondsConverter(_minutes));
            _energy += 1;
        }
    }   

    /// <summary>
    /// Converts the minutes given at Inspector into seconds and passes it to the coroutine function
    /// </summary>
    /// <param name="inMinutes"></param>
    /// <returns></returns>
    private float MinutesToSecondsConverter(float inMinutes) 
    {
        float seconds = inMinutes * 60;
        return seconds;
    }
}
