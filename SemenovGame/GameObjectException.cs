using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Создать собственное исключение GameObjectException, которое появляется при попытке создать объект с неправильными характеристиками(например, отрицательные размеры, слишком большая скорость или неверная позиция).
namespace WindowsFormsApp1
{
    class GameObjectException : Exception
    {
        public GameObjectException(string message)
            : base(message)
        {

        }
    }
}
