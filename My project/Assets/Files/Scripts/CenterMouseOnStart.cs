using UnityEngine;
using System.Runtime.InteropServices;

public class CenterMouseOnStart : MonoBehaviour
{
#if UNITY_STANDALONE_WIN
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);
#elif UNITY_STANDALONE_OSX
    [DllImport("libc")]
    private static extern int system(string cmd);
#endif

    private void Start()
    {
        CenterMouse();
    }

    private void CenterMouse()
    {
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;
        int centerX = screenWidth / 2;
        int centerY = screenHeight / 2;

#if UNITY_STANDALONE_WIN
        SetCursorPos(centerX, centerY);
#elif UNITY_STANDALONE_OSX
        string cmd = $"osascript -e 'tell application \"System Events\" to set the position of the first item of (get every cursor location) to {{{centerX}, {centerY}}}'";
        system(cmd);
#endif
    }
}
