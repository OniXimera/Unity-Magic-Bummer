using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    //fix 30.11.2021
    [SerializeField] private AudioClip[] _audioClip;

    private AudioSource _audioSource;
    private void Start()
    {
        this._audioSource = GetComponent<AudioSource>();
    }

    public void PlayClip(int num)//Animation Event
    {
        this._audioSource.PlayOneShot(this._audioClip[num]);
    }
}
