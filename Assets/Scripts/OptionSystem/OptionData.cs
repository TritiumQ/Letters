using System;

[Serializable]
internal class OptionData
{
	public bool EnableAudio;
	public float GlobalVolume;
	public float MusicVolume;
	public float EffectVolume;

	public Resolutions Resolution;
	public bool FullScreen;


}

[Serializable]
public enum Resolutions
{
	r1920x1080,
	r1366x768,
	r1280x720,
	r960x540,
	r640x360,
	r320x180,
}