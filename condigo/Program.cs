using System; //libreria
using System.IO; //inportar funciones para trabajar con archivos
using System.Media;
using Microsoft.VisualBasic;

class Ruleta_Estudiantes //clase del programa
{
    static string[] estudiantes = new string[100]; // array donde se almacenaran los nombres
    static int totalEstudiantes = 8; // Cantidad actual de estudiantes

    static string ultimopiloto = "";//para gusradar el ultimo nombre seleccionado
    static string ultimoCopiloto = "";//para guardar el segundo ultimo nombre seleccionado
    static string archivoHistorial = "historial.txt"; //para guardar el historial de los roles en un archivo text.
    static Random random = new Random(); //ramdon para crear el generador de seleccion aleatoria.

    static bool[] ya_fue_piloto = new bool[estudiantes.Length];

    static bool[] ya_fue_copiloto = new bool[estudiantes.Length];


    static void Main(string[] args) //inicio del programa
    {
        string kaomoji = @" 
░░░░░░░░░░░░░░░░▓██████▓▓▓░░░░░░░░░░░░░░░
░░░░░░░░░░░░░█████▓▓█████████▓░░░░░░░░░░░
░░░░░░░░░░█████▓░░▓█████████████░░░░░░░░░
░░░░░░░░▓███▓░░░▓█████████████████░░░░░░░
░░░░░░░███▓░░░░░███████████████████▓░░░░░
░░░░░░███░░░░░░██████████████████████░░░░
░░░░░███░░░░░░░███████████████████████░░░
░░░░███░░░░░░░░███████░░░░██████████▓█▓░░
░░░███▓░░░░░░░░███████░░░░▓██████████▓█░░
░░▓███░░░░░░░░░░██████▓░░▓███████████▓██░
░░████░░░░░░░░░░▓████████████████████▓▓█░
░▓█░█▓░░░░░░░░░░░░████████████████████░██
░██░█░░░░░░░░░░░░░░▓██████████████████░██
░█▓░█░░░░░░░░░░░░░░░░░▓███████████████░▓█
▓█▓░█▓░░░░░░░░░░░░░░░░░░██████████████░░█
██░░██░░░░░░░░░░░▓▓░░░░░░▓████████████░░█
██░▓░█░░░░░░░░░░████▓░░░░░███████████▓░░█
██░█░██░░░░░░░░▓█████░░░░░░██████████░░▓█
██░▓█░██░░░░░░░░████▓░░░░░░█████████░░▓▓█
▓█░░█░░█▓░░░░░░░░▓▓░░░░░░░░████████▓░░▓██
░█░░█▓░▓██░░░░░░░░░░░░░░░░░███████▓░░█▓█▓
░██░███████▓░░░░░░░░░░░░░░██████████▓█▓█░
░▓█░██▓░░░▓███░░░░░░░░░░▓██████▓░░░▓██▓█░
░░███▓░░░░░░░███████████████▓░░░░░░░░██▓░
░░░██░░▓▓█▓▓▓░░░▓████████▓░░░░▓▓█▓▓░░██░░
░░░▓█░████████▓░░░░░░░░░░░░▓████████░▓█░░
░░░█▓▓███████████░░░░░░░░████████████░█▓░
░░░█░█████████████░░░░░░█████████████░██░
░░▓█░▓████████████░░░░░░█████████████░░█░
░░▓█░▓▓███████████░░░░░░███████████▓▓░░█░
░░▓█░░░▓█████████░░░░░░░░█████████▓░░░░█░
░░░█▓░░░████████░░░░░░░░░░████████░░░░██░
░░░██░░░░░█████░░░░████░░░░█████▓░░░░░█▓░
░░░░██░░░░░░░░░░░░██████░░░░░░░░░░▓░░██░░
░░░░▓████▓░░░░░░░░███▓██▓░░░░░░░░█████░░░
░░░░░▓█▓████▓░░░░░██░▓▓██░░░░▓████░██░░░░
░░░░░░░░▓█▓██░▓░░░██▓▓▓██░░█▓█████░░░░░░░
░░░░░░░░▓█░███▓░░░▓▓▓░▓░░░░░█▓██▓█░░░░░░░
░░░░░░░░▓█░██▓░░▓░░░░░░░░░▓░███▓▓█░░░░░░░
░░░░░░░░▓█░███▓███▓░░░░░▓███▓██░▓█░░░░░░░
░░░░░░░░██░░██░▓░█████████░▓▓█▓░▓█░░░░░░░
░░░░░░░░▓█░░▓██▓▓░░▓░█░█░▓░▓██░░░█░░░░░░░
░░░░░░░░░█▓░░████░▓░░▓░░▓▓███░░░██░░░░░░░
░░░░░░░░░▓█▓░░████████▓█████░░░██▓░░░░░░░
░░░░░░░░░░░██░░▓▓▓▓▓▓▓▓▓▓▓█░░░██░░░░░░░░░
░░░░░░░░░░░░██░░▓█████▓██▓░░▓██░░░░░░░░░░
░░░░░░░░░░░░░██░░░░░▓▓░░░░░███░░░░░░░░░░░
░░░░░░░░░░░░░░██░░░░░░░░░░██▓░░░░░░░░░░░░
░░░░░░░░░░░░░░▓██░░░░░░░░██░░░░░░░░░░░░░░
░░░░░░░░░░░░░░░░██████████░░░░░░░░░░░░░░░
";
        // Estudiantes iniciales
        estudiantes[0] = "Carlos ";
        estudiantes[1] = "Ana  ";
        estudiantes[2] = "Luis ";
        estudiantes[3] = "Sofía ";
        estudiantes[4] = "Marcos ";
        estudiantes[5] = "Paula ";
        estudiantes[6] = "Juan  ";
        estudiantes[7] = "Lucía";
        string opcion;

        //bucle do-whie 
        do
        {
            Mostrar_Menu(); //nombre de la funcion del menu
            Console.Write("Ingrese su opción: ");//pedir al usuario ingresar una de las opciones
            opcion = Console.ReadLine()!; //para guardar la opcion deseada

            switch (opcion) //un switch con la variable opcion
            {
                case "1":
                    SeleccionarEstudiantes();//primer case (seleccion de estudiantes)
                    break;
                case "2":
                    VerUltimosSeleccionados();//segundo case (ultimos estudiantes seleccionados)
                    break;
                case "3":
                    MostrarHistorial();//tercer case  muestra el historial
                    break;
                case "4":
                    GestionEstudiantes();//cuarto case gestion de estudiantes selecionandos
                    break;
                case "5":
                    if (ConfirmarSalida())//funcion de confirmacion
                        return;//para detener el programa
                    break;
                default://default: advertencia al usuario ingresar una opcion invalida
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" ⚠️Opción inválida. Intente de nuevo.⚠️");
                    Console.ResetColor();
                    Console.WriteLine(kaomoji);
                    break;
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();

        } while (true);
    }

    static void Mostrar_Menu()
    {
        //         string emoji = @"
        // ________________¶¶¶¶¶¶¶¶¶¶¶¶¶¶
        // ____________¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶
        // _________¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶
        // _______¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶
        // ______¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶
        // _____¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶
        // ____¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶
        // ___¶¶¶¶¶¶¶_____¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶
        // _¶¶¶¶¶_____¶¶¶¶___¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶
        // _¶¶¶¶_____¶¶¶¶¶¶¶__¶¶¶¶¶¶¶¶¶¶¶¶____¶¶¶¶¶¶¶¶¶
        // _¶¶¶______¶¶¶¶¶¶¶___¶¶¶¶¶¶¶¶¶¶______¶¶¶¶¶¶¶¶
        // ¶¶¶_______¶¶¶¶¶¶¶____¶¶¶¶¶¶¶¶¶______¶¶¶¶¶¶¶¶
        // ¶¶_________¶¶¶¶¶______¶¶¶¶¶¶¶¶¶____¶¶¶¶¶¶¶¶¶
        // ¶¶¶___________________¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶
        // ¶¶¶____________________¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶
        // _¶¶_____________________¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶_¶
        // _¶¶¶_____________________¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶_¶¶
        // __¶¶_______________________¶¶¶¶¶¶¶¶¶¶¶¶¶_¶¶
        // ___¶¶______¶¶¶¶__________________¶¶_____¶¶
        // ____¶¶¶_____¶¶¶¶¶_____________¶¶¶¶¶____¶¶
        // _____¶¶¶_______¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶_____¶¶¶
        // ______¶¶¶¶________¶¶¶¶¶¶¶¶¶¶¶______¶¶¶¶
        // ________¶¶¶¶________¶¶¶¶¶¶¶¶____¶¶¶¶¶
        // __________¶¶¶¶¶______________¶¶¶¶¶¶
        // _____________¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶
        // ";



Console.ForegroundColor = ConsoleColor.Red;
string carro1 =

@"   \_______________/           
    __/__|______|__\__          
    /⭕⭕______⭕⭕\ 
    |__/__GTR-RR34__\__| 
    \©©__|_|_|_|_|__©©";
        Console.ResetColor();


Console.ForegroundColor = ConsoleColor.Yellow;
        string centro =
@" ▒▒▒▒▒▒▐███████▌ 
   ▒▒▒▒▒▒▐▄▄▄▄▄▄▄▌ 
  ▄▀▀▀█▒▐░▀▀▄▀▀░▌▒█▀▀▀▄ 
  ▌▌▌▌▐▒▄▌░▄▄▄░▐▄▒▌▐▐▐▐";
  Console.ResetColor();
 

Console.ForegroundColor = ConsoleColor.Blue;
 string carro2 =
 @"
      \_______________/           
    __/__|______|__\__          
    /⭕⭕______⭕⭕\ 
    |__/__GTR-RR34__\__| 
    \©©__|_|_|_|_|__©©";
     Console.ResetColor();


        string titulo2 = @"
                █▄─▄▄▀█▄─██─▄█▄─▄███▄─▄▄─█─▄─▄─██▀▄─██
                ██─▄─▄██─██─███─██▀██─▄█▀███─████─▀─██
                ▀▄▄▀▄▄▀▀▄▄▄▄▀▀▄▄▄▄▄▀▄▄▄▄▄▀▀▄▄▄▀▀▄▄▀▄▄▀";




        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(carro1);
        Console.ResetColor();

        Console.Write(" ");

        Console.Write(centro);

        Console.Write(" ");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(carro2);
        Console.ResetColor();
        SoundPlayer carro = new SoundPlayer("carro.wav");
        carro.PlaySync();
        Console.WriteLine(titulo2);
 

        SoundPlayer bienvenida = new SoundPlayer("Bienvenida.wav");
        bienvenida.PlaySync();

        //menu de la consola

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("╔═════════════∘◦☠︎︎^(⑉>▽<⑉)^☠︎︎◦∘═════════════════╗");
        Console.WriteLine("║ 1. 🎲 Iniciar nueva selección               ║");
        Console.WriteLine("࿔ 2. 📋 Ver últimos seleccionados             ࿔");
        Console.WriteLine("☯ 3. 📁 Ver historial completo                ☯");
        Console.WriteLine("༄ 4. ✏️ Gestionar estudiantes                  ༄");
        Console.WriteLine("║ 5. ❌ Salir                                 ║");
        Console.WriteLine("╚══════════════🐺☆✮〰 ♕  〰☆✮🐺═══════════════╝");
        Console.ResetColor();


        // Console.WriteLine(emoji);
    }

    static void SeleccionarEstudiantes()


    {
        Random Giro = new Random();

        //         string G = @"
        //          ____                                  __               ___                                ___           __                           
        // /\  _`\   __                          /\ \             /\_ \                              /\_ \         /\ \__                        
        // \ \ \L\_\/\_\  _ __    __      ___    \_\ \    ___     \//\ \      __        _ __   __  __\//\ \      __\ \ ,_\    __                 
        //  \ \ \L_L\/\ \/\`'__\/'__`\  /' _ `\  /'_` \  / __`\     \ \ \   /'__`\     /\`'__\/\ \/\ \ \ \ \   /'__`\ \ \/  /'__`\               
        //   \ \ \/, \ \ \ \ \//\ \L\.\_/\ \/\ \/\ \L\ \/\ \L\ \     \_\ \_/\ \L\.\_   \ \ \/ \ \ \_\ \ \_\ \_/\  __/\ \ \_/\ \L\.\_  __  __  __ 
        //    \ \____/\ \_\ \_\\ \__/.\_\ \_\ \_\ \___,_\ \____/     /\____\ \__/.\_\   \ \_\  \ \____/ /\____\ \____\\ \__\ \__/.\_\/\_\/\_\/\_\
        //     \/___/  \/_/\/_/ \/__/\/_/\/_/\/_/\/__,_ /\/___/      \/____/\/__/\/_/    \/_/   \/___/  \/____/\/____/ \/__/\/__/\/_/\/_/\/_/\/_/

        //                                                                                                                                       ";
        string figura = @"
─────────▀▀▀▀▀▀──────────▀▀▀▀▀▀▀
──────▀▀▀▀▀▀▀▀▀▀▀▀▀───▀▀▀▀▀▀▀▀▀▀▀▀▀
────▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀──────────▀▀▀
───▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀──────────────▀▀
──▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀──────────────▀▀
─▀▀▀▀▀▀▀▀▀▀▀▀───▀▀▀▀▀▀▀───────────────▀▀
─▀▀▀▀▀▀▀▀▀▀▀─────▀▀▀▀▀▀▀──────────────▀▀
─▀▀▀▀▀▀▀▀▀▀▀▀───▀▀▀▀▀▀▀▀──────────────▀▀
─▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀───────────────▀▀
─▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀───────────────▀▀
─▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀───────────────▀▀
──▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀───────────────▀▀
───▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀───────────────▀▀▀
─────▀▀▀▀▀▀▀▀▀▀▀▀▀───────────────▀▀▀
──────▀▀▀▀▀▀▀▀▀▀▀───▀▀▀────────▀▀▀
────────▀▀▀▀▀▀▀▀▀──▀▀▀▀▀────▀▀▀▀
───────────▀▀▀▀▀▀───▀▀▀───▀▀▀▀
─────────────▀▀▀▀▀─────▀▀▀▀
────────────────▀▀▀──▀▀▀▀
──────────────────▀▀▀▀
───────────────────▀▀
";


        //validacion

        if (totalEstudiantes < 2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"⚠️ No hay suficientes estudiantes para realizar la selección.X_X X_X ");
            Console.ResetColor();
            return;
        }

        //control de seleccion de un mismo estudiante
        int indice1, indice2;
        do
        {
            indice1 = random.Next(totalEstudiantes);
            indice2 = random.Next(totalEstudiantes);
        } while (indice1 == indice2);

        string piloto = estudiantes[indice1];
        string copiloto = estudiantes[indice2];

        ya_fue_copiloto[indice1] = true;
        ya_fue_piloto[indice2] = true;

        ultimopiloto = piloto;
        ultimoCopiloto = copiloto;

        string elegidos = $"{piloto}{copiloto}";
        int vueltas = Giro.Next(1, 5);//cantidad de vuelas para la animacion

        for (int i = 0; i < vueltas; i++)
        {
            int orbita = Giro.Next(estudiantes.Length);
            elegidos = estudiantes[orbita];

            if (elegidos == elegidos)
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("(っ◔◡◔)っ ♥ Girando la ruleta... ♥");
                Console.ResetColor();

                Console.WriteLine(elegidos);
                Thread.Sleep(100 + 1 * 4); //se va poniendo mas lento

                SoundPlayer giros = new SoundPlayer("ruleta.wav");
                giros.PlaySync();
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("🎯 Resultados de la Selección Aleatoria 🎯");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"☯️ " + $"El Piloto; {piloto} ");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"☯️ " + $"  El Copiloto: {copiloto} ");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(figura);
        Console.ResetColor();

        SoundPlayer seleccionado = new SoundPlayer("seleccionado.wav");
        seleccionado.PlaySync();

        bool todos_fueron_asignados = true;

        for (int i = 0; i < totalEstudiantes; i++)
        {

            if (ya_fue_copiloto[i] == true || ya_fue_piloto[i] == true)
            {
                todos_fueron_asignados = false;
                break;
            }
        }

        if (todos_fueron_asignados)
        {
            Console.WriteLine(" Los estudiantes a ocupado cada rool.. Fin de la selección");

            Console.WriteLine("presione cualquier tecla para salir: ");
            Console.ReadKey();
            Environment.Exit(0);
        }
        string registro = $"{DateTime.Now}: {elegidos}"; //YIN: {YIN}, YANG: {YANG}";//el registro del archivo de text
        File.AppendAllText(archivoHistorial, registro + "\n");//agrega cada selecion al final 
    }

    static void VerUltimosSeleccionados()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("📋 Últimos seleccionados:");
        Console.ResetColor();

        if (string.IsNullOrEmpty(ultimopiloto) || string.IsNullOrEmpty(ultimoCopiloto))
        {
            Console.WriteLine("Aún no se ha realizado ninguna selección. 😢😢");
        }
        else
        {
            Console.WriteLine("☯️ " + $"EL YIN: {ultimopiloto}");
            Console.WriteLine("☯️ " + $"El YANG: {ultimoCopiloto}");
        }
    }

    static void MostrarHistorial()

    {

        //string xd = @"💪 ( ͡👁️ ͜ʖ ͡👁️) 👊";
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("📁 Historial de Selecciones:");
        Console.ResetColor();

        if (File.Exists(archivoHistorial))
        {
            string[] lineas = File.ReadAllLines(archivoHistorial);
            foreach (string linea in lineas)
            {
                Console.WriteLine(linea);
            }
        }
        else
        {
            Console.WriteLine("❎" + "No hay historial disponible.");
        }
    }

    static void GestionEstudiantes()
    {
        string dentro = @"
⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛⬜⬜⬜⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬜⬜⬜⬛
⬜⬜⬜⬜⬛⬜⬜⬜⬛⬜⬛⬜⬜⬜⬛⬜⬜⬜⬛⬜⬛⬜⬜⬜⬛
⬜⬜⬜⬜⬛⬜⬜⬜⬛⬜⬜⬛⬜⬛⬜⬛⬜⬛⬜⬜⬛⬜⬜⬜⬛
⬜⬜⬜⬜⬜⬛⬛⬛⬜⬜⬜⬜⬛⬜⬜⬜⬛⬜⬜⬜⬜⬛⬛⬛⬜
⬜⬜⬜⬜⬜⬜⬜⬜🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬜⬜⬜
⬜⬜⬜⬜🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬜⬜⬜
⬜⬜⬜⬜🟨🟨🟨🟨⬛⬛⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬜⬜
⬜⬜⬜🟨🟨🟨🟨⬛⬛🌫️🌫️🌫️🌫️⬛🟨🟨🟨🟨⬛⬛⬛⬛🟨⬜⬜
⬜⬜🟨🟨🟨🟨⬛⬛⬛⬛🌫️🌫️🌫️⬛⬛🟨⬛⬛🌫️🌫️🌫️🌫️⬛🟨⬜
⬜⬜🟨🟨🟨⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛🌫️🌫️⬜⬛🟨⬜
⬜⬜🟨🟨🟨⬛⬛⬛⬛⬛⬛⬛⬛⬛🟨⬛⬛⬛⬛⬛⬛⬛⬛⬛⬜
⬜⬜🟨🟨🟨⬛⬛⬛⬛⬛⬛⬛⬛⬛🟨⬛⬛⬛⬛⬛⬛⬛⬛⬛⬜
⬜⬜🟧🟧🟧⬛⬛⬛⬛⬛⬛⬛⬛🟨🟨⬛⬛⬛⬛⬛⬛⬛⬛⬜⬜
⬜⬜🟧🟧🟧🟧🟧⬛⬛⬛⬛🟨🟨🟨🟨🟨⬛⬛⬛⬛⬛⬛⬛⬜⬜
⬜⬜🟧🟧🟧🟧🟧🟧🟧🟨🟨🟨⬛⬛⬛🟨🟧⬛⬛⬛⬛⬛⬜⬜⬜
⬜⬜⬜🟧🟧🟧🟧🟧🟧🟧🟨🟨🟨🟨🟨🟧🟧🟧🟧🟧🟧🟧⬜⬜⬜
⬜⬜⬜🟧🟧🟧🟧🟧🟧🟧🟧🟨🟨🟨🟨🟧🟧🟧🟧🟧🟧🟧⬜⬜⬜
⬜⬜⬜⬜🟧🟧🟧🟧🟧🟧🟧🟨🟨🟨🟨🟧🟧🟧🟧🟧🟧⬜⬜⬜⬜
⬜⬜⬜⬜⬜🟧🟧🟧🟧🟧🟧🟨🟨🟨🟨🟧🟧🟧🟧🟧⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜🟧🟧🟧🟧🟧🟨🟨🟨🟨🟧🟧🟧🟧⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜";
        string killer = @"
────────────────────────────────────────
─────────────▄▄██████████▄▄─────────────
─────────────▀▀▀───██───▀▀▀─────────────
─────▄██▄───▄▄████████████▄▄───▄██▄─────
───▄███▀──▄████▀▀▀────▀▀▀████▄──▀███▄───
──████▄─▄███▀──────────────▀███▄─▄████──
─███▀█████▀▄████▄──────▄████▄▀█████▀███─
─██▀──███▀─██████──────██████─▀███──▀██─
──▀──▄██▀──▀████▀──▄▄──▀████▀──▀██▄──▀──
─────███───────────▀▀───────────███─────
─────██████████████████████████████─────
─▄█──▀██──███───██────██───███──██▀──█▄─
─███──███─███───██────██───███▄███──███─
─▀██▄████████───██────██───████████▄██▀─
──▀███▀─▀████───██────██───████▀─▀███▀──
───▀███▄──▀███████────███████▀──▄███▀───
─────▀███────▀▀██████████▀▀▀───███▀─────
───────▀─────▄▄▄───██───▄▄▄──────▀──────
──────────── ▀▀███████████▀▀ ────────────
────────────────────────────────────────
";
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("🤓" + "Gestión de Estudiantes");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("1.📒" + "Agregar estudiante");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("2.✏️" + " Editar estudiante");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("3.😵" + "Eliminar estudiante");
        Console.ResetColor();

        Console.Write("👀" + "Seleccione una opción:" + "👀  ");

        string opcion = Console.ReadLine()!;
        switch (opcion)
        {
            case "1":
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("🤓👨‍💻" + "Nombre del nuevo estudiante: ");
                string nuevo = Console.ReadLine()!;
                Console.ResetColor();

                if (!string.IsNullOrWhiteSpace(nuevo) && totalEstudiantes < estudiantes.Length)
                {
                    estudiantes[totalEstudiantes++] = nuevo;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("👨‍💻🤓" + "Estudiante agregado exitosamente.");
                    Console.WriteLine(dentro);

                    SoundPlayer Agregado = new SoundPlayer("seleccionado.wav");
                    Agregado.PlaySync();
                }
                else Console.WriteLine("Nombre inválido o máximo alcanzado. " + "🤷‍♂️🤷‍♂️");
                break;

            case "2":
                MostrarListaEstudiantes();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Ingrese número del estudiante a editar: " + "👨‍💻📒");
                Console.ResetColor();

                if (int.TryParse(Console.ReadLine(), out int posEditar) && posEditar >= 0 && posEditar < totalEstudiantes)
                {
                    Console.Write("Nuevo nombre:" + "📒 ");
                    string editado = Console.ReadLine()!;
                    if (!string.IsNullOrWhiteSpace(editado)) estudiantes[posEditar] = editado;
                }

                else
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Índice inválido." + "☠️☠️");
                break;

            case "3":
                MostrarListaEstudiantes();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Ingrese número del estudiante a eliminar: " + " 👨‍💻☠️");
                Console.ResetColor();

                if (int.TryParse(Console.ReadLine(), out int posEliminar) && posEliminar >= 0 && posEliminar < totalEstudiantes)
                {
                    for (int i = posEliminar; i < totalEstudiantes - 1; i++)
                        estudiantes[i] = estudiantes[i + 1];
                    estudiantes [--totalEstudiantes] = null!;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Estudiante eliminado correctamente. ");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(killer);
                    Console.ResetColor();

                }
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Índice inválido. " + "☠️☠️");
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opción inválida. ");
                break;
        }
    }

    static void MostrarListaEstudiantes()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Lista actual de estudiantes: " + "📒👨‍💻");
        Console.ResetColor();
        for (int i = 0; i < totalEstudiantes; i++)
        {
            Console.WriteLine($"{i}. {estudiantes[i]} ");
        }
    }

    static bool ConfirmarSalida()
    {

        string figura = @"
        ◌                             ◌                                       ◌           
                                            ‧₊ *:･ﾟ彡       ◌                 ☽︎       ◌
            ◌                                 ✩彡 ･ﾟ *:                                     
                                ◌   ██▓▒­░ ►▬ HASTA PRONTO ▬◄ ░▒▓██                                ◌
◌             ₊˚ ☁️⋅♡🪐༘⋆                                                         ‧₊˚ ☁️⋅♡🪐༘⋆
                                                ♡
                                        (\_(\      /)_/)
                                        (      )    (      )
                                     ૮/ʚɞ  |ა ૮|  ʚɞ\ა
                                      ( ◌    |      |     ◌ )";
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("¿Está seguro que desea salir? (S/N): ");
        string respuesta = Console.ReadLine()!;

        SoundPlayer despedida = new SoundPlayer("despedida.wav");
        despedida.PlaySync();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(figura);
        Console.ResetColor();

        return respuesta.Trim().ToUpper() == "S";
    }
}








