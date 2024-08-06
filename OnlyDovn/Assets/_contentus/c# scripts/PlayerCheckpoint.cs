using DiasGames.Components;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerCheckpoint : MonoBehaviour
{
    private Vector3 currentCheckpoint;

    private void Start()
    {
        // Устанавливаем начальную позицию как первый чекпоинт
        currentCheckpoint = transform.position;
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        currentCheckpoint = newCheckpoint;
        Debug.Log("Чекпоинт установлен в: " + currentCheckpoint);
    }

    public void Respawn()
    {
        //transform.position = currentCheckpoint;
        var _mover = GetComponent<Mover>();
        _mover.SetPosition(currentCheckpoint);
        Debug.Log("Персонаж возрожден на чекпоинте: " + currentCheckpoint);
    }
}
