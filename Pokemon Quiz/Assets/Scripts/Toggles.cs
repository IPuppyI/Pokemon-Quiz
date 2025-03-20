using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggles : MonoBehaviour
{
    [SerializeField] private Toggle silhouette;
    [SerializeField] private Toggle[] toggles;
    [SerializeField] private Color disabledColor;
    [SerializeField] private Color enabledColor;
    private OptionsConfig optionsConfig;

    private void OnEnable()
    {
        int i = 0;
        foreach (Toggle toggle in toggles)
        {
            if (optionsConfig.genToggles[i] == false)
            {
                toggle.isOn = false;
                optionsConfig.genToggles[i] = false;
                optionsConfig.toggleCount--;
            }
            i++;
        }
        if (optionsConfig.silhouettes == false)
        {
            silhouette.isOn = false;
            optionsConfig.silhouettes = false;
        }
    }

    private void Update()
    {
        if(optionsConfig.toggleCount == 1)
        {
            foreach (Toggle toggle in toggles)
            {
                if (toggle.isOn)
                {
                    toggle.interactable = false;
                    toggle.graphic.color = disabledColor;
                }
            }
            optionsConfig.togglesEnabled = false;
        }
        else if (optionsConfig.togglesEnabled == false && optionsConfig.toggleCount > 1)
        {
            foreach (Toggle toggle in toggles)
            {
                toggle.interactable = true;
                toggle.graphic.color = enabledColor;
            }
            optionsConfig.togglesEnabled = true;
        }
    }

    public void Gen1Toggle()
    {
        if (optionsConfig.genToggles[0])
        {
            optionsConfig.genToggles[0] = false;
            optionsConfig.toggleCount--;
        }
        else
        {
            optionsConfig.genToggles[0] = true;
            optionsConfig.toggleCount++;
        }
    }
    public void Gen2Toggle()
    {
        if (optionsConfig.genToggles[1])
        {
            optionsConfig.genToggles[1] = false;
            optionsConfig.toggleCount--;
        }
        else
        {
            optionsConfig.genToggles[1] = true;
            optionsConfig.toggleCount++;
        }
    }
    public void Gen3Toggle()
    {
        if (optionsConfig.genToggles[2])
        {
            optionsConfig.genToggles[2] = false;
            optionsConfig.toggleCount--;
        }
        else
        {
            optionsConfig.genToggles[2] = true;
            optionsConfig.toggleCount++;
        }
    }
    public void Gen4Toggle()
    {
        if (optionsConfig.genToggles[3])
        {
            optionsConfig.genToggles[3] = false;
            optionsConfig.toggleCount--;
        }
        else
        {
            optionsConfig.genToggles[3] = true;
            optionsConfig.toggleCount++;
        }
    }
    public void Gen5Toggle()
    {
        if (optionsConfig.genToggles[4])
        {
            optionsConfig.genToggles[4] = false;
            optionsConfig.toggleCount--;
        }
        else
        {
            optionsConfig.genToggles[4] = true;
            optionsConfig.toggleCount++;
        }
    }
    public void Gen6Toggle()
    {
        if (optionsConfig.genToggles[5])
        {
            optionsConfig.genToggles[5] = false;
            optionsConfig.toggleCount--;
        }
        else
        {
            optionsConfig.genToggles[5] = true;
            optionsConfig.toggleCount++;
        }
    }
    public void Gen7Toggle()
    {
        if (optionsConfig.genToggles[6])
        {
            optionsConfig.genToggles[6] = false;
            optionsConfig.toggleCount--;
        }
        else
        {
            optionsConfig.genToggles[6] = true;
            optionsConfig.toggleCount++;
        }
    }
    public void Gen8Toggle()
    {
        if (optionsConfig.genToggles[7])
        {
            optionsConfig.genToggles[7] = false;
            optionsConfig.toggleCount--;
        }
        else
        {
            optionsConfig.genToggles[7] = true;
            optionsConfig.toggleCount++;
        }
    }
    public void Gen9Toggle()
    {
        if (optionsConfig.genToggles[8])
        {
            optionsConfig.genToggles[8] = false;
            optionsConfig.toggleCount--;
        }
        else
        {
            optionsConfig.genToggles[8] = true;
            optionsConfig.toggleCount++;
        }
    }
    public void ArceusToggle()
    {
        if (optionsConfig.genToggles[9])
        {
            optionsConfig.genToggles[9] = false;
            optionsConfig.toggleCount--;
        }
        else
        {
            optionsConfig.genToggles[9] = true;
            optionsConfig.toggleCount++;
        }
    }
    public void SilhouettesToggle()
    {
        if (optionsConfig.silhouettes)
        {
            optionsConfig.silhouettes = false;
        }
        else
        {
            optionsConfig.silhouettes = true;
        }
    }

    public OptionsConfig GetOptionsConfig()
    {
        return optionsConfig;
    }
    public void SetOptionsConfig(OptionsConfig config)
    {
        optionsConfig = config;
    }
}
