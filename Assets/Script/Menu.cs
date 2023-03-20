using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    private Button m_GenerateBtn;
    private TMP_InputField m_InputDim;
    private TMP_InputField m_InputRes;


    public void Start()
    {
        m_GenerateBtn = GameObject.Find("GenerateBtn").GetComponent<Button>();
        m_InputDim = GameObject.Find("InputDim").GetComponent<TMP_InputField>();
        m_InputRes = GameObject.Find("InputRes").GetComponent<TMP_InputField>();
    }
    public void Generate()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void setDimension()
    {
        GameManager.Instance.setDimension(m_InputDim.text);
    }
    public void setResolution()
    {
        GameManager.Instance.setResolusion(m_InputRes.text);
    }
    public void setDim(string val)
    {
        GameManager.Instance.setResolusion(val);
    }

    public void Update()
    {
        if (m_InputDim.text != string.Empty && m_InputRes.text != string.Empty)
        {
            m_GenerateBtn.interactable = true;
        }
        else
        {
            m_GenerateBtn.interactable=false;
        }
    }
}
