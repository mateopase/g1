using System;

namespace Platformer
{
    public static class Entrypoint
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Platformer())
                game.Run();
        }
    }
}
