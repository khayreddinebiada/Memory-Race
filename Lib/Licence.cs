using System.Collections;
using System;
using UnityEngine;

public class Licence : MonoBehaviour {

    public bool IsLicenced = false;
    public int DayExpiration = 10;
    public int MonthExpiration = 07;
    public int YearExpiration = 2018;

	// Update is called once per frame
	void Update () {
		
	}

    public bool IsLicensed()
    {
        if (IsLicenced)
            return true;

        if (DateTime.Compare(DateTime.Now, new DateTime(YearExpiration, MonthExpiration, DayExpiration)) > 0)
            return false;

        return true;
    }
}
