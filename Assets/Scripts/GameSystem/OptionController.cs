using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OptionController : MonoBehaviour
{
    public static OptionController Instance { get; private set; }
    public OptionData data { get; private set; }
    public Canvas OptionMenu;

	public Scrollbar musicVolume, effectVolume;
	public TMP_Dropdown resolution, window;
    public Button Exit, Return, ReturnToMenu;

	private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
		data = FileUtility.LoadOptionDataFromJson();
        OptionMenu.enabled = false;
    }

    public void StartMenu()
    {
        OptionMenu.enabled = true;
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            //Return.enabled = false;
            ReturnToMenu.gameObject.SetActive(false);
            Exit.gameObject.SetActive(false);
        }
    }

    public void StopMenu()
    {
        OptionMenu.enabled = false;
	}



    #region APIs
    public void SetResolution(ResolutionOption option)
    {
        data.Resolution = option;
        switch(option)
        {
            case ResolutionOption.r1920x1080:
                Screen.SetResolution(1920, 1080, data.FullScreen);
                break;
            case ResolutionOption.r1366x768:
				Screen.SetResolution(1366, 768, data.FullScreen);
				break;
            case ResolutionOption.r1280x720:
				Screen.SetResolution(1280, 720, data.FullScreen);
				break;
            case ResolutionOption.r960x540:
				Screen.SetResolution(960, 540, data.FullScreen);
				break;
            case ResolutionOption.r640x360:
				Screen.SetResolution(640, 360, data.FullScreen);
				break;
            case ResolutionOption.r320x180:
				Screen.SetResolution(320, 180, data.FullScreen);
				break;
            default:
                break;
        }
        FileUtility.SaveOptionDataToJson(data);
    }

    public void SetFullScreen(bool enableFullScreen)
    {
        data.FullScreen = enableFullScreen;
        Screen.fullScreen = enableFullScreen;
		FileUtility.SaveOptionDataToJson(data);
	}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="musicVolume">Range[0f, 100f]</param>
    public void SetMusicVolume(float musicVolume)
    {
        data.MusicVolume = musicVolume;
		FileUtility.SaveOptionDataToJson(data);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="effectVolume">Range[0f, 100f]</param>
	public void SetEffectVolume(float effectVolume)
    {
        data.EffectVolume = effectVolume;
		FileUtility.SaveOptionDataToJson(data);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="enableAudio">Range[0f, 100f]</param>
	public void SetAudioEnabled(bool enableAudio)
    {
        data.EnableAudio = enableAudio;
		FileUtility.SaveOptionDataToJson(data);
	}
	#endregion
}
