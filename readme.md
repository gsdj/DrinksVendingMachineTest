Проект разработан в среде Visual Studio 2019.

Доступ в административную панель по ключу - 12345.

Выполненные необязательные требования:
-При возврате сдачи показывать количество и номинал монет.

ApplicationAcontext.cs - контекст данных.

Модели:
Coin.cs - модель монет(номинал, количество, сумма, признак доступности),

DrinkType.cs - тип напитков(Газ. вода, соки и тд.). 
(Наименование, описание, зависимая сущность DrinkGroup(содержит список группы напитков)).

DrinkGroup.cs - группа напитков по производителям(Coca-Cola, Fanta и тд.). 
(Наименование, кол-во содержащихся напитков,зависимая сущность Drink(содержит список напитков)).
Зависит от DrinkType.

Drink.cs - модель напитка(Coca-Cola Zero, Coca-Cola Classic).
Наименование,Описание,Объем,Цена,Количетсво, признак доступности, путь к для присоединения изображения.
Зависит от DrinkGroup.

Image.cs - модель изображения(Имя,путь).

DrinksBuyViewModel.cs - модель представления, для отображения на странице монет и напитков.
Содержит список Coin.cs и список Drink.cs
(Список монет,список напитков).

BuyModel.cs - модель покупки напитка.
(Id напитка, Coin(1,2,5,10) - кол-во монет каждого номинала в монетоприемнике, Sum - сумма монет в монетоприемнике)/

BuyResult.cs - модель результата покупки напитка.
Содержит Drinks.cs и список CoinsChange.cs
Содержит информацию о купленом напитке и сдачу в виде количества, номинала монет и суммы.

CoinsChange.cs - модель монет для выдачи сдачи.
Номинал,Количество и сумма монет.  

DrinkEditViewModel.cs - модель редактирования напитка.
Содержит Drink.cs и список Image.cs