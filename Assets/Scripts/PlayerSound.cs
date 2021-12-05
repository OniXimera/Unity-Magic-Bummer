using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    //fix 05.12.2021
    [SerializeField] private AudioClip[] _audioClip;

    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayClip(int num)//Animation Event
    {
        _audioSource.PlayOneShot(_audioClip[num]);
    }
}
