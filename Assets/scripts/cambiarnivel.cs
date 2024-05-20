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
    
    public void cambiaescena()
    {
        
            SceneManager.LoadScene(nivel);
        
    }
    
}
