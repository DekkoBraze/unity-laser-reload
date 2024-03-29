using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] private TMP_Text energyText;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject completeScreen;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject soundManager;

    public static Angle0 angle0;
    public static Angle90 angle90;
    public static Angle180 angle180;
    public static Angle270 angle270;

    public static Manager link;
    public static Player playerLink;

    public Sprite[] turretTiles;

    public GameObject backgroundEmptyTile;
    public Sprite emtyTileSprite;
    public Sprite dangerEmptyTileSprite;
    public Sprite lavaTileSprite;
    public Sprite dangerAfterDeath;
    public Sprite dangerPortalAfterDeath;

    public Tile clickedTile { get; set; }
    public bool isMenuOn { get; set; } = false;
    public bool isCompleteScreenOn { get; set; } = false;
    public int stepCount { get; set; } = 0;
    public bool isItOver { get; set; }

    private void Awake()
    {
        link = this;

        angle0 = new Angle0();
        angle90 = new Angle90();
        angle180 = new Angle180();
        angle270 = new Angle270();

        playerLink = FindObjectOfType<Player>();

        Instantiate(soundManager);

        Messenger.Broadcast(GameEvent.SET_STATE);
    }

    private void Start()
    {
        isItOver = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }
        if (!isCompleteScreenOn && Input.GetKeyDown(KeyCode.Escape))
        {
            Messenger.Broadcast(GameEvent.BUTTON_SOUND);
            isMenuOn = !isMenuOn;
            menu.SetActive(isMenuOn);
            isItOver = isMenuOn;
        }
    }

    public void StepChange()
    {
        stepCount++;
        Messenger.Broadcast(GameEvent.NEXT_STEP);
    }

    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // ����� ��� ������� ���������� �������
    public void EnergyUpdate()
    {
        //energyText.text = playerLink.energy.ToString();
        playerLink.ChangePlayerAnim();
    }

    public void CompleteTextAppear()
    {
        completeScreen.SetActive(true);
        isCompleteScreenOn = true;
        isMenuOn = !isMenuOn;
        stepCount = 0;
    }

    public void OnPlayerDestroy()
    {
        gameOverScreen.SetActive(true);
        isCompleteScreenOn = true;
        isMenuOn = !isMenuOn;
        stepCount = 0;
    }

    public void ReloadScene()
    {
        Messenger.Broadcast(GameEvent.RELOAD_LEVEL_SOUND);
        isCompleteScreenOn = false;
        stepCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
