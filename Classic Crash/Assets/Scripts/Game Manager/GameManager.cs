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
    private PlayerManager PlayerInfo;
    private Image FadePanel;
    private float FadeAmount;

    private string SafePath = "/game_save";

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
        return Directory.Exists(Application.persistentDataPath + SafePath);
    }

    public void SaveGame()
    {
        if (!IsSaveFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + SafePath);
        }
        if (!Directory.Exists(Application.persistentDataPath + SafePath  + "/player_data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + SafePath + "/player_data");
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + SafePath + "/player_data/collected_items.CB");
        var json = JsonUtility.ToJson(PlayerItems);
        bf.Serialize(file, json);
        file.Close();
    }

    public void LoadGame()
    {
        if (IsSaveFile())
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(Application.persistentDataPath + SafePath + "/player_data/collected_items.CB"))
            {
                FileStream file = File.Open(Application.persistentDataPath + SafePath + "/player_data/collected_items.CB", FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), PlayerItems);
                file.Close();
            }
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
