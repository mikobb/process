using System.Diagnostics;

class Programm {
    static void Main(String[] args)
    {
        string vibor = "";
        string name = "";
        Process[] procList = Process.GetProcesses();
        foreach (Process proc in procList) {
            Console.Write(proc.ProcessName +" ID процесса " + proc.Id + " потребляемая память " + proc.PagedMemorySize64 / 1024 + " состояние процесса " + proc.Responding);
            Console.WriteLine("");
        }
        while (true)
        {
            Console.WriteLine("Выберите что вы желаете создать или удалить процесс, чтобы закончить exit");
            Log("Выберите что вы желаете создать или удалить процесс, чтобы закончить exit");
            vibor = Console.ReadLine();
            if (vibor == "exit") {
                break;
            }
            Log(vibor);
            switch (vibor)
            {
                case "создать":
                    Console.WriteLine("Выберите какой процесс вы хотите создать (например notepad.exe");
                    Log("Выберите какой процесс вы хотите создать (например notepad.exe");
                    name = Console.ReadLine();
                    Process.Start(name);
                    Log(name);
                    Console.WriteLine("Процесс успешно создан");
                    Log("Процесс успешно создан");
                    break;

                case "удалить":
                    Console.WriteLine("Введите ID процесса");
                    Log("Введите ID процесса");
                    Process targe = Process.GetProcessById(Convert.ToInt32(Console.ReadLine()));
                    Log(Convert.ToString(targe.Id));
                    targe.Kill();
                    Console.WriteLine("Процесс завершен успешно");
                    Log("Процесс завершен успешно");
                    break;
            }
        }
    }
    public static void Log(string message)
    {
        string path = "logs.txt";
        using (StreamWriter sr = new StreamWriter(path, true))
        {
            sr.WriteLine(DateTime.Now +" " + message);
        }
    }
}