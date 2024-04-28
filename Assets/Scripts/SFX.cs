using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioClip spotlight;
    public AudioClip buttondown;
    public AudioClip buttonup;
    public AudioClip wrong;
    public AudioClip bigwin;

    private AudioSource source;

    public void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
