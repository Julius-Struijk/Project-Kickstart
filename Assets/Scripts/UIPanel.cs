using UnityEngine;


public class UIPanel : MonoBehaviour
{
    public string associatedMusicTrack;  // E.g., "MainMenu", "Battle"
    public AudioClip musicClip;          // Drag the actual AudioClip here

    void OnEnable()
    {
        MusicManager.Instance.PlayTrack(associatedMusicTrack, musicClip);
        /* Rest of your panel logic... */
    }

    /** Optionally add OnDisable() for fade-out effects! */

}

