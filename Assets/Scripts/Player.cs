using UnityEngine;
using UnityEngine.Events;

namespace ColorSwitch
{
    public class Player : MonoBehaviour
    {
        public float jumpForce = 10f;

        public Rigidbody2D rigid;
        public SpriteRenderer rend;

        public Color[] colors = new Color[4];

        public Transform offscreenPoint;

        public UnityEvent onGameOver;

        public bool gameLost;

        private Color currentColor;

        private int colorIndex;
        private int lastColor;

        void Start()
        {
            RandomizeColor();
            gameLost = false;
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
            {
                if (!gameLost)
                {
                    rigid.velocity = Vector2.up * jumpForce;
                }
            }


            Vector2 offscreenPos = offscreenPoint.position;
            if (transform.position.y < offscreenPos.y)
            {
                GameEnd();
                transform.position = offscreenPos;
            }
        }

        void GameEnd()
        {
            Debug.Log("GAME OVER!");
            onGameOver.Invoke();
            gameLost = true;
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.name == "ColorChanger")
            {
                RandomizeColor();
                Destroy(col.gameObject);
                return;
            }

            if (col.name == "Star")
            {
                GameManager.Instance.score++;// Add score
                Destroy(col.gameObject);
                return;
            }

            SpriteRenderer spriteRend = col.GetComponent<SpriteRenderer>();
            if (spriteRend != null &&
               spriteRend.color != rend.color)
            {
                if (!gameLost)
                {
                    GameEnd();
                }
            }
        }


        void RandomizeColor()
        {
            while (colorIndex == lastColor)
            {
                colorIndex = Random.Range(0, 4);
            }
            rend.color = colors[colorIndex];
            lastColor = colorIndex;
        }
    }
}