# Для работы с postgres использовал docker-образы postgres и adminer.  
* Для запуска контейнеров выполнить команду `docker compose up`, база данных VirtualStore создается автоматически при первом запуске
* Подключиться к adminer по адресу http://localhost:8080/, используя логин pgadmin и пароль 123
![alt text](https://github.com/T1m-cpp/Otus.C-.Developer.Professional/blob/main/ДЗ2/img/login.png)  
* Выполнить cкрипты из CreationScripts.sql, в результате чего создадутся нужные таблицы 
![alt text](https://github.com/T1m-cpp/Otus.C-.Developer.Professional/blob/main/ДЗ2/img/CreationScripts.png)
![alt text](https://github.com/T1m-cpp/Otus.C-.Developer.Professional/blob/main/ДЗ2/img/DBSchema.png)    
# Демонстрация выполнения скриптов из ДЗ  
Вначале необходимо подготовить тестовые данные  
```
-- Подготовительные действия
INSERT INTO Users(username, email, registrationdate)
VALUES 
       ('Al', 'Al11@1.com', '2024-02-12'),
       ('Bob', 'Bob2@1.com', '2025-02-01'),
       ('Tom', 'Tom@1.com', CURRENT_DATE);

INSERT INTO Orders(userid, orderdate, status)
VALUES 
       (1, '2025-01-01', 'Delivered'),
       (1, '2025-01-03', 'Delivered'),
       (1, '2025-04-25', 'Awaiting Payment'),
       (2, CURRENT_TIMESTAMP, 'Pending'),
       (3, '2025-04-21', 'Shipped'),
       (3, '2025-04-22', 'Shipped');
       
INSERT INTO OrderDetails (orderid, productid, quantity, totalcost)
VALUES     
       (1, 1, 3, (SELECT Price FROM Products WHERE ProductID = 1) * 3),
       (2, 2, 1, (SELECT Price FROM Products WHERE ProductID = 2) * 1),
       (3, 3, 8, (SELECT Price FROM Products WHERE ProductID = 3) * 8),
       (4, 4, 2, (SELECT Price FROM Products WHERE ProductID = 4) * 2),
       (5, 5, 3, (SELECT Price FROM Products WHERE ProductID = 5) * 3),
       (6, 6, 5, (SELECT Price FROM Products WHERE ProductID = 6) * 5);

```
1. Добавление нового продукта
```
INSERT INTO Products(productname, description, price, quantityinstock)
VALUES 
    ('Ноутбук MSI', 'Игровой ноутбук с RTX 5070 ti, ryzen 7 9900x', 225000.00, 10),
    ('Смартфон Samsung Galaxy s25 Ultra', 'Флагман с OLED-экраном, 12/256', 120000.00, 200),
    ('Наушники Air Pods Pro 2', 'Беспроводные с ANC', 190000, 20),
    ('Электросамокат Ninebot Kick Scooter E2 Plus II черный', 'E2 Plus E II позволяет эффективно справляться с ежедневными поездками на работу, по кампусу или в свободное время. Благодаря передней пружинной подвеске с ходом 27 мм амортизационная система E2 Plus E II обеспечивает плавную и комфортную езду по разным дорогам.', 26000.00, 3),
    ('Система охлаждения Arctic Cooling Liquid Freezer III 360 A-RGB', 'Система охлаждения Arctic Cooling Liquid Freezer III 360 A-RGB – трехсекционная модель с гидродинамическими подшипниками в вентиляторах для увеличенного рабочего ресурса и сниженного до 22.5 дБ уровня шума. ', 10499.00, 2),
    ('Корпус MONTECH KING 95 PRO белый', 'Белый корпус MONTECH KING 95 PRO для игрового компьютера представлен в формате Mid-Tower с вертикальной установкой материнской платы. Передняя и левая стенки из закаленного стекла позволяют следить за исправной работой компонентов. ARGB-подсветка корпуса и вентиляторов придает игровому компьютеру необычный внешний вид. Кнопка на передней панели позволяет одним касанием включать/отключать свечение.', 16600.00, 7);
```
![alt text](https://github.com/T1m-cpp/Otus.C-.Developer.Professional/blob/main/ДЗ2/img/AddProducts.png)  
2. Обновление цены продукта c id = 1
```
Update Products
SET Price = 230000.00
WHERE productid = 1;
```
![alt text](https://github.com/T1m-cpp/Otus.C-.Developer.Professional/blob/main/ДЗ2/img/UpdatePrice.png)  
3. Выбор всех заказов пользователя с id = 1
```
SELECT orderid, userid, orderdate, status
FROM Orders
WHERE UserID = 1;
```
![alt text](https://github.com/T1m-cpp/Otus.C-.Developer.Professional/blob/main/ДЗ2/img/UserOrders.png)    
4. Выбор всех заказов пользователя с id = 1 и расчет общей стоимости заказа
```
SELECT 
    SUM(od.TotalCost) AS TotalUserSpending
FROM 
    Orders o
JOIN 
    OrderDetails od ON o.OrderID = od.OrderID
WHERE 
    o.UserID = 1;
```
![alt text](https://github.com/T1m-cpp/Otus.C-.Developer.Professional/blob/main/ДЗ2/img/TotalUserSpending.png)   
5. Подсчет общего количества товаров на складе
```
SELECT SUM(QuantityInStock) AS TotalQuantityInStock
FROM Products;
```
![alt text](https://github.com/T1m-cpp/Otus.C-.Developer.Professional/blob/main/ДЗ2/img/TotalQuantityInStock.png)   
6. Получение 5 самых дорогих товаров
```
SELECT productid, productname, description, price, quantityinstock
FROM Products
ORDER BY Price DESC
LIMIT 5;
```
![alt text](https://github.com/T1m-cpp/Otus.C-.Developer.Professional/blob/main/ДЗ2/img/MostExpensive.png)     
7. Список товаров с количеством менее 5 штук
```
SELECT productid, productname, description, price, quantityinstock
FROM Products
WHERE QuantityInStock < 5;
```
![alt text](https://github.com/T1m-cpp/Otus.C-.Developer.Professional/blob/main/ДЗ2/img/LessThan5.png)  
Данные скрипты представлены в файле QueryScripts.sql
