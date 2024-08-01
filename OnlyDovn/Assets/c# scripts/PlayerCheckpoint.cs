using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    private Vector3 currentCheckpoint;

    private void Start()
    {
        // ������������� ��������� ������� ��� ������ ��������
        currentCheckpoint = transform.position;
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        currentCheckpoint = newCheckpoint;
        Debug.Log("�������� ���������� �: " + currentCheckpoint);
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint;
        Debug.Log("�������� ��������� �� ���������: " + currentCheckpoint);
    }
}
