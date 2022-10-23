using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;

	public bool EnableAudio;
	public float GlobalVolume;
	public float MusicVolume;
	public float EffectVolume;

	private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if(audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        //TODO 加载失败
        AudioMixerGroup group = Resources.Load<AudioMixer>("/Audio/Mixers/MainMixer.mixer").FindMatchingGroups("Master")[0];
        audioSource.outputAudioMixerGroup = group;
    }

    //播放

    public void PlayMusic(string name, bool isLoop = false)
    {
        if(EnableAudio)
        {
			audioSource.clip = GetAudioClip(name);
			audioSource.loop = isLoop;
			audioSource.Play();
		}
	}

    public void PlayeEffectSound(string name, bool isLoop = false)
    {
        if(EnableAudio)
        {

        }
    }


    //暂停播放
    public void AudioPause()
    {
        audioSource.Pause();
    }

    //暂停后继续
    public void AudioContinue()
    {
        audioSource.UnPause();
    }

    //暂停播放
    public void AudioStop()
    {
        audioSource.Stop();
    }

    //切换音频
    public void AudioSwitch(string name, bool isLoop = false)
    {
        AudioClip clip = GetAudioClip(name);
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.clip = clip;
        audioSource.loop = isLoop;
        audioSource.Play();
    }
	#region Utility
	public static AudioClip GetAudioClip(string name)
	{
		return Resources.Load<AudioClip>("Audio/" + name);
	}
	#endregion
}