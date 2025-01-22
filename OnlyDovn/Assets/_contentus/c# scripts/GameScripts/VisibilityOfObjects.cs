using System.Collections;
using UnityEngine;

public class VisibilityOfObjects : MonoBehaviour
{
    [SerializeField] private GameObject player; // �����
    [SerializeField] private GameObject[] gameParts; // ����� ����, � ������� ����������� ����������
    [SerializeField] private GameObject[] toDisable; // ������� ��� ����������

    private const float visibilityDistance = 80f; // ����� ���������� ��� ���������
    private const float checkInterval = 0.5f; // �������� �������� � ��������

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (gameParts == null || gameParts.Length == 0)
        {
            Debug.LogWarning("������ gameParts �� ��������!");
            return;
        }

        if (toDisable == null || toDisable.Length != gameParts.Length)
        {
            Debug.LogError("������ toDisable �� ������������� gameParts!");
            return;
        }

        // �������� �������� � ��������
        StartCoroutine(CheckVisibility());
    }

    private IEnumerator CheckVisibility()
    {
        while (true)
        {
            for (int i = 0; i < gameParts.Length; i++)
            {
                if (gameParts[i] == null || toDisable[i] == null)
                    continue;

                // ��������� ������� ����������
                float distanceSqr = (player.transform.position - gameParts[i].transform.position).sqrMagnitude;

                // ���������� � ��������� ������
                if (distanceSqr > visibilityDistance * visibilityDistance)
                {
                    toDisable[i].SetActive(false);
                }
                else
                {
                    toDisable[i].SetActive(true);
                }
            }

            yield return new WaitForSeconds(checkInterval); // ��� ����� ��������� ���������
        }
    }
}
