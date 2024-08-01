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
        // �������������� ������ � ��������� ��� �������� �������
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
            Debug.LogWarning("����� � ����� 'Player' �� ������!");
            return;
        }

        dist = Vector3.Distance(transform.position, player.transform.position);
        //Debug.Log("���������� �� ������: " + dist);

        bool shouldBeActive = dist <= distOfVision;
        // ��������� ��������� ������� ��������� �������
        foreach (GameObject child in childObjects)
        {
            child.SetActive(shouldBeActive);
        }
    }
}
