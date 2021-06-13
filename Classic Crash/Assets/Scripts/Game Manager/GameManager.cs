using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ItemsCollected PlayerItems;
    public WorldMapLocation WorldMapLocation;
    public SFXAkuAku SFXAkuAku;
    public SFXCollectables SFXCollectables;

    public float FadeSpeed;
    public int HoldNextFade;
    [HideInInspector]
    public bool FadeToBlack;
    [HideInInspector]
    public bool CanMove = true;
    [HideInInspector]
    public int Scene;
    [HideInInspector]
    public PlayerManager PlayerInfo;
    private Image FadePanel;
    private float FadeAmount;

    private string SavePath = "/game_save";
    private string PlayerData = "/player_data";

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        FadePanel = GetComponentInChildren<Image>();
        FindPlayer();
    }

    private bool IsSaveFile()
    {
        return Directory.Exists(Application.persistentDataPath + SavePath);
    }

    public void SaveGame()
    {
        if (!IsSaveFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + SavePath);
        }
        if (!Directory.Exists(Application.persistentDataPath + SavePath  + PlayerData))
        {
            Directory.CreateDirectory(Application.persistentDataPath + SavePath + PlayerData);
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream CollectedItems = File.Create(Application.persistentDataPath + SavePath + PlayerData + "/collected_items.CB");
        FileStream WorldMap = File.Create(Application.persistentDataPath + SavePath + PlayerData + "/worldmap.CB");
        string CollectedItemsJson = JsonUtility.ToJson(PlayerItems);
        string WorldMapJson = JsonUtility.ToJson(WorldMapLocation);
        bf.Serialize(CollectedItems, CollectedItemsJson);
        bf.Serialize(WorldMap, WorldMapJson);
        CollectedItems.Close();
    }

    public void LoadGame()
    {
        if (IsSaveFile())
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(Application.persistentDataPath + SavePath + PlayerData + "/collected_items.CB"))
            {
                FileStream CollectedItems = File.Open(Application.persistentDataPath + SavePath + PlayerData + "/collected_items.CB", FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)bf.Deserialize(CollectedItems), PlayerItems);
                CollectedItems.Close();
            }
            if(File.Exists(Application.persistentDataPath + SavePath + PlayerData + "/worldmap.CB"))
            {
                FileStream Worldmap = File.Open(Application.persistentDataPath + SavePath + PlayerData + "/worldmap.CB", FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)bf.Deserialize(Worldmap), WorldMapLocation);
                Worldmap.Close();
            }
            Scene = SceneManager.GetActiveScene().buildIndex + 1;
            StartCoroutine(FadingEffect(null));
        }
    }

    public void SFXAkuAkuAdd()
    {
        SFXAkuAku.PlayAddSFX();
    }

    public void SFXWithdrawAkuAku()
    {
        SFXAkuAku.PlayWithdrawSFX();
    }

    public void SFXInvinsibility()
    {
        SFXAkuAku.PlayInvinsibilitySFX();
    }

    public void SFXStopInvinsiblility()
    {
        SFXAkuAku.StopInvinsibility();
    }

    public void SFXAddWumpa()
    {
        SFXCollectables.PlayWumpaAdd();
    }

    public void SFXAddLife()
    {
        SFXCollectables.PlayLifeAdd();
    }

    public void SFXGemCollected()
    {
        SFXCollectables.PlayGemCollected();
    }

    public void SFXSpinAway()
    {
        SFXCollectables.PlaySpinAway();
    }

    public void FindPlayer()
    {
        if (PlayerInfo == null)
        {
            PlayerInfo = FindObjectOfType<PlayerManager>();
        }
    }

    public void GetScene()
    {
        Scene = SceneManager.GetActiveScene().buildIndex;
    }

    public IEnumerator FadingEffect(Transform BonusLevel)
    {
        if (FadeToBlack)
        {
            CanMove = false;
            while (FadePanel.color.a < 1)
            {
                Color ChangeColor = FadePanel.color;
                FadeAmount = ChangeColor.a + (FadeSpeed * Time.deltaTime);

                ChangeColor = new Color(ChangeColor.r, ChangeColor.g, ChangeColor.b, FadeAmount);
                FadePanel.color = ChangeColor;
                yield return null;
            }
            FadeToBlack = false;                 
            if (PlayerInfo != null)
            {
                if (PlayerInfo.Player.Instakill)
                {
                    PlayerInfo.CheckLifeTotal();
                    yield break;
                }
                else
                {
                    yield return new WaitForSeconds(HoldNextFade);
                    StartCoroutine(FadingEffect(BonusLevel));
                }
            }
            if (BonusLevel == null)
            {
                SceneManager.LoadScene(Scene);
                yield return new WaitForSeconds(HoldNextFade);
                StartCoroutine(FadingEffect(null));
            }
        }
        else
        {
            if(PlayerInfo != null)
            {
                if(BonusLevel != null)
                {
                    PlayerInfo.Player.PlayerPosition.position = BonusLevel.position;
                }
                if (PlayerInfo.Player.Instakill)
                {
                    PlayerInfo.Player.Instakill = false;
                }
            }
            yield return new WaitForSeconds(HoldNextFade);
            while(FadePanel.color.a > 0)
            {
                Color ChangeColor = FadePanel.color;
                FadeAmount = ChangeColor.a - (FadeSpeed * Time.deltaTime);

                ChangeColor = new Color(ChangeColor.r, ChangeColor.g, ChangeColor.b, FadeAmount);
                FadePanel.color = ChangeColor;
                yield return null;
            }
            CanMove = true;
            FadeToBlack = true;
        }
    }
}
