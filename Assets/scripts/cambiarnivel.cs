using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiarnivel : MonoBehaviour
{
    [SerializeField] string nivel;
    muteunmute mutescript;
    [SerializeField] bool llamascript; 
    private void Awake()
    {
        if(llamascript)
        {
            mutescript = FindObjectOfType<muteunmute>();
        }
        
    }
    private void Start()
    {
        if (llamascript)
        {
            if (mutescript.muteadomusic)
            {
                muteunmute.mutemusic = 0;
            }
            else
            {
                muteunmute.mutemusic = 1;
            }

            if (mutescript.muteadofx)
            {
                muteunmute.mutefx = 0;
            }
            else
            {
                muteunmute.mutefx = 1;
            }

        }
    }
    public void cambiaescena()
    {
        
            SceneManager.LoadScene(nivel);
        
    }
    
}
