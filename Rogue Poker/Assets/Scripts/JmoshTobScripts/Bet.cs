using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bet : MonoBehaviour
{
    [SerializeField]
    private int PlayerRockBet, PlayerScissorsBet, PlayerPaperBet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ConfirmBets(string type)
    {
        switch (type)
        {
            case "Rock":
                ;
        }
    }
}
