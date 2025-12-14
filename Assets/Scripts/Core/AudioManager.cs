using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField]private AudioSource bgmSource;
    [SerializeField]private AudioSource sfxSource;

    [Header("BGM Clips")]
    public AudioClip titleBgm;       // 타이틀 BGM
    public AudioClip gameplayBgm;    // 게임플레이 BGM

    public AudioClip deleteObjectSfx;  // 오브젝트 삭제
    public AudioClip elevatorMoveSfx;  // 엘리베이터 이동
    public AudioClip switchClickSfx;   // 스위치 클릭
    public AudioClip enterDoorSfx;     // 문 입장
    public AudioClip gameOver;
    public AudioClip playerChange;

    public AudioClip clearSfx;         // 클리어
    public AudioClip uiClickSfx;       // UI 클릭


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayBgm(AudioClip clip)
    {
        if (bgmSource.clip == clip && bgmSource.isPlaying) return;

        bgmSource.clip = clip;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void StopBGM() {
        bgmSource.Stop();
    }

    public void PauseBGM() {
        bgmSource.Pause();
    }

    public void ResumeBGM() {
        bgmSource.UnPause();
    }
}