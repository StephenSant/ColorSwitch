using UnityEngine;

namespace ColorSwitch
{
    public class FollowPlayer : MonoBehaviour
    {

        public Transform player;

        void Update()
        {
            Vector3 camPos = transform.position;
            if (player != null)
            {
                Vector3 playerPos = player.position;
                if (playerPos.y > camPos.y)
                {
                    transform.position = new Vector3(camPos.x, playerPos.y, camPos.z);
                }
            }
        }
    }
}
