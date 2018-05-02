using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closures
{
    

    
    class Program
    {
        static void Main(string[] args)
        {
            var action = CreateAction();
            action();
            action();
        }
        static Action CreateAction()
        {
            // Никакой переменной count в стеке больше нет.
            // Вместо нее создается объект класса DisplayClass1 и
            // используется его поле count.
            // В результате переменная count значимого типа располагается
            // не в стеке, а в управляемой куче и не будет собрана сборщиком
            // мусора до тех пор, пока будут оставаться ссылки на
            // делегат, созданный этим методом
            NewDisplay c1 = new NewDisplay();
            c1.message = "Inside anonymous method";
            c1.count = 0;
            Action action = new Action(c1.ActionMethod);
            return action;
        }
    }
    // Этот класс будет сгенерирован компилятором.
    // Настоящее его имя будет иметь вид типа "<>c__DisplayClass1".
    // Таким образом компилятор обеспечивает невозможность коллизий
    // имен, поскольку пользователь самостоятельно не сможет создать
    // класс имя которого будет содержать символы "<>".
    class NewDisplay : System.Object
    {
        public NewDisplay()
        { }
        public string message;

        // Имя этого метода тоже будет не столь благозвучным.
        // По тем же причинам (ради исключение
        // коллизий), имя это метода будет примерно
        // таким: "<CreateAction>b__0".
        public void ActionMethod()
        {
            count++;
            Console.WriteLine("{0}. Count = {1}", message, count);
        }
        public int count;
    }
}
