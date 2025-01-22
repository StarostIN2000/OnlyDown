using System.Collections;
using UnityEngine;

public class VisibilityOfObjects : MonoBehaviour
{
    [SerializeField] private GameObject player; // Игрок
    [SerializeField] private GameObject[] gameParts; // Части игры, к которым вычисляется расстояние
    [SerializeField] private GameObject[] toDisable; // Объекты для отключения

    private const float visibilityDistance = 80f; // Порог расстояния для видимости
    private const float checkInterval = 0.5f; // Интервал проверки в секундах

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (gameParts == null || gameParts.Length == 0)
        {
            Debug.LogWarning("Массив gameParts не заполнен!");
            return;
        }

        if (toDisable == null || toDisable.Length != gameParts.Length)
        {
            Debug.LogError("Массив toDisable не соответствует gameParts!");
            return;
        }

        // Начинаем проверку в корутине
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

                // Вычисляем квадрат расстояния
                float distanceSqr = (player.transform.position - gameParts[i].transform.position).sqrMagnitude;

                // Сравниваем с квадратом порога
                if (distanceSqr > visibilityDistance * visibilityDistance)
                {
                    toDisable[i].SetActive(false);
                }
                else
                {
                    toDisable[i].SetActive(true);
                }
            }

            yield return new WaitForSeconds(checkInterval); // Ждём перед следующей проверкой
        }
    }
}
