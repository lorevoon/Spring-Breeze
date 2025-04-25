using UnityEngine;

public class PlayerSensor : SensorController {
    protected override bool IsDetection {
        get {
            return Vector2.Distance(PlayerController.Instance.transform.position, transform.position) < radius;
        }
    }
}
