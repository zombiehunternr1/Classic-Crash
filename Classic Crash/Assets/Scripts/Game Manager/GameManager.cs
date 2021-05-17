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
    public InputManager PlayerPosition;
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
        if (PlayerPosition == null)
        {
            PlayerPosition = FindObjectOfType<InputManager>();
        }
    }

    public IEnumerator FadingEffect(int scene, Transform BonusLevel)
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
            if(BonusLevel == null)
            {
                SceneManager.LoadScene(scene);
                yield return new WaitForSeconds(HoldNextFade);
                StartCoroutine(FadingEffect(scene, null));
            }
            else
            {
                yield return new WaitForSeconds(HoldNextFade);
                StartCoroutine(FadingEffect(scene, BonusLevel));
            }
        }
        else
        {
            if(PlayerPosition != null)
            {
                if(BonusLevel != null)
                {
                    PlayerPosition.PlayerPosition.position = BonusLevel.position;
                }
            }
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
