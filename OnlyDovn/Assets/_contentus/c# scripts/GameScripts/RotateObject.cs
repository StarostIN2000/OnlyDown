using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 100, 0); // �������� �������� ������ ������ ��� (x, y, z) � �������� � �������

    void Update()
    {
        // ������� ������ ������ ����� ���
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
