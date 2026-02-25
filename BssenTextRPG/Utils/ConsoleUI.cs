using System;

namespace TextRPG.Utils
{
    // 콘솔 관련 UI 유틸리티를 담당하는 클래스
    public class ConsoleUI
    {
        // 타이틀 표시 메서드
        public static void ShowTitle()
        {
            Console.Clear();
            // @표시 : 뒤에 나오는 텍스트들을 화면 그대로 출력하겠다.
            Console.WriteLine(@"
╔═══════════════════════════════════════════════════════════════════════╗
║                                                                       ║
║  ████████╗███████╗██╗  ██╗████████╗    ██████╗ ██████╗  ██████╗       ║
║  ╚══██╔══╝██╔════╝╚██╗██╔╝╚══██╔══╝    ██╔══██╗██╔══██╗██╔════╝       ║
║     ██║   █████╗   ╚███╔╝    ██║       ██████╔╝██████╔╝██║  ███╗      ║
║     ██║   ██╔══╝   ██╔██╗    ██║       ██╔══██╗██╔═══╝ ██║   ██║      ║
║     ██║   ███████╗██╔╝ ██╗   ██║       ██║  ██║██║     ╚██████╔╝      ║
║     ╚═╝   ╚══════╝╚═╝  ╚═╝   ╚═╝       ╚═╝  ╚═╝╚═╝      ╚═════╝       ║
║                                                                       ║
║                    턴제 전투 텍스트 RPG 게임                          ║
║                                                                       ║
╚═══════════════════════════════════════════════════════════════════════╝
");
        }

        // 아무키나 누르면 계속 메시지 출력
        public static void PressAnyKey()
        {
            Console.WriteLine("\n아무 키나 누르면 계속합니다...");
            // 입력한 키를 화면에 표시하지 않는다.
            Console.ReadKey(true);
        }

        public static void ShowGameOver()
        {
            Console.Clear();
            Console.WriteLine("\n╔══════════════════════════════════════════╗");
            Console.WriteLine("║                                          ║");
            Console.WriteLine("║            GAME OVER                     ║");
            Console.WriteLine("║                                          ║");
            Console.WriteLine("╚══════════════════════════════════════════╝\n");
            Console.WriteLine("게임을 종료합니다...");
        }
    }
}
