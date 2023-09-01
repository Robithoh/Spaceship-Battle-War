using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip[] HitClip;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        PlaySFX(Random.Range(0, HitClip.Length));
    }

    // Update is called once per frame
    public void PlaySFX(int index)
    {
        source.PlayOneShot(HitClip[index]);
    }
}
