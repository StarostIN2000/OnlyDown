using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{
    public Material newSkyboxMaterial; // ����� �������� skybox

    private void OnTriggerEnter(Collider other)
    {
        // ���������, ��� ��������� ����� ����� (��� ������ ������)
        if (other.CompareTag("Player")) // ���������, ��� � ������ ������� ���� ��� "Player"
        {
            // ������ skybox �� ����� ��������
            RenderSettings.skybox = newSkyboxMaterial;
            // ��������� ��������� (���� ����������)
            DynamicGI.UpdateEnvironment();
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        // ���� ������ ������� ������ skybox ��� ������ �� ��������
        if (other.CompareTag("Player"))
        {
            // ������� ������ skybox (����� ��������� ��� � ����������)
            RenderSettings.skybox = null; // ��� ���������� ��� �������� skybox
            DynamicGI.UpdateEnvironment();
        }
    }*/
    public void ChangeTothat() 
    {
        // ������ skybox �� ����� ��������
        RenderSettings.skybox = newSkyboxMaterial;
        // ��������� ��������� (���� ����������)
        DynamicGI.UpdateEnvironment();

    }
}
