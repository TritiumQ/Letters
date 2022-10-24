using UnityEngine;

[System.Serializable]
public class OptionData
{
	public bool EnableAudio;
	public float MusicVolume;
	public float EffectVolume;

	public ResolutionOption Resolution;
	public bool FullScreen;
	
	public OptionData()
	{
		EnableAudio = FileUtility.DefaultEnableAudio;
		MusicVolume = FileUtility.DefaultMusicVolume;
		EffectVolume = FileUtility.DefaultEffectVolume;
		Resolution = FileUtility.DefaultResolution;
		FullScreen = FileUtility.DefaultFullScreen;

	}

	public OptionData
		(
			bool enableAudio, 
			float musicVolume, 
			float effectVolume, 
			ResolutionOption resolutionOption,
			bool fullScreen
		)
	{
		EnableAudio = enableAudio;
		MusicVolume = musicVolume;
		EffectVolume = effectVolume;
		Resolution = resolutionOption;
		FullScreen = fullScreen;
	}

	public void SetResolutionDefault()
	{
		Resolution = FileUtility.DefaultResolution;
		FullScreen = FileUtility.DefaultFullScreen;
	}

	public void SetVolumeDefault()
	{
		EnableAudio = FileUtility.DefaultEnableAudio;
		MusicVolume = FileUtility.DefaultMusicVolume;
		EffectVolume = FileUtility.DefaultEffectVolume;
	}

	public void SetDefault()
	{
		EnableAudio = FileUtility.DefaultEnableAudio;
		MusicVolume = FileUtility.DefaultMusicVolume;
		EffectVolume = FileUtility.DefaultEffectVolume;
		Resolution = FileUtility.DefaultResolution;
		FullScreen = FileUtility.DefaultFullScreen;
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