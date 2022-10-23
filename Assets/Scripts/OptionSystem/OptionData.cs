using UnityEngine;

[System.Serializable]
public class OptionData
{
	public bool EnableAudio;
	public float GlobalVolume;
	public float MusicVolume;
	public float EffectVolume;

	public ResolutionOption Resolution;
	public RefreshRateOption RefreshRate;
	public bool FullScreen;
	
	public OptionData()
	{
		EnableAudio = OptionUtility.DefaultEnableAudio;
		GlobalVolume = OptionUtility.DefaultGlobalVolume;
		MusicVolume = OptionUtility.DefaultMusicVolume;
		EffectVolume = OptionUtility.DefaultEffectVolume;
		Resolution = OptionUtility.DefaultResolution;
		RefreshRate = OptionUtility.DefaultRefreshRate;
		FullScreen = OptionUtility.DefaultFullScreen;

	}

	public OptionData
		(
			bool enableAudio, 
			float globalVolume, 
			float musicVolume, 
			float effectVolume, 
			ResolutionOption resolutionOption, 
			RefreshRateOption refreshRate, 
			bool fullScreen
		)
	{
		EnableAudio = enableAudio;
		GlobalVolume = globalVolume;
		MusicVolume = musicVolume;
		EffectVolume = effectVolume;
		Resolution = resolutionOption;
		RefreshRate = refreshRate;
		FullScreen = fullScreen;
	}
}

[System.Serializable]
public enum ResolutionOption
{
	rDefault,
	r1920x1080,
	r1366x768,
	r1280x720,
	r960x540,
	r640x360,
	r320x180,
}

[System.Serializable]
public enum RefreshRateOption
{
	rDefault,
	r30,
	r60,
}