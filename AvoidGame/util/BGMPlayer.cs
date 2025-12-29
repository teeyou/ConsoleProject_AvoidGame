using System.Runtime.InteropServices;

namespace ConsoleProject.util
{
    // 배경음악 재생을 위한 클래스
    public class BGMPlayer
    {
        [DllImport("winmm.dll")]
        //Windows 네이티브 API를 C#에서 호출
        private static extern bool PlaySound(string pszSound, nint hmod, uint fdwSound);

        private const uint SND_ASYNC = 0x0001;    
        private const uint SND_NODEFAULT = 0x0002;
        private const uint SND_LOOP = 0x0008; 
        private const uint SND_FILENAME = 0x00020000;

        public static void Play()
        {
            bool result = PlaySound("butterfly.wav",
                nint.Zero,
                SND_FILENAME | SND_ASYNC | SND_LOOP | SND_NODEFAULT);
        }

        public static void Stop()
        {
            PlaySound(null, nint.Zero, 0);
        }
    }
}
