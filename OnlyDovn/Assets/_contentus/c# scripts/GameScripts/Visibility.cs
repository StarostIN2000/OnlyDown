using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    private float dist;
    public float distOfVision = 20;
    private GameObject player;
    private List<GameObject> childObjects;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        // Инициализируем список и добавляем все дочерние объекты
        childObjects = new List<GameObject>();
        foreach (Transform child in transform)
        {
            childObjects.Add(child.gameObject);
        }
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            Debug.LogWarning("Игрок с тегом 'Player' не найден!");
            return;
        }

        dist = Vector3.Distance(transform.position, player.transform.position);
        //Debug.Log("Расстояние до игрока: " + dist);

        bool shouldBeActive = dist <= distOfVision;
        // Обновляем состояние каждого дочернего объекта
        foreach (GameObject child in childObjects)
        {
            child.SetActive(shouldBeActive);
        }
    }
}
