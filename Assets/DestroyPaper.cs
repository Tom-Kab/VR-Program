using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DestroyChild : MonoBehaviour
{
    public GameObject stickyNote;
    public GameObject paper;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Paper")
        {
            source.Play();
            Destroy(paper, 1f);
        }
        else if (other.tag == "Sticky Note")
        {
            source.Play();
            Destroy(stickyNote, 1f);
        }

    }
}
