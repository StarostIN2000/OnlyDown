using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.Universal;
using System.Linq;

public class QualitySettingsScript : MonoBehaviour
{
    [SerializeField] TMP_Dropdown QualityDropdown;
    [SerializeField] TMP_Dropdown FPSDropdown;
    [SerializeField] Toggle SSAOToggle;
    [SerializeField] Toggle PPToggle;
    [SerializeField] List<UniversalRendererData> URDs;
    [SerializeField] PostProcessData PPD;
    [SerializeField] MonoBehaviour targetScript; // ������, ������� ����� ��������/���������

    private void Awake()
    {
        if (PlayerPrefs.HasKey("quality"))
        {
            OnQualitySet(PlayerPrefs.GetInt("quality"));
            OnFPSSet(PlayerPrefs.GetInt("fps"));
            OnSSAOSet(PlayerPrefs.GetInt("SSAO") == 0 ? false : true);
            OnPPSet(PlayerPrefs.GetInt("PP") == 0 ? false : true);
        }
        else
        {
            OnQualitySet(0);
            OnFPSSet(1);
            OnSSAOSet(true);
            OnPPSet(true);
        }
    }

    public void OnQualitySet(int ind)
    {
        QualitySettings.SetQualityLevel(ind);
        QualityDropdown.value = ind; // ������������� �������� � UI

        PlayerPrefs.SetInt("quality", ind);

        // ���������/���������� ������� � ����������� �� ������ ��������
        UpdateTargetScript(ind);
    }

    public void OnFPSSet(int ind)
    {
        int fps = 0;
        switch (ind)
        {
            case 0: fps = 30; break;
            case 1: fps = 60; break;
            case 2: fps = 90; break;
        }
        Application.targetFrameRate = fps;
        QualitySettings.vSyncCount = 0;
        FPSDropdown.value = ind; // ������������� �������� � UI

        PlayerPrefs.SetInt("fps", ind);
    }

    public void OnSSAOSet(bool flag)
    {
        foreach (var i in URDs)
        {
            var ssao = i.rendererFeatures.Where((f) => f.name == "SSAO").FirstOrDefault();
            if (ssao)
            {
                ssao.SetActive(flag);
            }
        }

        SSAOToggle.isOn = flag; // ������������� �������� � UI

        PlayerPrefs.SetInt("SSAO", flag ? 1 : 0);
    }

    public void OnPPSet(bool flag)
    {
        foreach (var i in URDs)
        {
            i.postProcessData = flag ? PPD : null;
            i.SetDirty();
        }

        PPToggle.isOn = flag; // ������������� �������� � UI

        PlayerPrefs.SetInt("PP", flag ? 1 : 0);
    }

    private void UpdateTargetScript(int qualityLevel)
    {
        if (targetScript == null) return; // ��������, ���� ������ �� �����

        // ������ ���������/���������� �������
        if (qualityLevel == 0) // ����������� ���������
        {
            targetScript.enabled = true;
        }
        else // ��� ��������� ������
        {
            targetScript.enabled = false;
        }
    }
}
