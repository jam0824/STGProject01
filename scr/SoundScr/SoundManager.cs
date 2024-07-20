using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    public float BgmVolume = 0.5f;
    public float SeVolume = 1.0f;

    // BGM�p�̃I�[�f�B�I�\�[�X
    private AudioSource bgmAudioSource;

    // SE�p�̃I�[�f�B�I�\�[�X
    private AudioSource seAudioSource;

    // BGM�p�̃I�[�f�B�I�N���b�v
    public AudioClip bgmClip;

    // SE�p�̃I�[�f�B�I�N���b�v�̎���
    public List<AudioClip> seClipList;
    public List<string> seClipNames;
    private Dictionary<string, AudioClip> seClips;

    private void Awake() {
        // �C���X�^���X�����݂��邩�m�F
        if (Instance == null) {
            // �C���X�^���X�����݂��Ȃ��ꍇ�A���̃C���X�^���X��ݒ�
            Instance = this;
            // �V�[�����܂����ł��j������Ȃ��悤�ɂ���
            DontDestroyOnLoad(gameObject);
        }
        else {
            // �C���X�^���X�����ɑ��݂���ꍇ�A���̃I�u�W�F�N�g��j������
            Destroy(gameObject);
        }

        // AudioSource�R���|�[�l���g���擾�܂��͒ǉ�
        bgmAudioSource = gameObject.AddComponent<AudioSource>();
        bgmAudioSource.volume = BgmVolume;
        seAudioSource = gameObject.AddComponent<AudioSource>();
        seAudioSource.volume = SeVolume;

        // SE�N���b�v�̃��X�g�������ɕϊ�
        seClips = MakeClipDict(seClipList, seClipNames);
    }

    //dictionary�ɕϊ�
    private Dictionary<string, AudioClip> MakeClipDict(List<AudioClip> seClipList, List<string>seClipNames) {
        Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();
        for(int i = 0; i < seClipList.Count; i++) {
            clips[seClipNames[i]] = seClipList[i];
        }
        return clips;
    }

    private void Start() {
        // BGM���Đ�
        PlayBGM();
    }

    // BGM���Đ����郁�\�b�h
    public void PlayBGM() {
        if (bgmAudioSource != null && bgmClip != null) {
            bgmAudioSource.clip = bgmClip;
            bgmAudioSource.loop = true;
            bgmAudioSource.Play();
        }
    }

    // BGM���~���郁�\�b�h
    public void StopBGM() {
        if (bgmAudioSource != null) {
            bgmAudioSource.Stop();
        }
    }

    // SE����������Đ����郁�\�b�h
    public void PlaySE(string name) {
        if (seAudioSource != null && seClips.ContainsKey(name)) {
            seAudioSource.PlayOneShot(seClips[name]);
        }
    }
}
