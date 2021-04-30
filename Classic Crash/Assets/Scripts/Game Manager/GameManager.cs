using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ItemsCollected PlayerItems;

    private SFXAkuAku SFXAkuAku;

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
        SFXAkuAku = GetComponentInChildren<SFXAkuAku>();
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
}
