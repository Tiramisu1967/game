using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable] // 클래스 안의 정보(변수)들이 인스펙터에 표시 될 수 있도록
public class Sound  // 컴포넌트 추가 불가능.  MonoBehaviour 상속 안 받아서. 그냥 C# 클래스.
{
    public string Name;  // 곡 이름
    public AudioClip Clip;  // 곡
}

public class SoundManager : BaseManager
{
    static public SoundManager instance;  // 자기 자신을 공유 자원으로. static은 씬이 바뀌어도 유지된다.

    [SerializeField]
    private Sound[] SFXSounds;  // 효과음 오디오 클립들

    [SerializeField]
    private Sound[] BgmSounds;  // BGM 오디오 클립들

    [SerializeField]
    private AudioSource AudioSourceBgm;  // BGM 재생기. BGM 재생은 한 군데서만 이루어지면 되므로 배열 X 

    [SerializeField]
    private AudioSource[] AudioSourceSFX;  // 효과음들은 동시에 여러개가 재생될 수 있으므로 'mp3 재생기'를 배열로 선언

    private void Awake()  // 객체 생성시 최초 실행 (그래서 싱글톤을 여기서 생성)
    {
        if (instance == null)  // 단 하나만 존재하게끔
        {
            instance = this;  // 객체 생성시 instance에 자기 자신을 넣어줌
        }
        else
            Destroy(this.gameObject);
    }

    public void PlaySFX(string _name)
    {
        for (int i = 0; i < SFXSounds.Length; i++)
        {
            if (_name == SFXSounds[i].Name)
            {
                for (int j = 0; j < AudioSourceSFX.Length; j++)
                {
                    if (false == AudioSourceSFX[j].isPlaying)
                    {
                        AudioSourceSFX[j].clip = SFXSounds[i].Clip;
                        AudioSourceSFX[j].Play();
                        return;
                    }
                }
                return;
            }
        }
        Debug.Log(_name + "사운드가 SoundManager에 등록되지 않았습니다.");
    }

    public void PlayBGM(string _name)
    {
        for (int i = 0; i < BgmSounds.Length; i++)
        {
            if (_name == BgmSounds[i].Name)
            {
                AudioSourceBgm.clip = BgmSounds[i].Clip;
                AudioSourceBgm.Play();
                return;
            }
        }
        Debug.Log(_name + "사운드가 SoundManager에 등록되지 않았습니다.");
    }

    public void StopAllSFX()
    {
        for (int i = 0; i < AudioSourceSFX.Length; i++)
        {
            AudioSourceSFX[i].Stop();
        }
    }
}