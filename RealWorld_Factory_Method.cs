using System;

/*
 Използвайки градивния шаблон за дизайн Factory Method създайте програма на C#, която
да създава WindowsDialog или WebDialog, следователно по даден environment type(тип среда).
Всеки 1 диалог може да създава съответно WindowsDialog -> WindowsButton & WebDialog -> HTMLButton.
Ако средата не е нито windows или web трябва да хвърлите грешка. Всеки тип бутон трябва да има
функционалност за рендериране и при клик да прави нещо (да изписва нещо на конзолата). В Main
метода създайте 3 диалога (1 windows, 1 web и 1 невалиден), създайте съответните бутони, рендерирайте ги
и изпълнете при клик метода.
 */
namespace FactoryMethod
{
   //абстрактния клас ще бъде наследен от конкретните Диалози
    abstract class Dialog
    {
       
        public abstract Button createButton();

        public string render()
        {
          
            Button button = createButton();
       
            string result = string.Format("{0} е създаден.",button.GetType().Name);
            
            return result;
        }
    }

    //Конкретен клас 1
    class WindowsDialog : Dialog
    {
      
        public override Button createButton()
        {
            return new WindowsButton();
        }
    }

    //Конкретен клас 2
    class WebDialog : Dialog
    {
        public override Button createButton()
        {
            return new HTMLButton();
        }
    }

    //интерфейс за самите Бутони,който ще биват създавани постредством Диалозите
    public interface Button
    {
        string render();
        string onClick(string target);
    }

    //Конкретен бутон 1
    class WindowsButton : Button
    {
 

        public string onClick(string target)
        {
            return string.Format("{0} е кликнат", target);
        }

        public string render()
        {
            return string.Format("{0} е показан(дисплейнат)", this.GetType().Name);
        }
    }

    //Конкретен бутон 2
    class HTMLButton : Button
    {
        public string onClick(string target)
        {
            return string.Format("{0} е кликнат", target);
        }

        public string render()
        {
            return string.Format("{0} е показан(дисплейнат)", this.GetType().Name);
        }
    }


    class Program
    {
        //Самият Factory Method, който решава какъв Диалог да се създаде
        //Посредством подаден environmentType
        public static Dialog initializer(string environmentType)
        {
            Dialog dialog;
            if (environmentType == "Windows")
            {
                dialog = new WindowsDialog();
            }
            else if (environmentType == "Web")
            {
                dialog = new WebDialog();
            }
            else throw new InvalidOperationException("Грешка! Непозната среда!");

            return dialog;
        }
        static void Main(string[] args)
        {
            Dialog dialogWin = initializer("Windows");
            Console.WriteLine(dialogWin.render()); 
            Button winButton = dialogWin.createButton();
            Console.WriteLine(winButton.render());
            Console.WriteLine(winButton.onClick("Exit"));

            Console.WriteLine();
            
            Dialog dialogWeb = initializer("Web");
            Console.WriteLine(dialogWeb.render());
            Button webButton = dialogWeb.createButton();
            Console.WriteLine(webButton.render());
            Console.WriteLine(webButton.onClick("Log in"));

            Console.WriteLine();

            Dialog dialogError = initializer("Linux");
        }
    }
}