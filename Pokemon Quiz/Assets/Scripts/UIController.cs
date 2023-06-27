using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private PokemonListsManager pokemonListsManager;
    [SerializeField] private Toggles toggles;
    [SerializeField] private PokemonGuessing pokemonGuessing;
    [SerializeField] private PokemonSelector pokemonSelector;
    [SerializeField] private GameObject correct;
    [SerializeField] private GameObject wrong;
    [SerializeField] private TMP_InputField inputText;
    [SerializeField] private Slider thresholdSlider;
    [SerializeField] private TextMeshProUGUI sliderValueText;
    [SerializeField] private Image image;
    [SerializeField] private GameObject main;
    [SerializeField] private GameObject gens;
    [SerializeField] private GameObject extra;
    [SerializeField] private GameObject reset;
    [SerializeField] private GameObject outOfPokemon;
    private bool caught;
    private bool confirm;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        pokemonListsManager = FindObjectOfType<PokemonListsManager>();
        if (gameManager == null)
        {
            return;
        }
        if (toggles != null)
        {
            toggles.SetOptionsConfig(gameManager.GetOptionsConfig());
        }
        if (thresholdSlider != null)
        {
            thresholdSlider.value = gameManager.GetOptionsConfig().threshold;
        }
        if (pokemonGuessing != null)
        {
            pokemonGuessing.SetThreshold(gameManager.GetOptionsConfig().threshold);
        }
    }

    private void OnEnable()
    {
        caught = false;
    }

    private void Update()
    {
        if (thresholdSlider != null)
        {
            sliderValueText.text = "" + (thresholdSlider.value / 100);
        }
        if (pokemonSelector != null)
        {
            if (pokemonSelector.GetPokemonInfo().no == -1 && !caught)
            {
                outOfPokemon.SetActive(true);
                caught = true;
            }
        }
    }

    // Main Menu Buttons
    public void OptionsButton()
    {
        SceneManager.LoadScene(2);
    }
    public void PlayButtion()
    {
        SceneManager.LoadScene(1);
    }

    // Options Menu Buttons
    public void BackButton()
    {
        gameManager.SetOptionsConfig(toggles.GetOptionsConfig());
        gameManager.SetThreshold(thresholdSlider.value);
        OptionsSave.Save(gameManager.GetOptionsConfig(), "OptionsConfig.json");
        pokemonListsManager.Clear();
        gameManager.ReorganizeActiveGens();
        SceneManager.LoadScene(0);
    }
    public void GensBackButton()
    {
        gens.SetActive(false);
        main.SetActive(true);
    }
    public void ExtraBackButton()
    {
        extra.SetActive(false);
        main.SetActive(true);
    }
    public void ResetBackButton()
    {
        reset.SetActive(false);
        main.SetActive(true);
    }
    public void GensButton()
    {
        main.SetActive(false);
        gens.SetActive(true);
    }
    public void ExtraButton()
    {
        main.SetActive(false);
        extra.SetActive(true);
    }
    public void ResetButton()
    {
        main.SetActive(false);
        reset.SetActive(true);
    }

    // Reset Menu Buttions
    
    public void ResetGen1Button()
    {
        PokemonDataDelete.DeleteJsonFile("gen1Progress.json");
    }
    public void ResetGen2Button()
    {
        PokemonDataDelete.DeleteJsonFile("gen2Progress.json");
    }
    public void ResetGen3Button()
    {
        PokemonDataDelete.DeleteJsonFile("gen3Progress.json");
    }
    public void ResetGen4Button()
    {
        PokemonDataDelete.DeleteJsonFile("gen4Progress.json");
    }
    public void ResetGen5Button()
    {
        PokemonDataDelete.DeleteJsonFile("gen5Progress.json");
    }
    public void ResetGen6Button()
    {
        PokemonDataDelete.DeleteJsonFile("gen6Progress.json");
    }
    public void ResetGen7Button()
    {
        PokemonDataDelete.DeleteJsonFile("gen7Progress.json");
    }
    public void ResetGen8Button()
    {
        PokemonDataDelete.DeleteJsonFile("gen8Progress.json");
    }
    public void ResetGen9Button()
    {
        PokemonDataDelete.DeleteJsonFile("gen9Progress.json");
    }
    public void ResetArceusButton()
    {
        PokemonDataDelete.DeleteJsonFile("legendsArceusProgress.json");
    }
    public void ResetAllButton()
    {
        PokemonDataDelete.DeleteJsonFile("gen1Progress.json");
        PokemonDataDelete.DeleteJsonFile("gen2Progress.json");
        PokemonDataDelete.DeleteJsonFile("gen3Progress.json");
        PokemonDataDelete.DeleteJsonFile("gen4Progress.json");
        PokemonDataDelete.DeleteJsonFile("gen5Progress.json");
        PokemonDataDelete.DeleteJsonFile("gen6Progress.json");
        PokemonDataDelete.DeleteJsonFile("gen7Progress.json");
        PokemonDataDelete.DeleteJsonFile("gen8Progress.json");
        PokemonDataDelete.DeleteJsonFile("gen9Progress.json");
        PokemonDataDelete.DeleteJsonFile("legendsArceusProgress.json");
    }

    // Play Screen Buttons
    public void SubmitButton()
    {
        if (pokemonGuessing.CheckAnswer())
        {
            StartCoroutine(Right());
        }
        else
        {
            StartCoroutine(Wrong());
        }
    }
    public void PlayBackButton()
    {
        SceneManager.LoadScene(0);
    }
    public void SkipButton()
    {
        inputText.text = "";
        pokemonSelector.SelectPokemon();
    }

    private IEnumerator Wrong()
    {
        wrong.SetActive(true);
        yield return new WaitForSeconds(1f);
        wrong.SetActive(false);
    }
    private IEnumerator Right()
    {
        correct.SetActive(true);
        image.color = Color.white;
        yield return new WaitForSeconds(1f);
        correct.SetActive(false);
        inputText.text = "";
        pokemonListsManager.RemoveItem(pokemonSelector.GetPokemonInfo().no);
        pokemonListsManager.SaveCurrentLists();
        pokemonSelector.SelectPokemon();
    }

    // Other
    public void ConfirmButton()
    {

    }
    public void DenyButton()
    {

    }
}
