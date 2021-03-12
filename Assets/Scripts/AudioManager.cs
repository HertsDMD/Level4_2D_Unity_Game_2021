using UnityEngine;

[System.Serializable]
public class Sound
{
    public string nameOfSound;
    public AudioClip clip;

    [Range (0f,1f)]
    public float volume = 0.7f;

    [Range(0f, 0.5f)]
    public float volumeRandomness = 0.1f; // adds some volume variation to a repetitive sound

    [Range(0.5f, 2f)]
    public float pitch = 1f;

    [Range(0f, 0.5f)]
    public float pitchRandomness = 0.1f; // adds some pitch variation to a repetitive sound
    [Range(0f, 1f)]

    public float stereoPan;
    public bool loop;

    [Header("Reverb Settings")]
    public AudioReverbPreset reverbPreset;  
  

    private AudioSource source;
    private AudioReverbFilter reverbFilter;
    public void SetSource(AudioSource _source, AudioReverbFilter _reverbFilter)
    {
        source = _source;
        source.clip = clip;
        source.loop = loop;
        source.panStereo = stereoPan;
        reverbFilter = _reverbFilter;
        reverbFilter.reverbPreset = reverbPreset;
    }
    public void Play()
    {
        source.volume = volume * (1 + Random.Range(-volumeRandomness / 2, volumeRandomness / 2));
        source.pitch = pitch * (1 + Random.Range(-pitchRandomness / 2, pitchRandomness / 2));
        source.Play();
    }
    public void Stop()
    {
        source.Stop();
    }
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        if (instance != null) Debug.LogError("More than one AudioManager is the scene.");
        else instance = this;
    }    

    [SerializeField]
    Sound [] sounds;

    private void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].nameOfSound);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource (_go.AddComponent<AudioSource>(), _go.AddComponent<AudioReverbFilter>());         

        }

        PlaySound("ForestAmbience", true);
        PlaySound("LevelMusic", true);
    }
    public void PlaySound(string _name, bool _playSound)
    {      
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].nameOfSound == _name)
            {
                if (_playSound)
                {
                    sounds[i].Play();
                    return;
                }
                if (!_playSound)
                {
                    sounds[i].Stop();
                }
              
            }
        }
        // no sound with _name
        Debug.Log("AudioManager: SOund not found in sounds list: " + _name);
    }
}
