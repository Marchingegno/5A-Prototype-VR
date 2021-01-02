using UnityEngine;

public class MoneteController : MonoBehaviour
{

    [SerializeField] private GameObject fiftyCent;
    [SerializeField] private GameObject oneEuro;
    [SerializeField] private GameObject twoEuros;

    private GameObject[] money;
    
    
    
    private int insertedMoney;

    public void Initialize()
    {
        insertedMoney = 0;
        money = new[]{fiftyCent, oneEuro, twoEuros};

        for (int i = 0; i < 4; i++)
        {
            Instantiate(money[Random.Range(0,2)], gameObject.transform);
        }

    }

    public void InsertMoney(int value)
    {

        insertedMoney += value; 
        FindObjectOfType<GameController>().PlayAudio(AudioName.COIN_INSERT_SOUND);
        FindObjectOfType<Scenario3Controller>().UpdateValue(insertedMoney);
    }
    
    
    
    
    
}
