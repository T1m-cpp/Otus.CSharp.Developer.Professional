# Описание/Пошаговая инструкция выполнения домашнего задания:
1. Написать обобщённую функцию расширения, находящую и возвращающую максимальный элемент коллекции.
Функция должна принимать на вход делегат, преобразующий входной тип в число для возможности поиска максимального значения.
public static T GetMax(this IEnumerable collection, Func<T, float> convertToNumber) where T : class;
1. Написать класс, обходящий каталог файлов и выдающий событие при нахождении каждого файла;
1. формить событие и его аргументы с использованием .NET соглашений:
public event EventHandler FileFound;
FileArgs – будет содержать имя файла и наследоваться от EventArgs;
1. Добавить возможность отмены дальнейшего поиска из обработчика;
1. Вывести в консоль сообщения, возникающие при срабатывании событий и результат поиска максимального элемента.
# Демонстрация работы
Для демонстрации нахождения максимального элемента коллекции использовались следующие тестовые данные:
![alt text](https://github.com/T1m-cpp/Otus.CSharp.Developer.Professional/blob/main/ДЗ8/img/Cars.png)  
И следующие обработчики:
![alt text](https://github.com/T1m-cpp/Otus.CSharp.Developer.Professional/blob/main/ДЗ8/img/Handlers.png)  
Для поиска файлов использовалась следующая директория с тестовыми файлами:
![alt text](https://github.com/T1m-cpp/Otus.CSharp.Developer.Professional/blob/main/ДЗ8/img/Files.png)  
Демонстрация работы программы:  
![alt text](https://github.com/T1m-cpp/Otus.CSharp.Developer.Professional/blob/main/ДЗ8/img/Result.png)

