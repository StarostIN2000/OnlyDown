using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 100, 0); // Скорость вращения вокруг каждой оси (x, y, z) в градусах в секунду

    void Update()
    {
        // Вращаем объект вокруг своей оси
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
