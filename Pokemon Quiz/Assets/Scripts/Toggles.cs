using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggles : MonoBehaviour
{
    private bool[] genToggles = new bool[10];
    private bool silhouettes;
    [SerializeField] private Toggle silhouette;
    [SerializeField] private Toggle[] toggles;
    private int toggleCount;
    private bool togglesEnabled;
    [SerializeField] private Color disabled;
    [SerializeField] private Color enabled;

    private void OnEnable()
    {
        int i = 0;
        foreach (Toggle toggle in toggles)
        {
            if (genToggles[i] == false)
            {
                toggle.isOn = false;
                genToggles[i] = false;
                toggleCount--;
            }
            i++;
        }
        if (silhouettes == false)
        {
            silhouette.isOn = false;
            silhouettes = false;
        }
    }

    private void Update()
    {
        if(toggleCount == 1)
        {
            foreach (Toggle toggle in toggles)
            {
                if (toggle.isOn)
                {
                    toggle.interactable = false;
                    toggle.graphic.color = disabled;
                }
            }
            togglesEnabled = false;
        }
        else if (togglesEnabled == false && toggleCount > 1)
        {
            foreach (Toggle toggle in toggles)
            {
                toggle.interactable = true;
                toggle.graphic.color = enabled;
            }
            togglesEnabled = true;
        }
    }

    public void Gen1Toggle()
    {
        if (genToggles[0])
        {
            genToggles[0] = false;
            toggleCount--;
        }
        else
        {
            genToggles[0] = true;
            toggleCount++;
        }
    }
    public void Gen2Toggle()
    {
        if (genToggles[1])
        {
            genToggles[1] = false;
            toggleCount--;
        }
        else
        {
            genToggles[1] = true;
            toggleCount++;
        }
    }
    public void Gen3Toggle()
    {
        if (genToggles[2])
        {
            genToggles[2] = false;
            toggleCount--;
        }
        else
        {
            genToggles[2] = true;
            toggleCount++;
        }
    }
    public void Gen4Toggle()
    {
        if (genToggles[3])
        {
            genToggles[3] = false;
            toggleCount--;
        }
        else
        {
            genToggles[3] = true;
            toggleCount++;
        }
    }
    public void Gen5Toggle()
    {
        if (genToggles[4])
        {
            genToggles[4] = false;
            toggleCount--;
        }
        else
        {
            genToggles[4] = true;
            toggleCount++;
        }
    }
    public void Gen6Toggle()
    {
        if (genToggles[5])
        {
            genToggles[5] = false;
            toggleCount--;
        }
        else
        {
            genToggles[5] = true;
            toggleCount++;
        }
    }
    public void Gen7Toggle()
    {
        if (genToggles[6])
        {
            genToggles[6] = false;
            toggleCount--;
        }
        else
        {
            genToggles[6] = true;
            toggleCount++;
        }
    }
    public void Gen8Toggle()
    {
        if (genToggles[7])
        {
            genToggles[7] = false;
            toggleCount--;
        }
        else
        {
            genToggles[7] = true;
            toggleCount++;
        }
    }
    public void Gen9Toggle()
    {
        if (genToggles[9])
        {
            genToggles[9] = false;
            toggleCount--;
        }
        else
        {
            genToggles[9] = true;
            toggleCount++;
        }
    }
    public void ArceusToggle()
    {
        if (genToggles[8])
        {
            genToggles[8] = false;
            toggleCount--;
        }
        else
        {
            genToggles[8] = true;
            toggleCount++;
        }
    }
    public void SilhouettesToggle()
    {
        if (silhouettes)
        {
            silhouettes = false;
        }
        else
        {
            silhouettes = true;
        }
    }

    public bool[] GetGenToggles()
    {
        return genToggles;
    }
    public bool GetSilhouettesToggle()
    {
        return silhouettes;
    }
    public int GetToggleCount()
    {
        return toggleCount;
    }
    public bool GetTogglesEnabled()
    {
        return togglesEnabled;
    }
    public void SetGenToggles(bool[] gens)
    {
        genToggles = gens;
    }
    public void SetSilhouettesToggle(bool sil)
    {
        silhouettes = sil;
    }
    public void SetToggleCount(int count)
    {
        toggleCount = count;
    }
    public void SetTogglesEnabled(bool enabled)
    {
        togglesEnabled = enabled;
    }
}
