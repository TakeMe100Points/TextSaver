using System;
using System.IO;
using System.Text;

namespace TextSaver
{
    /// <summary>
    /// Контейнер, реализующий работу с текстом
    /// </summary>
    class TextContainer
    {
        /// <summary>
        /// Весь полученный текст
        /// </summary>
        private StringBuilder sb;

        /// <summary>
        /// Типы ввода символов
        /// </summary>
        public enum InputControls
        {
            AcceptableInput, SaveToFile, NextLine
        }

        public TextContainer() => sb = new StringBuilder();


        /// <summary>
        /// Добавить символ в текст
        /// </summary>
        /// <param name="sym">Добавляемый символ</param>
        /// <returns>Тип операции (сохранение, перенос строки, обычный символ)</returns>
        public InputControls AppendSymbol(char sym)
        {
            if (sym == Constants.SAVE_CODE)
                return InputControls.SaveToFile;

            sb.Append(sym);

            if (sym == Constants.NEXT_LINE_CODE)
                return InputControls.NextLine;
            else
                return InputControls.AcceptableInput;
        }

        /// <summary>
        /// Экспортировать текст из контейнера в файл
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <returns>Успешна ли операция</returns>
        public bool ExportToFile(string filename)
        {  
            try
            {
                using StreamWriter sw = new StreamWriter(filename);

                sw.Write(sb);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Save error: " + ex.Message.ToString());
                return false;
            }

            return true;         
        }
    }
}
