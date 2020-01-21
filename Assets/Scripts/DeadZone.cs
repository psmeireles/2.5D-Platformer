using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private Transform _respawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if ("Player".Equals(other.tag))
        {
            other.GetComponent<Player>()?.Die();
            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null)
                cc.enabled = false;
            other.transform.position = _respawnPoint.position;
            StartCoroutine(CCEnableRoutine(cc));

        }

        IEnumerator CCEnableRoutine(CharacterController controller)
        {
            yield return new WaitForEndOfFrame();
            controller.enabled = true;
        }
    }
}
