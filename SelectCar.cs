using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CarInfo
{
    public GameObject prefab;
    public float price;
    public bool isOpened;
}

public class SelectCar : MonoBehaviour {

    public CarInfo[] carsInfos;
    public GameObject currentCar;
    public int currentIndexCar;
    public Transform carPosition;

    public static SelectCar instance;

	// Use this for initialization
	void Awake () {
        instance = this;
	}

    // Use this for initialization
    void Start()
    {
        RefrashOurCarsBuy();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void RefrashOurCarsBuy()
    {
        for (int i = 0; i < carsInfos.Length; i++)
        {
            if (Data.CarIsOpened(i))
            {
                carsInfos[i].isOpened = true;
            }
        }
    }

    public CarInfo PrevCar()
    {
        currentIndexCar--;
        if (currentIndexCar < 0)
            currentIndexCar = carsInfos.Length - 1;

        Destroy(currentCar);
        currentCar = Instantiate(carsInfos[currentIndexCar].prefab, carPosition.transform.position, carPosition.transform.rotation);
        currentCar.transform.SetParent(transform);


        return carsInfos[currentIndexCar];
    }

    public CarInfo NextCar()
    {
        currentIndexCar++;
        if (currentIndexCar == carsInfos.Length)
            currentIndexCar = 0;

        Destroy(currentCar);
        currentCar = Instantiate(carsInfos[currentIndexCar].prefab, carPosition.transform.position, carPosition.transform.rotation);
        currentCar.transform.SetParent(transform);


        return carsInfos[currentIndexCar];
    }

    public bool BuyCar()
    {

        if (carsInfos[currentIndexCar].price < Data.GetTotalCoins())
        {
            Data.SetTotalCoins((int)(Data.GetTotalCoins() - carsInfos[currentIndexCar].price));
            Data.SetCarOpened(currentIndexCar, true);
            RefrashOurCarsBuy();

            return true;
        }

        return false;
    }
}
