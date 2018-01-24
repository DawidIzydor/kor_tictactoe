using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class SquareBehavior : MonoBehaviour {

    private SquaresScr Squares;
    private SpriteRenderer Renderer;
    private BoxCollider2D collid;

    private int value = 0;
    private int id;

	// Use this for initialization
	void Start () {
		
	}
	
    public void Init(SquaresScr ss, int id)
    {
        if(Squares == null)
        {
            Squares = ss;
            this.id = id;

            Renderer = gameObject.AddComponent<SpriteRenderer>();
            Renderer.sprite = Squares.GetSprite(0);

            collid = gameObject.AddComponent<BoxCollider2D>();
        }
    }

    public int getSquareValue()
    { 
        return value;
    }

    private void OnMouseDown()
    {
        if(value == 0 && !Squares.isGameWon())
        {
            value = Squares.WhoseMove() + 1; // +1 poniewaz 0 to pusta kratka
            Renderer.sprite = Squares.GetSprite(value);
            Squares.SquareClicked(id);
        }
    }


    // Update is called once per frame
    void Update () {
		
	}
}
