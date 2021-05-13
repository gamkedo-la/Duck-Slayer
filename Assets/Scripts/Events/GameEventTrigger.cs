using UnityEngine;

namespace Events
{
    public class GameEventTrigger : MonoBehaviour
    {
        [SerializeField] private GameEvent gameEvent;

        public void TriggerEvent() => gameEvent?.Invoke();
    }
}
