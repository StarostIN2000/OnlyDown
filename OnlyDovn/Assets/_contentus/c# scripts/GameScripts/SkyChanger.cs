using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{
    public Material newSkyboxMaterial; // Новый материал skybox

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что триггером вошёл игрок (или другой объект)
        if (other.CompareTag("Player")) // Убедитесь, что у вашего объекта есть тег "Player"
        {
            // Меняем skybox на новый материал
            RenderSettings.skybox = newSkyboxMaterial;
            // Обновляем освещение (если необходимо)
            DynamicGI.UpdateEnvironment();
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        // Если хотите вернуть старый skybox при выходе из триггера
        if (other.CompareTag("Player"))
        {
            // Вернуть старый skybox (можно сохранить его в переменной)
            RenderSettings.skybox = null; // Или установите ваш исходный skybox
            DynamicGI.UpdateEnvironment();
        }
    }*/
    public void ChangeTothat() 
    {
        // Меняем skybox на новый материал
        RenderSettings.skybox = newSkyboxMaterial;
        // Обновляем освещение (если необходимо)
        DynamicGI.UpdateEnvironment();

    }
}
