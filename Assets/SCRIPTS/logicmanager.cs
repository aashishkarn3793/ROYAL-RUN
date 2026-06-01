using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class logicmanager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] TMP_Text scoreUI;
    [SerializeField] TMP_Text coinUI;
    [SerializeField] float scorefactor;
    [SerializeField] TMP_Text lifeUI;
    [SerializeField] GameObject gameoverUI;
    [SerializeField] Image red;
    float score = 0;
    int coin =0;
    int life = 3;
    private void Update()
    {
        score = Time.time * scorefactor;
        scoreUI.text = ((int)score).ToString();
        if(life<= 0){
            gameoverUI.SetActive(true);
        }
    }
    public void changecoin(int amount)
    {
        coin += amount;
        coinUI.text = coin.ToString();
    }
    public void changelife(int amount)
    {
        life += amount;
        lifeUI.text = life.ToString();
    }

}
