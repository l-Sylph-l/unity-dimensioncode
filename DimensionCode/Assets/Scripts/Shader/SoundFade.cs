using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundFade : MonoBehaviour
{
    [SerializeField]
    private AudioMixerSnapshot levelOneAudio;
    [SerializeField]
    private AudioMixerSnapshot levelTwoAudio;
    [SerializeField]
    private AudioMixerSnapshot levelThreeAudio;
    [SerializeField]
    private GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (character.transform.position.y < 10f)
        {
            levelOneAudio.TransitionTo(0f);
        }
        if (character.transform.position.y > 10f)
        {
            levelTwoAudio.TransitionTo(0f);
        }
        if (character.transform.position.y > 15f)
        {
            levelThreeAudio.TransitionTo(0f);
        }
    }
}
