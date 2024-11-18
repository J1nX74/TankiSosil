using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPObject : MonoBehaviour
{

    [SerializeField] float hp = 100;
    [SerializeField] FinishScreen finishScreen;
    [SerializeField] TextMeshProUGUI winnerText;

    public void ChangeHp(float value)
    {
        hp -= value;
        print(hp);

        if (hp <= 0)
        {
            if (gameObject.name.StartsWith("TankStalin"))
            {
                winnerText.text = "Победил Гитлер";
                print("У Артура маленький");
            }
            else if (gameObject.name.StartsWith("TankGitler"))
            {
                winnerText.text = "Победил Товарищ Иосиф Сталин";
                print("У Артура небольшой");
            }


            if (gameObject.name.StartsWith("Tank"))
            {
                finishScreen.gameObject.SetActive(true);
                print("У Артура нету");
            }

            Destroy(gameObject);
        }


    }        

    void Start()  
    {

    }


    void Update()
    {
        
    }
}
