using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    public float BgmVolume = 0.5f;
    public float SeVolume = 1.0f;

    // BGM用のオーディオソース
    private AudioSource bgmAudioSource;

    // SE用のオーディオソース
    private AudioSource seAudioSource;

    // BGM用のオーディオクリップ
    public AudioClip bgmClip;

    // SE用のオーディオクリップの辞書
    public List<AudioClip> seClipList;
    public List<string> seClipNames;
    private Dictionary<string, AudioClip> seClips;

    private void Awake() {
        // インスタンスが存在するか確認
        if (Instance == null) {
            // インスタンスが存在しない場合、このインスタンスを設定
            Instance = this;
            // シーンをまたいでも破棄されないようにする
            DontDestroyOnLoad(gameObject);
        }
        else {
            // インスタンスが既に存在する場合、このオブジェクトを破棄する
            Destroy(gameObject);
        }

        // AudioSourceコンポーネントを取得または追加
        bgmAudioSource = gameObject.AddComponent<AudioSource>();
        bgmAudioSource.volume = BgmVolume;
        seAudioSource = gameObject.AddComponent<AudioSource>();
        seAudioSource.volume = SeVolume;

        // SEクリップのリストを辞書に変換
        seClips = MakeClipDict(seClipList, seClipNames);
    }

    //dictionaryに変換
    private Dictionary<string, AudioClip> MakeClipDict(List<AudioClip> seClipList, List<string>seClipNames) {
        Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();
        for(int i = 0; i < seClipList.Count; i++) {
            clips[seClipNames[i]] = seClipList[i];
        }
        return clips;
    }

    private void Start() {
        // BGMを再生
        PlayBGM();
    }

    // BGMを再生するメソッド
    public void PlayBGM() {
        if (bgmAudioSource != null && bgmClip != null) {
            bgmAudioSource.clip = bgmClip;
            bgmAudioSource.loop = true;
            bgmAudioSource.Play();
        }
    }

    // BGMを停止するメソッド
    public void StopBGM() {
        if (bgmAudioSource != null) {
            bgmAudioSource.Stop();
        }
    }

    // SEを辞書から再生するメソッド
    public void PlaySE(string name) {
        if (seAudioSource != null && seClips.ContainsKey(name)) {
            seAudioSource.PlayOneShot(seClips[name]);
        }
    }
}
