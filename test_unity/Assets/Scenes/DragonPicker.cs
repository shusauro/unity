using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonPicker : MonoBehaviour
{
    public GameObject energyShieldPrefab;
    public int numEnergyShield = 3;
    public float energyShieldBottomY = -6f;
    public float energyShiledRadius = 1.5f;
    void Start()
    {
        for (int i = 0; i < numEnergyShield; i++)
        {
            GameObject eShieldGo = Instantiate<GameObject>(energyShieldPrefab);
            eShieldGo.transform.position = new Vector3(0, energyShieldBottomY, 0);
            eShieldGo.transform.localScale = new Vector3(i, i, i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
