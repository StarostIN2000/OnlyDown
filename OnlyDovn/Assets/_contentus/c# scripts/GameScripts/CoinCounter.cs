using System;
using System.Collections;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    private float Coins;
    private float MaxDistAmount;
    private float CurrentDistanceAmount;

    [SerializeField] private GameObject zeroPoint;
    [SerializeField] private GameObject Player;

    void Awake()
    {
        Coins = PlayerPrefs.GetInt("Coins", 0);
        MaxDistAmount = PlayerPrefs.GetInt("MaxDist", 0);
        StartCoroutine(coinsUpdater());
    }

    IEnumerator coinsUpdater() 
    {
        while (true) 
        {
            CurrentDistanceAmount = Vector3.Distance(zeroPoint.transform.position, Player.transform.position);
            if (CurrentDistanceAmount > MaxDistAmount)
            {
                Coins += CurrentDistanceAmount - MaxDistAmount;
                MaxDistAmount = CurrentDistanceAmount;
                PlayerPrefs.SetInt("Coins", Convert.ToInt32(Coins));
                PlayerPrefs.SetInt("MaxDist", Convert.ToInt32(MaxDistAmount));
            }
            yield return new WaitForSeconds(3f);
        }    
    }
    
        
}
