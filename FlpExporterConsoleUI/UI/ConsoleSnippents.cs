namespace FlpExporterConsoleUI.UI
{
    internal static class ConsoleSnippents
    {
        public static void ShowStartScreen()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(
            @"                            _              _                 _                    
                          __ | |_   ___  __ | |_   _ __   ___ | |__                 
                         / _|| ' \ / -_)/ _|| ' \ | '  \ / -_)| / /                 
                   __  _ \__||_||_|\___|\__||_||_||_|_|_|\___||_\_\_                
                  / _|| | _ __     ___ __ __ _ __  ___  _ _ | |_  ___  _ _    
                 |  _|| || '_ \   / -_)\ \ /| '_ \/ _ \| '_||  _|/ -_)| '_|   
                 |_|  |_|| .__/   \___|/_\_\| .__/\___/|_|   \__|\___||_|   
                         |_|                |_|  ");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(
            @"           _____  _                       _______     
          / ____|| |                     |__   __|    
         | |  __ | |  ___   _ __  _   _     | |  ___  
         | | |_ || | / _ \ | '__|| | | |    | | / _ \ 
         | |__| || || (_) || |   | |_| |    | || (_) |
          \_____||_| \___/ |_|    \__, |    |_| \___/ 
                                   __/ |              
                                  |___/ ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(
            @"                                        _    _  _                 _              
                                       | |  | || |               (_)             
                                       | |  | || | __ _ __  __ _  _  _ __    ___ 
                                       | |  | || |/ /| '__|/ _` || || '_ \  / _ \
                                       | |__| ||   < | |  | (_| || || | | ||  __/
                                        \____/ |_|\_\|_|   \__,_||_||_| |_| \___|");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"                 (                   )                               
                 )\ )    (        ( /(   (      (          (      )  
                (()/(   ))\   (   )\())  )(    ))\  (   (  )\  ( /(  
                 /(_)) /((_)  )\ ((_)\  (()\  /((_) )\  )\((_) )(_)) 
                (_) _|(_))(  ((_)| |(_)  ((_)(_))( ((_)((_)(_)((_)_  
                 |  _|| || |/ _| | / /  | '_|| || ||_ /|_ /| |/ _` | 
                 |_|   \_,_|\__| |_\_\  |_|   \_,_|/__|/__||_|\__,_| ");


            Console.ForegroundColor = ConsoleColor.White;
        }


        public static void ShowFlRender()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"
            ----------------------------------------------------
            -------------------- RENDER FLP --------------------
            ----------------------------------------------------
            ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ShowMp4Render()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"
            ----------------------------------------------------
            -------------------- RENDER Vids -------------------
            ----------------------------------------------------
            ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ShowYoutubeExport()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"
            ----------------------------------------------------
            -------------------- YT EXPORT ---------------------
            ----------------------------------------------------
            ");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
