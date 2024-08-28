using DiasGames.Components;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    private Vector3 currentCheckpoint;

    private void Start()
    {
        // Загружаем сохраненный чекпоинт, если он существует
        if (PlayerPrefs.HasKey("CheckpointX"))
        {
            float x = PlayerPrefs.GetFloat("CheckpointX");
            float y = PlayerPrefs.GetFloat("CheckpointY");
            float z = PlayerPrefs.GetFloat("CheckpointZ");
            currentCheckpoint = new Vector3(x, y, z);
            transform.position = currentCheckpoint;
        }
        else
        {
            // Устанавливаем начальную позицию как первый чекпоинт
            currentCheckpoint = transform.position;
        }
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        currentCheckpoint = newCheckpoint;

        // Сохраняем чекпоинт в PlayerPrefs
        PlayerPrefs.SetFloat("CheckpointX", currentCheckpoint.x);
        PlayerPrefs.SetFloat("CheckpointY", currentCheckpoint.y);
        PlayerPrefs.SetFloat("CheckpointZ", currentCheckpoint.z);
        PlayerPrefs.Save();

        Debug.Log("Чекпоинт установлен в: " + currentCheckpoint);
    }

    public void Respawn()
    {
        var _mover = GetComponent<Mover>();
        _mover.SetPosition(currentCheckpoint);
        Debug.Log("Персонаж возрожден на чекпоинте: " + currentCheckpoint);
    }

    public void TeleportToCheckpoint(Vector3 checkpointPosition)
    {
        var _mover = GetComponent<Mover>();
        _mover.SetPosition(checkpointPosition);
        Debug.Log("Игрок телепортирован на чекпоинт: " + checkpointPosition);
    }
    public void TeleportToCheckpoint1()
    {
        TeleportToCheckpoint(new Vector3((float)-12.01, (float)12.96, (float)-20.22)); // Укажите координаты первого чекпоинта
    }
    public void TeleportToCheckpoint2()
    {
        TeleportToCheckpoint(new Vector3((float)2.512, (float)17.227, (float)0.46)); // Укажите координаты первого чекпоинта
    }
    public void TeleportToCheckpoint3()
    {
        TeleportToCheckpoint(new Vector3((float)30.272, (float)74.51691, (float)48.47)); // Укажите координаты первого чекпоинта
    }
    public void ResetProgress()
    {
        PlayerPrefs.DeleteKey("Checkpoint");
        // Перемещаем игрока в начальную позицию
        var startPosition = new Vector3(0, 0, 0); // укажите начальную позицию
        GetComponent<Mover>().SetPosition(startPosition);
        currentCheckpoint = transform.position;
    }


}
