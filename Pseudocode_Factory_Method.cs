// Класът създател декларира Фактори методa, който трябва
// връща обект от продуктов клас. Подкласовете на създателя
// обикновено предоставя имплементацията на този метод.
class Dialog is
    // Създателят може също така да предостави някаква реализация по подразбиране
    // на Фактори методa.
    abstract method createButton():Button

    // Имайте предвид, че въпреки името си, основният създател на
     // отговорността не е създаването на продукти. Обикновено
     // съдържа някаква основна бизнес логика, която разчита на продукта
     // обекти, върнати от Фактори метода. Подкласовете могат
     // косвено да променят тази бизнес логика, като отменя
     // Фактори методa и връщане на различен тип продукт
     // от него.
    method render() is
        // Извикване на Фактори метода за създаване на продуктов обект.
        Button okButton = createButton()
        // Сега използвайки продукта.
        okButton.onClick(closeDialog)
        okButton.render()


// Конкретните създатели заменят Фактори метода, за да променят
// типът на получения продукт.
class WindowsDialog extends Dialog is
    method createButton():Button is
        return new WindowsButton()

class WebDialog extends Dialog is
    method createButton():Button is
        return new HTMLButton()


// Интерфейсът на продукта декларира операциите, които всички
// конкретни продукти трябва да изпълняват.
interface Button is
    method render()
    method onClick(f)

// Конкретните продукти осигуряват различни изпълнения на
// продуктовия интерфейс.
class WindowsButton implements Button is
    method render(a, b) is
        // Render a button in Windows style.
    method onClick(f) is
        // Bind a native OS click event.

class HTMLButton implements Button is
    method render(a, b) is
        // Return an HTML representation of a button.
    method onClick(f) is
        // Bind a web browser click event.


class Application is
    field dialog: Dialog

    // Приложението избира типа създател в зависимост от
    // текуща конфигурация или настройки на средата.
    method initialize() is
        config = readApplicationConfigFile()

        if (config.OS == "Windows") then
            dialog = new WindowsDialog()
        else if (config.OS == "Web") then
            dialog = new WebDialog()
        else
            throw new Exception("Error! Unknown operating system.")

    // Клиентският код работи с инстанция на конкретния
     // създател, макар и през неговия базов интерфейс. Докато
     // клиентът продължава да работи със създателя чрез базата
     // интерфейс, можете да му предадете подклас на всеки създател.
    method main() is
        this.initialize()
        dialog.render()