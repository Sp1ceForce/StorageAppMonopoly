using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageAppInterface.DrawHandlers
{

    //Статический класс, отвечает за работу почти всех меню
    public static class MenuDrawHandler
    {
        public static void ExecuteOneMenuCycle(IReadOnlyDictionary<string,Command> commands, string menuName)
        {
            //Console.Clear();
            DrawMenu(commands, menuName);
            string input = GetInput();
            if (!string.IsNullOrWhiteSpace(input))
            {
                ProcessInput(input, commands);
            }
        }
        static void DrawMenu(IReadOnlyDictionary<string, Command> commands, string menuName)
        {
            StringBuilder sb = new StringBuilder($"{menuName}\n");
            foreach (var command in commands)
            {
                sb.Append($"{command.Key} : {command.Value.CommandDescription} \n");
            }
            sb.Append("Введите номер команды:");
            Console.WriteLine(sb);
        }
        //Обработчик ввода, убирает все пробелы из получаемой строки
        static string GetInput()
        {
            return new string(Console.ReadLine().ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
        }
        static void ProcessInput(string input, IReadOnlyDictionary<string,Command> commands)
        {
            if(commands.TryGetValue(input, out Command command))
            {
                command.Activate();
            }
        }
    }
}
