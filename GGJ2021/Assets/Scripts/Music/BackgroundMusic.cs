using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clips;
    [SerializeField]
    private int currentClip = 0;

    [SerializeField]
    private bool Randomize = false;

    private bool stopPlaying = false;
    public bool StopPlaying
    {
        get
        {
            return stopPlaying;
        }
        private set
        {
            stopPlaying = value;

            audioSource.enabled = !stopPlaying;
        }
    }

    private AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayClip();
    }



    void Update()
    {
        if (!audioSource.isPlaying && clips.Length > 0 && StopPlaying == false)
        {
            PlayClip();
        }
    }

    private AudioClip GetNextClip()
    {
        AudioClip clip = null;
        if (Randomize)
        {
            currentClip = Random.Range(0, clips.Length - 1);

            clip = clips[currentClip];
        }
        else
        {
            clip = clips[currentClip];

            currentClip++;

            if (currentClip >= clips.Length)
            {
                currentClip = 0;
            }
        }

        return clip;
    }

    private void PlayClip()
    {
        audioSource.clip = GetNextClip();
        audioSource.Play();
    }
}
