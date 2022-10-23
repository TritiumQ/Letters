using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//音频数据类
public class ClipData
{
    public AudioClip Audiodata(string name)
    {
        return Resources.Load<AudioClip>("Audio/" + name);
    }
}
public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    ClipData clipdata = new ClipData();
    private AudioSource audioSource;
    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //循环播放
    public void AudioPlayLoop(string name)
    {
        audioSource.clip = clipdata.Audiodata(name);
        audioSource.loop = true;
        audioSource.Play();
    }

    //播放音频
    public void AudioPlay(string name)
    {
        audioSource.clip = clipdata.Audiodata(name);
        audioSource.loop = false;
        audioSource.Play();
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
    public void AudioSwitch(string name)
    {
        AudioClip clip = clipdata.Audiodata(name);
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.clip = clip;
        audioSource.loop = false;
        audioSource.Play();
    }

    //切换循环音频
    public void AudioSwitchLoop(string name)
    {
        AudioClip clip = clipdata.Audiodata(name);
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
