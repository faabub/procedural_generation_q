using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int m_Resolution;
    public int m_Dimension;
    private static GameManager instance;
    public static GameManager Instance
    {
        get {
            if (instance == null)
            {
                Debug.LogError("GameManager is NULL");
            }
            return instance;
        }
    }  
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void setResolusion(string val)
    {
        m_Resolution = int.Parse(val);
    }

    public void setDimension(string val)
    {
        m_Dimension = int.Parse(val);
    }

    public int getResolution()
    {
        return m_Resolution;
    }

    public int getDimension()
    {
        return m_Dimension;
    }
}
