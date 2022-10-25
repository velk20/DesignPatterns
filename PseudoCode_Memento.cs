// Създателят съхранява някои важни данни, които може да се променят
// време. Той също така дефинира метод за запазване на състоянието му в
// спомен и друг метод за възстановяване на състоянието от него.
class Editor is
    private field text, curX, curY, selectionWidth

    method setText(text) is
        this.text = text

    method setCursor(x, y) is
        this.curX = x
        this.curY = y

    method setSelectionWidth(width) is
        this.selectionWidth = width

   // Запазва текущото състояние в спомен.
    method createSnapshot():Snapshot is
        // Споменът е неизменен обект; ето защо
         // авторът предава състоянието си на спомена като
         // параметри на конструктора.
        return new Snapshot(this, text, curX, curY, selectionWidth)

// Класът Спомен съхранява миналото състояние на редактора.
class Snapshot is
    private field editor: Editor
    private field text, curX, curY, selectionWidth

    constructor Snapshot(editor, text, curX, curY, selectionWidth) is
        this.editor = editor
        this.text = text
        this.curX = x
        this.curY = y
        this.selectionWidth = selectionWidth

    // В даден момент може да има предишно състояние на редактора
     // възстановено с помощта на обект за спомен.
    method restore() is
        editor.setText(text)
        editor.setCursor(curX, curY)
        editor.setSelectionWidth(selectionWidth)

 class Program
    {
        static void Main(string[] args)
        {
            //Създаване на първоначален Editor
            Editor editor = new Editor();
            

            //Създаване на спомен
            Snapshot snapshot =  editor.createSnapshot();

            //Промяна на създадения Editor
            editor.Text = "Моят 2 текстови редактор";
            editor.CursorX = "6969";
            editor.CursorY = "1002";

            //Връщане на старото състояние на Editor
          
            snapshot.restore();
   
        }
    }