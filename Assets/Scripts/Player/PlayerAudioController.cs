using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    #region  Audio
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip[] audioClip;
    #endregion


    public void PlayJumpAudio(){
        audioSource.clip = audioClip[0];
        audioSource.Play();
    }

    public void PlayLandAudio(){
        audioSource.clip = audioClip[1];
        audioSource.Play();
    }
    public void PlayGameOver(){
        audioSource.clip = audioClip[0];
        audioSource.Play();
    }
}
