using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    [Header("аватар и скин по индексу от одного персонажа должны быть!")]
    [SerializeField] private List<Avatar> avatars;
    [SerializeField] private GameObject[] skins;
    [SerializeField] private GameObject player;
    private Animator anim;
    void Start()
    {
        anim = player.GetComponent<Animator>();   
    }

    public void ChangeToWoman() 
    {
        anim.avatar = avatars[0];
        for (int i = 0; i < skins.Length; i++) 
        {
            if (i == 0)
            {
                skins[i].SetActive(true);
            }
            else 
            {
                skins[i].SetActive(false);
            
            }
        }
    }
    public void ChangeToMan()
    {
        anim.avatar = avatars[1];
        for (int i = 0; i < skins.Length; i++)
        {
            if (i == 1)
            {
                skins[i].SetActive(true);
            }
            else
            {
                skins[i].SetActive(false);

            }
        }
    }




}
