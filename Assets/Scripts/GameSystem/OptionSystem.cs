using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSystem : MonoBehaviour
{
    public OptionData data { get; private set; }

    private void Awake()
    {
		data = OptionUtility.LoadOptionDataFromJson();
    }

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
        OptionUtility.SaveOptionDataToJson(data);
    }

    public void SetFullScreen(bool enableFullScreen)
    {
        data.FullScreen = enableFullScreen;
        Screen.fullScreen = enableFullScreen;
		OptionUtility.SaveOptionDataToJson(data);
	}

    public void SetGlobalVolume(float globalVolume)
    {
        data.GlobalVolume = globalVolume;
        
		OptionUtility.SaveOptionDataToJson(data);
	}

    public void SetMusicVolume(float musicVolume)
    {
        data.MusicVolume = musicVolume;

		OptionUtility.SaveOptionDataToJson(data);
	}

    public void SetEffectVolume(float EffectVolume)
    {
        data.EffectVolume = EffectVolume;

		OptionUtility.SaveOptionDataToJson(data);
	}

    public void SetAudioEnabled()
    {


		OptionUtility.SaveOptionDataToJson(data);
	}
}
