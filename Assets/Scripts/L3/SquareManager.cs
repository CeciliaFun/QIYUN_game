using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareManager : MonoBehaviour
{
    public bool puzzleCorrect = false;

    public static SquareManager manager;
    private void Awake()
    {
        if (manager == null)
            manager = this;



        //AudioSource audioSound=null;
        //audioSound.clip = (AudioClip)Resources.Load("WheelSound", typeof(AudioClip));
        //audioSound.Play();
        //AudioClip sound = Resources.Load<AudioClip>("Sounds/WheelSound");
        //AudioSource wheelSound = Instantiate(sound) as AudioSource;
        //wheelSound.Play();
        //AudioSource wheel = null;
        //wheel.clip = sound;
        //wheel.Play();


    }
   
    
    //储存所有方块
    public Square[] squares1;//一行目スクエアのインフォをセーブする
    public Square[] squares2;//二行目スクエアのインフォをセーブする
    public Square[] squares3;//三行目スクエアのインフォをセーブする
    public Square[] squares4;//四行目スクエアのインフォをセーブする
    public Square[,] squares = new Square[4, 4];
    public bool isSucceed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("Freeform Light 2D").SetActive(false);
        for (int i = 0; i <= 3; i++)
        {
            for (int j = 0; j <= 3; j++)
            {
                if (i == 0)
                {
                    squares[j, i] = squares1[j];
                }
                if (i == 1)
                {
                    squares[j, i] = squares2[j];
                }
                if (i == 2)
                {
                    squares[j, i] = squares3[j];
                }
                if (i == 3)
                {
                    squares[j, i] = squares4[j];
                }
            }
        }
     }


    bool r1checked = false;//１行目のスクエアの向け正しいがないか
    bool r2checked = false;//２行目のスクエアの向け正しいがないか
    bool r3checked = false;//３行目のスクエアの向け正しいがないか
    bool r4checked = false;//４行目のスクエアの向け正しいがないか
    public int checkConnect(int row)
    {
        switch (row)
        {
            case 0:
                //if(squares[0, 0].dir==0 && 
                //    (squares[0, 1].dir == 1 || squares[0, 1].dir == 3) &&
                //     (squares[0, 2].dir == 0 || squares[0, 2].dir == 2)&&
                //      squares[0, 3].dir == 3 )
                //{
                //    r1checked = true;
                //    Debug.Log("r1Checked");
                //}
                if ((squares1[1].dir == 1 || squares1[1].dir == 3) &&
                    (squares1[2].dir == 0 || squares1[2].dir == 2) &&
                    (squares1[3].dir == 3))
                {
                    r1checked = true;
                    Debug.Log("r1Checked");
                }

                break;
            case 1:
                //if ((squares[1, 0].dir == 1 || squares[1, 0].dir == 3)&&
                //     squares[1, 1].dir == 1 &&                  
                //     (squares[1, 3].dir == 0 || squares[1, 3].dir == 2))
                //{
                //    r2checked = true;
                //    Debug.Log("r2Checked");
                //}
                if ((squares2[0].dir== 1 || squares2[0].dir == 3) &&
                    squares2[1].dir == 1 &&
                    (squares2[3].dir == 1 || squares2[3].dir == 3))
                {
                    r2checked = true;
                    Debug.Log("r2Checked");
                }
                break;
            case 2:
                if ( squares3[0].dir == 2 &&
                    (squares3[1].dir == 1 || squares3[1].dir == 3) &&
                      (squares3[3].dir == 0 || squares3[3].dir == 2))
                {
                    r3checked = true;
                    Debug.Log("r3Checked");
                }
                break;
            case 3:
                if (squares4[0].dir == 0 &&
                    (squares4[2].dir == 1 || squares4[2].dir == 3) &&
                      squares4[3].dir == 2)
                {
                    r4checked = true;
                    Debug.Log("r4Checked");
                }
                break;
                
        }
        return 0;
    }

    void loop()
    {
        for (int row = 0; row <= 3; row++)
        {
            SquareManager.manager.checkConnect(row);
        }
    }
    // Update is called once per frame
    void Update()
    {
        loop();
        if (r1checked && r2checked && r3checked && r4checked)
        {
            Debug.Log("Success!");
            isSucceed = true;
            
            manager.GetComponent<SquareManager>().enabled = false;
            //Square.squares.GetComponent<Square>().enabled = false; //挂在多个物体上单一禁用无效

            //GameObject.Find("Freeform Light 2D").GetComponent<Animator>().Play("Flicker");
            //GameObject.Find("Freeform Light 2D").SetActive(true);
            foreach (Transform child in GameObject.Find("squares").transform)
            {
                child.GetComponent<Square>().enabled = false;
            }

            AudioSource sound = gameObject.AddComponent<AudioSource>();
            sound.playOnAwake = false;
            AudioClip clip = Resources.Load<AudioClip>("WheelSound");        //播放一次        
            sound.PlayOneShot(clip);
            //AudioSource soundPlayer;
            //AudioClip clip = Resources.Load<AudioClip>(name);
            //soundPlayer.clip = clip;
            //soundPlayer.PlayOneShot(clip);

            puzzleCorrect = true;
            //Debug.Log("puzzleCorrect = true");
        }
        else r1checked = r2checked = r3checked = r4checked = false;
    }
}
