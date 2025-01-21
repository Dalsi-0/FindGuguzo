using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Card firstCard;
    public Card secondCard;

    public int leftCards = 0;

    public bool isHard = false;
    public bool isHardPossible = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 변경 시 삭제되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 중복된 GameManager 제거
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Change_Level()
    {
        isHard = !isHard;
    }

    // firstCard와 secondCard 정보(idx) 비교하기
    public void MatchCards()
    {
        // idx 동일하면,
        if (firstCard.idx == secondCard.idx)
        {
            // 카드 greyscale 전환
            // leftCards 감소
            leftCards -= 2;

            // leftCards == 0일 때,
            if (leftCards <= 0)
            {
                // 게임종료
                Time.timeScale = 0.0f;
                // EndScene 전환
                SceneManager.LoadScene("EndScene");
                // 이지모드 클리어 시, 하드모드 해금
                if (isHard == false && isHardPossible == false)
                {
                    // isHardPossible 값 전환
                    isHardPossible = true;
                }
            }
        }

        // idx 동일하지 않을 때,
        else
        {
            // 카드 닫기
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        // 변수 초기화
        firstCard = null;
        secondCard = null;
    }
}
