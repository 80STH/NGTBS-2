using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Newtonsoft.Json;
using System;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameVersion;

    //[SerializeField]
    //private TextMeshProUGUI SourceDataText;
    //[SerializeField]
    //private TMP_InputField InputField;
    //[SerializeField]
    //private TextMeshProUGUI SaveTimeText;
    //[SerializeField]
    //private TextMeshProUGUI LoadTimeText;

    //private GlobalStats globalStats = new GlobalStats();
    //private LocalStats localStats = new LocalStats();
    private IDataService DataService = new JsonDataService();
    private bool EncryptionEnabled;
    private long SaveTime;
    private long LoadTime;

    public void Start()
    {
        gameVersion.text = "0.0.2 InDev";
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadFile()
    {
        long startTime = DateTime.Now.Ticks;
        //if (DataService.SaveData("/player-stats.json", PlayerStats, EncryptionEnabled))
        //{
        //    SaveTime = DateTime.Now.Ticks - startTime;

        //    startTime = DateTime.Now.Ticks;
        //    try
        //    {
        //        //PlayerStats data = DataService.LoadData<PlayerStats>("/player-stats.json", EncryptionEnabled);
        //        LoadTime = DateTime.Now.Ticks - startTime;
        //        //InputField.text = "Loaded from file:\r\n" + JsonConvert.SerializeObject(data, Formatting.Indented);
        //        //LoadTimeText.SetText($"Load Time: {(LoadTime / TimeSpan.TicksPerMillisecond):N4}ms");
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.LogError($"Could not read file! Show something on the UI here!");
        //        //InputField.text = "<color=#ff0000>Error reading save file!</color>";
        //    }
        //}
        //else
        //{
        //    Debug.LogError("Could not save file! Show something on the UI about it!");
        //    //InputField.text = "<color=#ff0000>Error saving data!</color>";
        //}
    }
}
