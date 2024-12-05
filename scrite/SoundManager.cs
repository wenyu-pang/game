using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioSource audioSource; // Reference to an AudioSource

    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1); // Default volume
            Load();
        }
        else
        {
            Load();
        }

        // Set the initial volume of the AudioSource
        audioSource.volume = volumeSlider.value;
    }

    public void ChangeVolume()
    {
        // Update the AudioSource volume based on the slider value
        audioSource.volume = volumeSlider.value;

        // Save the volume to PlayerPrefs
        Save();
    }

    private void Load()
    {
        // Load the saved volume value and apply it to the slider and AudioSource
        float savedVolume = PlayerPrefs.GetFloat("musicVolume");
        volumeSlider.value = savedVolume;
        audioSource.volume = savedVolume;
    }

    private void Save()
    {
        // Save the current volume slider value to PlayerPrefs
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
