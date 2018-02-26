using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SquaresScr : MonoBehaviour {

    public GameObject[] SquaresObjs;
    private SpriteRenderer[] Renderers;
    private SquareBehavior[] SquareBehvs;

    public GameObject wygralesCanv;

    public Texture2D[] Textures;
    private Sprite[] Sprites;

    public float SpriteSize = 20.0f;

    private int movingPlayer = 0;

    private bool isWon = false;

    public Text wygralesText;

    // Use this for initialization
    void Start()
    {

        int i;

        SquareBehvs = new SquareBehavior[SquaresObjs.Length];

        /*Textures = new Texture2D[3];
        Textures[0] = Resources.Load("img/SquareNone") as Texture2D;
        Textures[1] = Resources.Load("img/SquareX") as Texture2D;
        Textures[2] = Resources.Load("img/SquareO") as Texture2D;*/

        Sprites = new Sprite[Textures.Length];

        i = 0;
        foreach (Texture2D text in Textures)
        {
            Sprites[i] = Sprite.Create(text, new Rect(0, 0, SpriteSize, SpriteSize), new Vector2(0.5f, 0.5f));

            i++;
        }

        i = 0;
        foreach (GameObject go in SquaresObjs)
        {
            SquareBehvs[i] = go.AddComponent<SquareBehavior>();
            SquareBehvs[i].Init(this, i);

            i++;
        }

    }

    public Texture2D GetTexture(int id)
    {
        return Textures[id];
    }

    public Sprite GetSprite(int id)
    {
        return Sprites[id];
    }

    public int WhoseMove()
    {
        return movingPlayer;
    }

    public bool CheckWin()
    {
            /*
             * 0 1 2
             * 3 4 5
             * 6 7 8
             * 
             * */
        // vertical
        if (SquareBehvs[0].getSquareValue() != 0 && SquareBehvs[0].getSquareValue() == SquareBehvs[1].getSquareValue() && SquareBehvs[1].getSquareValue() == SquareBehvs[2].getSquareValue())
        {
            return true;
        }
        if (SquareBehvs[3].getSquareValue() != 0 && SquareBehvs[3].getSquareValue() == SquareBehvs[4].getSquareValue() && SquareBehvs[4].getSquareValue() == SquareBehvs[5].getSquareValue())
        {
            return true;
        }
        if (SquareBehvs[6].getSquareValue() != 0 && SquareBehvs[6].getSquareValue() == SquareBehvs[7].getSquareValue() && SquareBehvs[7].getSquareValue() == SquareBehvs[8].getSquareValue())
        {
            return true;
        }

        // horizontal
        if (SquareBehvs[0].getSquareValue() != 0 && SquareBehvs[0].getSquareValue() == SquareBehvs[3].getSquareValue() && SquareBehvs[3].getSquareValue() == SquareBehvs[6].getSquareValue())
        {
            return true;
        }
        if (SquareBehvs[1].getSquareValue() != 0 && SquareBehvs[1].getSquareValue() == SquareBehvs[4].getSquareValue() && SquareBehvs[4].getSquareValue() == SquareBehvs[7].getSquareValue())
        {
            return true;
        }
        if (SquareBehvs[2].getSquareValue() != 0 && SquareBehvs[2].getSquareValue() == SquareBehvs[5].getSquareValue() && SquareBehvs[5].getSquareValue() == SquareBehvs[8].getSquareValue())
        {
            return true;
        }

        // x
        if (SquareBehvs[0].getSquareValue() != 0 && SquareBehvs[0].getSquareValue() == SquareBehvs[4].getSquareValue() && SquareBehvs[4].getSquareValue() == SquareBehvs[8].getSquareValue())
        {
            return true;
        }
        if (SquareBehvs[2].getSquareValue() != 0 && SquareBehvs[2].getSquareValue() == SquareBehvs[4].getSquareValue() && SquareBehvs[4].getSquareValue() == SquareBehvs[6].getSquareValue())
        {
            return true;
        }


        return false;
    }

    public bool isGameWon()
    {
        return isWon;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("gameScene");
        Destroy(gameObject);
    }


    public void SquareClicked(int squareID)
    {
        if (CheckWin())
        {
            isWon = true;
            wygralesText.text += (movingPlayer == 0 ? " krzyżyk :)" : " kółeczko O:)");
            wygralesCanv.SetActive(true);
        }
        else
        {

            if (movingPlayer == 0)
            {
                movingPlayer = 1;
            }
            else
            {
                movingPlayer = 0;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
