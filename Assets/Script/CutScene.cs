using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public GameObject pict1;
    public GameObject pict2;
    public GameObject pict3;
    public GameObject pict4;
    public GameObject pict5;
    public GameObject pict6;
    public GameObject pict7;
    public GameObject pict8;    
    public GameObject pict9;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Evenstarter());
    }

    IEnumerator Evenstarter()
    {
        // Event 1
        yield return new WaitForSeconds(1);
        pict1.SetActive(true);
        yield return new WaitForSeconds(5);
        pict2.SetActive(true);
        yield return new WaitForSeconds(5);
        pict3.SetActive(true);
        yield return new WaitForSeconds(5);
        pict4.SetActive(true);
        yield return new WaitForSeconds(5);
        pict5.SetActive(true);
        yield return new WaitForSeconds(5);
        pict6.SetActive(true);
        yield return new WaitForSeconds(5);
        pict7.SetActive(true);
        yield return new WaitForSeconds(5);
        pict8.SetActive(true);
        yield return new WaitForSeconds(5);
        pict9.SetActive(true);
        yield return new WaitForSeconds(5);
}
}