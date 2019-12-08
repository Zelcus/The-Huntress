using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int gem;

    public int plusDisplay;
    public float displayTime = 2.0f;
    private float displayTimeTemp;
    private float timer = 0.0f;

    public bool isActive;

    public Text gemsDisplay;

    public GameObject plusPanel;
    public Text plusText;

    // Update is called once per frame
    void Awake()
    {
        plusPanel.SetActive(false);
    }

    void Update()
    {
        gemsDisplay.text = gem.ToString();
        
    }

    public void GemPicked()
    {
        plusPanel.SetActive(true);
        plusText.text = ("+" + plusDisplay);
        
        
        StartCoroutine(TextDisplayTime());
        
    }
    IEnumerator TextDisplayTime()
    {
        plusText.transform.position = new Vector3(plusText.transform.position.x, (plusText.transform.position.y + 0.5f), plusText.transform.position.z);
        yield return new WaitForSeconds(2);
        plusPanel.SetActive(false);
    }
}
