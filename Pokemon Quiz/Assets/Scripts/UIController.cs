using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

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
    [SerializeField] private ConfirmationWindow confirmationWindow;
    private bool caught;
    private bool checking;
    private bool confirm;

    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        pokemonListsManager = FindFirstObjectByType<PokemonListsManager>();
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
        checking = false;
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
        OptionsManager.Save(gameManager.GetOptionsConfig(), "OptionsConfig.json");
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
    
    public async void ResetGen1Button()
    {
        OpenConfirmationWindow("This will delete your Gen 1 Pokemon data");
        DeleteData("gen1Progress.json");
        confirm = false;
    }
    public void ResetGen2Button()
    {
        
        //if (confirm){
            PokemonDataManager.Delete("gen2Progress.json");
        //}
        //confirm = false;
    }
    public void ResetGen3Button()
    {
        
        //if (confirm){
            PokemonDataManager.Delete("gen3Progress.json");
        //}
        //confirm = false;
    }
    public void ResetGen4Button()
    {
        
        //if (confirm){
            PokemonDataManager.Delete("gen4Progress.json");
        //}
        //confirm = false;
    }
    public void ResetGen5Button()
    {
        
        //if (confirm){
            PokemonDataManager.Delete("gen5Progress.json");
        //}
        //confirm = false;
    }
    public void ResetGen6Button()
    {
        
        //if (confirm){
            PokemonDataManager.Delete("gen6Progress.json");
        //}
        //confirm = false;
    }
    public void ResetGen7Button()
    {
        
        //if (confirm){
            PokemonDataManager.Delete("gen7Progress.json");
        //}
        //confirm = false;
    }
    public void ResetGen8Button()
    {
        
        //if (confirm){
            PokemonDataManager.Delete("gen8Progress.json");
        //}
        //confirm = false;
    }
    public void ResetGen9Button()
    {
        
        //if (confirm){
            PokemonDataManager.Delete("gen9Progress.json");
        //}
        //confirm = false;
    }
    public void ResetArceusButton()
    {
        
        //if (confirm) {
        PokemonDataManager.Delete("legendsArceusProgress.json");
        //}
        //confirm = false;
    }
    public void ResetAllButton()
    {
        //await Task.Run(() => OpenConfirmationWindow(""));
        //if (confirm) 
        //{
            PokemonDataManager.Delete("gen1Progress.json");
            PokemonDataManager.Delete("gen2Progress.json");
            PokemonDataManager.Delete("gen3Progress.json");
            PokemonDataManager.Delete("gen4Progress.json");
            PokemonDataManager.Delete("gen5Progress.json");
            PokemonDataManager.Delete("gen6Progress.json");
            PokemonDataManager.Delete("gen7Progress.json");
            PokemonDataManager.Delete("gen8Progress.json");
            PokemonDataManager.Delete("gen9Progress.json");
            PokemonDataManager.Delete("legendsArceusProgress.json");
        //}
        
        //confirm = false;
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
        if (!checking)
        {
            checking = true;
            correct.SetActive(true);
            image.color = Color.white;
            yield return new WaitForSeconds(1f);
            correct.SetActive(false);
            inputText.text = "";
            pokemonListsManager.RemoveItem(pokemonSelector.GetPokemonInfo().no);
            pokemonListsManager.SaveCurrentLists();
            pokemonSelector.SelectPokemon();
            checking = false;
        }
    }

    // Other
    public void YesButton()
    {
        confirmationWindow.gameObject.SetActive(false);
        confirm = true;
    }
    public void NoButton()
    {
        confirmationWindow.gameObject.SetActive(false);
        confirm = false;
    }
    public void OpenConfirmationWindow(string context)
    {
        confirmationWindow.gameObject.SetActive(true);
        confirmationWindow.yesButton.onClick.AddListener(YesButton);
        confirmationWindow.noButton.onClick.AddListener(NoButton);
        confirmationWindow.contextText.text = context;
    }
    private void DeleteData(string file)
    {
        if (confirm)
        {
            PokemonDataManager.Delete(file);
            Debug.Log("Gen 1 deleted");
        }
        else Debug.Log("Gen 1 not deleted");
    }
}
