using DiasGames.Components;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    private Vector3 currentCheckpoint;

    private void Start()
    {
        // ��������� ����������� ��������, ���� �� ����������
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
            // ������������� ��������� ������� ��� ������ ��������
            currentCheckpoint = transform.position;
        }
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        currentCheckpoint = newCheckpoint;

        // ��������� �������� � PlayerPrefs
        PlayerPrefs.SetFloat("CheckpointX", currentCheckpoint.x);
        PlayerPrefs.SetFloat("CheckpointY", currentCheckpoint.y);
        PlayerPrefs.SetFloat("CheckpointZ", currentCheckpoint.z);
        PlayerPrefs.Save();

        Debug.Log("�������� ���������� �: " + currentCheckpoint);
    }

    public void Respawn()
    {
        var _mover = GetComponent<Mover>();
        _mover.SetPosition(currentCheckpoint);
        Debug.Log("�������� ��������� �� ���������: " + currentCheckpoint);
    }

    public void TeleportToCheckpoint(Vector3 checkpointPosition)
    {
        var _mover = GetComponent<Mover>();
        _mover.SetPosition(checkpointPosition);
        Debug.Log("����� �������������� �� ��������: " + checkpointPosition);
    }
    public void TeleportToCheckpoint1()
    {
        TeleportToCheckpoint(new Vector3((float)-12.01, (float)12.96, (float)-20.22)); // ������� ���������� ������� ���������
    }
    public void TeleportToCheckpoint2()
    {
        TeleportToCheckpoint(new Vector3((float)2.512, (float)17.227, (float)0.46)); // ������� ���������� ������� ���������
    }
    public void TeleportToCheckpoint3()
    {
        TeleportToCheckpoint(new Vector3((float)30.272, (float)74.51691, (float)48.47)); // ������� ���������� ������� ���������
    }
    public void ResetProgress()
    {
        PlayerPrefs.DeleteKey("Checkpoint");
        // ���������� ������ � ��������� �������
        var startPosition = new Vector3(0, 0, 0); // ������� ��������� �������
        GetComponent<Mover>().SetPosition(startPosition);
        currentCheckpoint = transform.position;
    }


}
