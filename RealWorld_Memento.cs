using System;
using System.Text;


/*
 * Използвайки шаблона за дизайн Memento(Спомен) създайте програма на C#, която
 * да запазва вътрешното състояние на класа Editor, който има като полета text, cursorX, cursorY, selectedWidth.
 * Създайте клас Snapshot, който да пази състоянието на Editor и да има функционалност за тяхното взимане и за връщането на запазеното състояние.
 */

namespace Memento
{
    //Класа Editor, който ще бъде запазван вътрешното му състояние
    class Editor
    {
        public string Text { get; set; }
        public string CursorX { get; set; }
        public string CursorY { get; set; }
        public string SelectionWidth { get; set; }
        
        //Запазването на състоянието
        public Snapshot createSnapshot()
        {
            return new Snapshot(this, Text, CursorX, CursorY, SelectionWidth);
        }

        public override string? ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();  
            stringBuilder.Append("Text: "+Text);
            stringBuilder.Append("\n");
            stringBuilder.Append("CursorX: " + CursorX);
            stringBuilder.Append("\n");
            stringBuilder.Append("CursorY: " + CursorY);
            stringBuilder.Append("\n");
            stringBuilder.Append("SelectionWidth: " + SelectionWidth);
            stringBuilder.Append("\n");

            return stringBuilder.ToString();
        }
    }

    //Класа, който ще държи запазеното състояние
    class Snapshot
    {
        private Editor editor;
        private string Text { get; set; }
        private string CursorX { get; set; }
        private string CursorY { get; set; }
        private string SelectionWidth { get; set; }

        public Snapshot(Editor editor, string text, string cursorX, string cursorY, string selectionWidth)
        {
            this.editor = editor;
            Text = text;
            CursorX = cursorX;
            CursorY = cursorY;
            SelectionWidth = selectionWidth;
        }

        //Метода за връщане на състоянието
        public void restore()
        {
            editor.Text = Text;
            editor.CursorX = CursorX;   
            editor.CursorY = CursorY;
            editor.SelectionWidth = SelectionWidth;
        }

        public Editor getSavedEditor()
        {
            return editor;
        }
    }

  

    class Program
    {
        static void Main(string[] args)
        {
            //Създаване на първоначален Editor
            Editor editor = new Editor();
            editor.Text = "Моят 1 текстови редактор";
            editor.CursorX = "100";
            editor.CursorY = "200";
            editor.SelectionWidth = "300";

            Console.WriteLine("Текущото състояние на Editor:");
            Console.WriteLine( editor.ToString());

            //Създаване на спомен
            Snapshot snapshot =  editor.createSnapshot();

            //Промяна на създадения Editor
            editor.Text = "Моят 2 текстови редактор";
            editor.CursorX = "6969";
            editor.CursorY = "1002";
            Console.WriteLine("Променено състояние на Editor:");
            Console.WriteLine(editor.ToString());

            //Връщане на старото състояние на Editor
            Console.WriteLine("Връщане на състоянието на Editor:");
            snapshot.restore();
            Console.WriteLine(editor.ToString());


        }
    }
 


}