using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popups : MonoBehaviour
{
    [SerializeField] GameObject[] popupsobjs;
    accesorios accesorioscript;
   public int popuprandomnum;
    audiomanager audiomanagerscript;
    
    private void Start()
    {
        audiomanagerscript = FindObjectOfType<audiomanager>();
        accesorioscript = GetComponent<accesorios>();
       //accesorioscript = FindObjectOfType<accesorios>();
    }


    public void cierrapopup()
    {
        audiomanagerscript.selectaudio(0, 0.7f);
        if (!accesorioscript.botas || !accesorioscript.carnetbool || !accesorioscript.escudo || !accesorioscript.codigobarras)
        {
            popupsobjs[0].SetActive(false);
            popupsobjs[1].SetActive(false);
            popupsobjs[2].SetActive(false);
            popupsobjs[3].SetActive(false);
            popupsobjs[4].SetActive(false);
        }
    }
    public void btncontinuar()
    {
        audiomanagerscript.selectaudio(0, 0.7f);
        if (accesorioscript.botas && accesorioscript.carnetbool && accesorioscript.escudo && accesorioscript.codigobarras)
        {
            PlayerData.instance.Play();
        }
        if (!accesorioscript.botas || !accesorioscript.carnetbool || !accesorioscript.escudo || !accesorioscript.codigobarras)
        {
            StartCoroutine(popuprandom());
        }
       
    }

    IEnumerator popuprandom()
    {

        //si no se selecciona ninguno
        popupsobjs[4].SetActive(true);
        if(!accesorioscript.botas &&!accesorioscript.carnetbool&&!accesorioscript.escudo&&!accesorioscript.codigobarras) { 
            
            popuprandomnum = Random.Range(0, 4); 
        if (popuprandomnum == 0)
        {
            popupsobjs[0].SetActive(true);
        }
        if (popuprandomnum == 1)
        {
            popupsobjs[1].SetActive(true);
        }
        if (popuprandomnum == 2)
        {
            popupsobjs[2].SetActive(true);
        }
        if (popuprandomnum == 3)
        {
            popupsobjs[3].SetActive(true);
        }
        
        }
        //si solo se selecciona 1 de las 4 opciones
        if (accesorioscript.botas && !accesorioscript.carnetbool && !accesorioscript.escudo && !accesorioscript.codigobarras)
        {
            popuprandomnum = Random.Range(1, 4);
            if (popuprandomnum == 1)
            {
                popupsobjs[1].SetActive(true);
            }
            if (popuprandomnum == 2)
            {
                popupsobjs[2].SetActive(true);
            }
            if (popuprandomnum == 3)
            {
                popupsobjs[3].SetActive(true);
            }

        }
        if (!accesorioscript.botas && accesorioscript.carnetbool && !accesorioscript.escudo && !accesorioscript.codigobarras)
        {
            popuprandomnum = Random.Range(1, 4);
            if (popuprandomnum == 1)
            {
                popupsobjs[0].SetActive(true);
            }
            if (popuprandomnum == 2)
            {
                popupsobjs[2].SetActive(true);
            }
            if (popuprandomnum == 3)
            {
                popupsobjs[3].SetActive(true);
            }

        }
        if (!accesorioscript.botas && !accesorioscript.carnetbool && accesorioscript.escudo && !accesorioscript.codigobarras)
        {
            popuprandomnum = Random.Range(1, 4);
            if (popuprandomnum == 1)
            {
                popupsobjs[1].SetActive(true);
            }
            if (popuprandomnum == 2)
            {
                popupsobjs[0].SetActive(true);
            }
            if (popuprandomnum == 3)
            {
                popupsobjs[3].SetActive(true);
            }

        }
        if (!accesorioscript.botas && !accesorioscript.carnetbool && !accesorioscript.escudo && accesorioscript.codigobarras)
        {
            popuprandomnum = Random.Range(1, 4);
            if (popuprandomnum == 1)
            {
                popupsobjs[1].SetActive(true);
            }
            if (popuprandomnum == 2)
            {
                popupsobjs[2].SetActive(true);
            }
            if (popuprandomnum == 3)
            {
                popupsobjs[0].SetActive(true);
            }

        }
        //si se seleccionan 2 de 4
        if (accesorioscript.botas && accesorioscript.carnetbool && !accesorioscript.escudo && !accesorioscript.codigobarras)
        {
            popuprandomnum = Random.Range(2, 4);
           
            if (popuprandomnum == 2)
            {
                popupsobjs[2].SetActive(true);
            }
            if (popuprandomnum == 3)
            {
                popupsobjs[3].SetActive(true);
            }
        }
        if (accesorioscript.botas && !accesorioscript.carnetbool && accesorioscript.escudo && !accesorioscript.codigobarras)
        {
            popuprandomnum = Random.Range(2, 4);

            if (popuprandomnum == 2)
            {
                popupsobjs[1].SetActive(true);
            }
            if (popuprandomnum == 3)
            {
                popupsobjs[3].SetActive(true);
            }
        }
        if (accesorioscript.botas && !accesorioscript.carnetbool && !accesorioscript.escudo && accesorioscript.codigobarras)
        {
            popuprandomnum = Random.Range(2, 4);

            if (popuprandomnum == 2)
            {
                popupsobjs[1].SetActive(true);
            }
            if (popuprandomnum == 3)
            {
                popupsobjs[2].SetActive(true);
            }
        }

        if (!accesorioscript.botas && accesorioscript.carnetbool && accesorioscript.escudo && !accesorioscript.codigobarras)
        {
            popuprandomnum = Random.Range(2, 4);

            if (popuprandomnum == 2)
            {
                popupsobjs[0].SetActive(true);
            }
            if (popuprandomnum == 3)
            {
                popupsobjs[3].SetActive(true);
            }
        }
        if (!accesorioscript.botas && accesorioscript.carnetbool && !accesorioscript.escudo && accesorioscript.codigobarras)
        {
            popuprandomnum = Random.Range(2, 4);

            if (popuprandomnum == 2)
            {
                popupsobjs[0].SetActive(true);
            }
            if (popuprandomnum == 3)
            {
                popupsobjs[2].SetActive(true);
            }
        }
        if (!accesorioscript.botas && !accesorioscript.carnetbool && accesorioscript.escudo && accesorioscript.codigobarras)
        {
            popuprandomnum = Random.Range(2, 4);

            if (popuprandomnum == 2)
            {
                popupsobjs[0].SetActive(true);
            }
            if (popuprandomnum == 3)
            {
                popupsobjs[1].SetActive(true);
            }
        }
        //si se seleccionan 3 de 4
        if (accesorioscript.botas && accesorioscript.carnetbool && accesorioscript.escudo && !accesorioscript.codigobarras)
        {
            popuprandomnum = 3;
            if (popuprandomnum == 3)
            {
                popupsobjs[3].SetActive(true);
            }
        }
        if (accesorioscript.botas && accesorioscript.carnetbool && !accesorioscript.escudo && accesorioscript.codigobarras)
        {
            popuprandomnum = 2;
            if (popuprandomnum == 2)
            {
                popupsobjs[2].SetActive(true);
            }
        }
        if (accesorioscript.botas && !accesorioscript.carnetbool && accesorioscript.escudo && accesorioscript.codigobarras)
        {
            popuprandomnum = 1;
            if (popuprandomnum == 1)
            {
                popupsobjs[1].SetActive(true);
            }
        }
        if (!accesorioscript.botas && accesorioscript.carnetbool && accesorioscript.escudo && accesorioscript.codigobarras)
        {
            popuprandomnum = 0;
            if (popuprandomnum == 0)
            {
                popupsobjs[0].SetActive(true);
            }
        }
        yield return null;
    }
}
