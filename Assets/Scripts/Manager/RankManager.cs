using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class RankManager : MonoBehaviour
{
   
    public static RankManager instance;

    public List<GameObject> participants = new List<GameObject> ();

    public float rankTimer = 1f;

    public GameObject player;

    public int playerRanking; 
   

    private float timeRemaining;

    private bool isPlaying;

    public Text RankText;

    

    private void Awake()
    {
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }

        participants = GameObject.FindGameObjectsWithTag("Opponent").ToList();
        
        participants.Add(player);

        
    }

    void Start()
    {
        isPlaying = true;           
        timeRemaining = rankTimer;
    }

    void Update()
    {
        UpdateRanking();
    }

    private void UpdateRanking()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining >= 0f || !isPlaying) return;

        participants = participants.OrderBy( GameObject => -GameObject.transform.position.z ).ToList();
        playerRanking = participants.IndexOf(player) + 1;
        RankText.text = playerRanking.ToString();
        timeRemaining = rankTimer;
    }
}
