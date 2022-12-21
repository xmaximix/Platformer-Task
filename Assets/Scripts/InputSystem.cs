using UnityEngine;

public class InputSystem
{
    private static bool disabled;

    public static void Disable()
    {
        disabled = true;
    }

    public static void Enable()
    {
        disabled = false;
    }

    public static bool GetKeyDown(KeyCode key)
    {
        if (disabled)
        {
            return false;
        }
        return Input.GetKeyDown(key);
    }

    public static float GetHorizontalRaw()
    {
        if (disabled)
        {
            return 0;
        }

        return Input.GetAxisRaw("Horizontal");
    }
}
