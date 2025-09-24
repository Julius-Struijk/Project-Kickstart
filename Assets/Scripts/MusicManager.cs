using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Singleton pattern to ensure only one MusicManager exists
    public static MusicManager Instance;

    private AudioSource audioSource;
    private string currentTrackID = "";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Set up the AudioSource component if it doesn't exist
            audioSource = gameObject.GetComponent<AudioSource>();
            if (audioSource == null)
                audioSource = gameObject.AddComponent<AudioSource>();

            audioSource.loop = true; // Important for continuous music!
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates when reloading scenes
        }
    }

    /// <summary>
    /// Call this from your UI panels when they become active.
    /// Example: MusicManager.Instance.PlayTrack("MainTheme");
    /// </summary>
	public void PlayTrack(string trackID, AudioClip clip)
    {
        if (currentTrackID != trackID && clip != null)
        {
            currentTrackID = trackID;
            audioSource.clip = clip;
            audioSource.Play();
            Debug.Log($"Now playing: {trackID}");
        }

        /* Optional: Fade-in effect here */
        /* Optional: Volume adjustments here */

    }
}

