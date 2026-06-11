using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
public static GameManager Instance;

[Header("Game State Trackers")]
private bool isGameOver = false;
public int targetsRemaining = 5;

[Header("Score System")]
public int score = 0;

[Header("Audio Clips (Designer Exposed)")]
public AudioClip shootSound;
public AudioClip hitSound;
public AudioClip backgroundMusic;
public AudioClip explosionSound;

[Header("Audio Sources")]
public AudioSource musicSource;
public AudioSource sfxSource;

[Header("Audio Mixer")]
public AudioMixer audioMixer;

private void Awake()
{
    if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }
    else
    {
        Destroy(gameObject);
    }
}

private void Start()
{
    //background music
    if (musicSource != null && backgroundMusic != null)
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.volume = 0.3f;
        musicSource.Play();
    }

    float musicVol = PlayerPrefs.GetFloat("MusicVolume", 0.3f);
    float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 1f);

    SetMusicVolume(musicVol);
    SetSFXVolume(sfxVol);
}

public void AddScore(int amount)
{
    if (isGameOver) return;

    score += amount;
    Debug.Log("Score: " + score);
}

public void TargetDestroyed()
{
    if (isGameOver) return;

    targetsRemaining--;
    Debug.Log("Targets remaining: " + targetsRemaining);

    if (targetsRemaining <= 0)
    {
        TriggerVictory();
    }
}

public void PlayerDied()
{
    if (isGameOver) return;

    isGameOver = true;
    Debug.Log("Game Over!");
    Time.timeScale = 0f;
} 

private void TriggerVictory()
{
    isGameOver = true;
    Debug.Log("You Win!");
    Time.timeScale = 0f;
} 

public void RestartGame()
{
    Time.timeScale = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}

public bool IsGameOver()
{
    return isGameOver;
}

//sound effects

public void PlayShootSound()
{
    if (sfxSource != null && shootSound != null)
    {
        sfxSource.pitch = Random.Range(0.9f, 1.1f);
        sfxSource.PlayOneShot(shootSound);
    }
}

public void PlayHitSound()
{
    if (sfxSource != null && hitSound != null)
    {
        sfxSource.PlayOneShot(hitSound, 1.5f); // 🔥 louder
    }
}

public void PlayExplosionSound()
{
    if (sfxSource != null && explosionSound != null)
    {
        sfxSource.PlayOneShot(explosionSound, 2f); // 🔥 louder
    }
}

//volume control

public void SetMusicVolume(float value)
{
    if (audioMixer != null)
    {
        value = Mathf.Clamp(value, 0.0001f, 1f);
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }
}

public void SetSFXVolume(float value)
{
    if (audioMixer != null)
    {
        value = Mathf.Clamp(value, 0.0001f, 1f);
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("SFXVolume", value);
    }
}

//test keys

void Update()
{
    if (Input.GetKeyDown(KeyCode.F))
    {
        Debug.Log("Playing Shoot Sound");
        PlayShootSound();
    }

    if (Input.GetKeyDown(KeyCode.G))
    {
        Debug.Log("Playing Hit Sound");
        PlayHitSound();
    }

    if (Input.GetKeyDown(KeyCode.H))
    {
        Debug.Log("Playing Explosion Sound");
        PlayExplosionSound();
    }
}


public class TargetHum : MonoBehaviour
{
    public Transform player;
    public AudioSource humSource;

//sound distance
    public float maxDistance = 30f; 

    void Update()
    {
        if (player == null || humSource == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        //volume decreases with distance
        float volume = 1 - (distance / maxDistance);
        humSource.volume = Mathf.Clamp01(volume);
    }
}
}
