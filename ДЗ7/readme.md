# Основное задание:
1. Написать сериализацию свойств или полей класса в строку
1. Проверить на классе: class F { int i1, i2, i3, i4, i5; Get() => new F(){ i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 }; }
1. Замерить время до и после вызова функции (для большей точности можно сериализацию сделать в цикле 100-100000 раз)
1. Вывести в консоль полученную строку и разницу времен
1. Отправить в чат полученное время с указанием среды разработки и количества итераций
1. Замерить время еще раз и вывести в консоль сколько потребовалось времени на вывод текста в консоль
1. Провести сериализацию с помощью каких-нибудь стандартных механизмов (например в JSON)
1. И тоже посчитать время и прислать результат сравнения
1. Написать десериализацию/загрузку данных из строки (ini/csv-файла) в экземпляр любого класса
1. Замерить время на десериализацию
1. Общий результат прислать в чат с преподавателем

## Результаты
- Сериализуемый класс: [class F](https://github.com/T1m-cpp/Otus.CSharp.Developer.Professional/blob/main/ДЗ7/Reflection/TestClasses/F.cs)
- Код сериализации-десериализации: [сериализация](https://github.com/T1m-cpp/Otus.CSharp.Developer.Professional/blob/main/ДЗ7/Reflection/Implementations/Serializer.cs)-[десериализация](https://github.com/T1m-cpp/Otus.CSharp.Developer.Professional/blob/main/ДЗ7/Reflection/Implementations/Deserializer.cs)
- Количество замеров: 1_000_000 итераций
- Мой рефлекшен:
  - Время на сериализацию = 669 мс:
  - Время на десериализацию = 925 мс:
- Стандартный механизм (System.Text.Json):
  - Время на сериализацию = 174 мс
  - Время на десериализацию = 166 мс:
- Среда разработки:
  - Visual Studio 2022
  - dotnet 8
  - Windows 10 Pro
  - Release сборка

### Демонстрация работы программы
![alt text](https://github.com/T1m-cpp/Otus.CSharp.Developer.Professional/blob/main/ДЗ7/img/result.png) 




