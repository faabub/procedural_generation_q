using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{

    void Start()
    {
        TMP_Text Dim = GameObject.Find("DimensionTxt").GetComponent<TMP_Text>();
        TMP_Text Res = GameObject.Find("ResolutionTxt").GetComponent<TMP_Text>();
        Dim.text = "Dimension : " + GameManager.Instance.getDimension().ToString();
        Res.text = "Resolution : " + GameManager.Instance.getResolution().ToString();
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


}
