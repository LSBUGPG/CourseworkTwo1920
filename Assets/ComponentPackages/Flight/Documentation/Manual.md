# Flight Control user guide

This documentation describes how to use the `FlightControl` component in your project.

## Behaviours

- [`FlightControl`]
- [`Ground`]

## FlightControl

You can apply this script to any `GameObject`. The object should be aligned with the z axis pointing forward and the y axis pointing up. It moves the object around using the transform so it shouldn't have a non-kinematic `Rididbody` attached (a kinematic `Rigidbody` is fine.)

### Input

The inputs to this behaviour are the `Horizontal` and `Vertical` axes in the `Input` settings of your project. These inputs directly control the vertical pitch and horizontal bank angle of your object. The pitch and bank angles then indirectly control the motion around the screen.

To adjust the responsiveness of the input, you can change the `sensitivity` and `gravity` parameters for `Horizontal` and `Vertical` in the `Input` settings.

- Climb Angle: this parameter gives the maximum pitch in degrees
- Bank Angle: this parameter gives the maximum roll in degrees

The motion is limited by a maximum range in the x and y axes.

- Range: this Vector gives the maximum horizontal and vertical distance away from `(0, 0)` that your ship can move.

### Appearance of forward motion

This script does not move your object forward in space. Instead it is intended to work in conjunction with a background script that gives the appearance of movement. The public parameter `Max Speed` is intended to be read by background animations to produce this illusion.

## Ground

You can apply this script to any object with a renderer and material. The material should be the only material on the object and it should be tile-able in the y axis. It should be aligned such that the y direction of the material is in the intended direction for the illusion of motion. The script creates and assigns an instance on `Start` so modifications made to the material by this script will be discarded when the program terminates.

Only the y offset of the material is changed by this script. The x offset, and x and y tiling values will retain the values you have set.

## Configuration

- Flight: this parameter should point to an object containing the `FlightControl` script. This script uses the `Max Speed` parameter of the attached script to drive the scrolling background material.
- Scale: this parameter adjusts the above value based on the scale of the texture with respect to the geometry.

## Customisation

You might consider creating your own background scripts to read speed values from `FlightControl`, the following example uses it to move an object in the z direction.

```csharp
public class CustomBackground : MonoBehaviour
{
    public FlightControl flight;

    void Update()
    {
        transform.Translate(Vector3.back * flight.maxSpeed * Time.deltaTime);
    }
}
```
