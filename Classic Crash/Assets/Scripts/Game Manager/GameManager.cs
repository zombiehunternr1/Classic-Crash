using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ItemsCollected PlayerItems;

    public SFXAkuAku SFXAkuAku;
    public SFXCollectables SFXCollectables;
    public SFXCrateTypes SFXCrateTypes;

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

    public void SFXCrateBreak()
    {
        SFXCrateTypes.PlayCrateBreak();
    }

    public void SFXCrateBounce()
    {
        SFXCrateTypes.PlayCrateBounce();
    }

    public void SFXTNTCountdown()
    {
        SFXCrateTypes.PlayTNTCountdown();
    }

    public void SFXTNTExplode()
    {
        SFXCrateTypes.PlayTNTExplode();
    }

    public void SFXStopTNTCountdown()
    {
        SFXCrateTypes.StopTNTCountdown();
    }

    public void SFXNitroExplode()
    {
        SFXCrateTypes.PlayNitroExplode();
    }

    public void SFXNitroSmalHop()
    {
        SFXCrateTypes.PlayNitroSmalHop();
    }

    public void SFXNitroBigHop()
    {
        SFXCrateTypes.PlayNitroBigHop();
    }

    public void SFXActivator()
    {
        SFXCrateTypes.PlayActivator();
    }

    public void SFXCrateActivating()
    {
        SFXCrateTypes.PlayCrateActivating();
    }

    public void SFXCheckPoint()
    {
        SFXCrateTypes.PlayCheckPoint();
    }
}
