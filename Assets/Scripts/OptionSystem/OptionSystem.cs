using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSystem : MonoBehaviour
{
	static OptionSystem instance;
	public static OptionSystem Instence
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<OptionSystem>();
                if(instance == null)
                {
                    GameObject obj = new GameObject("OptionSystem");
                    obj.AddComponent<OptionSystem>();
                    DontDestroyOnLoad(obj);
                    instance = obj.GetComponent<OptionSystem>();
                }
            }
            return instance;
        }
    }

    public OptionData data { get; private set; }

    private void Awake()
    {
        instance = this;
        data = OptionUtility.LoadOptionDataFromJson();
    }

    public void SetResolution(ResolutionOption option)
    {
        switch(option)
        {
            case ResolutionOption.rDefault:
                break;
            case ResolutionOption.r1920x1080:
                break;
            case ResolutionOption.r1366x768:
				break;
            case ResolutionOption.r1280x720:
				break;
            case ResolutionOption.r960x540:
				break;
            case ResolutionOption.r640x360:
                break;
            case ResolutionOption.r320x180:
                break;
            default:
                break;
        }
    }

    public void SetRefreshRate(RefreshRateOption option)
    {
        switch (option)
        {
            case RefreshRateOption.rDefault:
                break;
            case RefreshRateOption.r30:
                break;
            case RefreshRateOption.r60:
                break;
            default:
                break;
        }
    }

    public void SetFullScreen(bool enableFullScreen)
    {
        
    }

    public void SetDisplay()
    {

    }

    public void SetVolume()
    {

    }

    public void SetGlobalVolume()
    {

    }

    public void SetMusicVolume()
    {

    }

    public void SetEffectVolume()
    {

    }

    public void SetAudioEnabled()
    {

    }
}
