using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{

    public int startHealth = 100;

    public int bonusHealth;

    private int totalHealth;

    // Start is called before the first frame update
    void Start()
    {
        totalHealth = startHealth + bonusHealth;
        InvokeRepeating("DecreaseHealth", 1.0f, 1.0f);
    }

    void DecreaseHealth()
    {
        if (totalHealth > 0)
        {
            totalHealth -= 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(totalHealth);   
    }
}
