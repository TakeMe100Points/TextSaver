using System;
using static TextSaver.TextContainer;

namespace TextSaver
{
    internal class Program
    {      
        
        static void Main(string[] args)
        {
            //Инициализация контейнера
            TextContainer container = new TextContainer();
            //И признака завершения работы
            bool done = false;

            Console.WriteLine("Enter text line and press Enter for new line. Press Ctrl + S to Save file");
                      

            while (!done)
            {
                //Получения символа с клавиатуры
                char sym = Console.ReadKey(true).KeyChar;

                //Добавление его в контейнер
                switch (container.AppendSymbol(sym))
                {
                    //был введен символ новой строки, т.к. ReadKey его не отображает, то введем пустую строку:
                    case InputControls.NextLine:    
                        {
                            Console.WriteLine();
                            break;
                        }
                    
                    //Пользователь нажал сочетание "Ctrl + S", завершение обработки текста
                    case InputControls.SaveToFile:
                        {
                            done = true;
                            break;
                        }
                    //Введен символ
                    case InputControls.AcceptableInput:
                        {
                            Console.Write(sym);
                            break;
                        }
                }                
            }

            string curDateTime = FilenameGenerator.GetFilenameFromCurrentDateTime();
            

            if(!container.ExportToFile(filename: curDateTime))
            {
                Console.WriteLine($"Error, file not saved.");
                return;
            }

            long writted = FileService.GetFileSize(filename: curDateTime);
            
            if(writted != -1)
                Console.WriteLine($"File successfully saved. {writted} bytes");
            else
                Console.WriteLine($"Error, wrong size of file.");

            Console.ReadLine();
        }
    }
}
