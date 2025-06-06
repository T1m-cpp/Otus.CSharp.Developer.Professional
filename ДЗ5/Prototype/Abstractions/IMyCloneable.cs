namespace Prototype.Abstractions
{
    //Пользовательский обобщённый интерфейс, предназначенный для реализации шаблона проектирования "Прототип".
    //Определяет метод MyClone(), который возвращает копию объекта типа T.
    interface IMyCloneable<T> where T : class
    {
        T MyClone();
    }
}
