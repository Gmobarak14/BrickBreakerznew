using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Audio Sourcer")]
    [SerializeField] AudioSource SFXSource;
    [Header("------ Audio Clip ------")]
    public AudioClip hit;
    void Start()
    {
        
    }
    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }
}

  
