using UnityEngine;

[System.Serializable]
public class OptionData
{
	public bool EnableAudio;
	public float GlobalVolume;
	public float MusicVolume;
	public float EffectVolume;

	public ResolutionOption Resolution;
	public bool FullScreen;
	
	public OptionData()
	{
		EnableAudio = OptionUtility.DefaultEnableAudio;
		GlobalVolume = OptionUtility.DefaultGlobalVolume;
		MusicVolume = OptionUtility.DefaultMusicVolume;
		EffectVolume = OptionUtility.DefaultEffectVolume;
		Resolution = OptionUtility.DefaultResolution;
		FullScreen = OptionUtility.DefaultFullScreen;

	}

	public OptionData
		(
			bool enableAudio, 
			float globalVolume, 
			float musicVolume, 
			float effectVolume, 
			ResolutionOption resolutionOption,
			bool fullScreen
		)
	{
		EnableAudio = enableAudio;
		GlobalVolume = globalVolume;
		MusicVolume = musicVolume;
		EffectVolume = effectVolume;
		Resolution = resolutionOption;
		FullScreen = fullScreen;
	}

	public void SetResolutionDefault()
	{
		Resolution = OptionUtility.DefaultResolution;
		FullScreen = OptionUtility.DefaultFullScreen;
	}

	public void SetVolumeDefault()
	{
		EnableAudio = OptionUtility.DefaultEnableAudio;
		GlobalVolume = OptionUtility.DefaultGlobalVolume;
		MusicVolume = OptionUtility.DefaultMusicVolume;
		EffectVolume = OptionUtility.DefaultEffectVolume;
	}

	public void SetDefault()
	{
		EnableAudio = OptionUtility.DefaultEnableAudio;
		GlobalVolume = OptionUtility.DefaultGlobalVolume;
		MusicVolume = OptionUtility.DefaultMusicVolume;
		EffectVolume = OptionUtility.DefaultEffectVolume;
		Resolution = OptionUtility.DefaultResolution;
		FullScreen = OptionUtility.DefaultFullScreen;
	}
}

[System.Serializable]
public enum ResolutionOption
{
	r1920x1080,
	r1366x768,
	r1280x720,
	r960x540,
	r640x360,
	r320x180,
}