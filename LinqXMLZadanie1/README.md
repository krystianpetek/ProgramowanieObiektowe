### Klienci i zamówienia - LINQ i XML

> Autor: _Krzysztof Molenda_
>
> Wersja: 1.2 (2019.12.10)

Napisz program, **wykorzystując operatory LINQ**, pobierający ze standardowego wejścia bazę klientów wraz z przypisanymi im zamówieniami i wypisujący na standardowe wyjście listę wszystkich klientów, którzy złożyli przynajmniej jedno zamówienie w podanym roku.

Baza klientów jest niepusta i zapisana w formacie XML (patrz przykład). Może się zdarzyć, że klienci nie mają żadnych zamówień.

Standardowe wejście:

* w pierwszym wierszu: rok, dla którego należy wykonać wyszukiwanie,
* w kolejnych wierszach: kod XML bazy.

**Przykład:**

```xml
2014
<Customers>
  <Customer>
    <CustomerID>KRAHA</CustomerID>
    <CompanyName>Krakowski Handelek</CompanyName>
    <City>Krakow</City>
    <Country>Poland</Country>
    <Orders></Orders>
  </Customer>
  <Customer>
    <CustomerID>ANATR</CustomerID>
    <CompanyName>Ana Trujillo Emparedados y helados</CompanyName>
    <City>Mexico</City>
    <Country>Mexico</Country>
    <Orders>
      <Order>
        <OrderID>10308</OrderID>
        <OrderDate>2014-09-18T00:00:00</OrderDate>
        <Total>88.80</Total>
      </Order>
    </Orders>
  </Customer>
  <Customer>
    <CustomerID>ANTON</CustomerID>
    <CompanyName>Antonio Moreno Taqueria</CompanyName>
    <City>Rio de Janeiro</City>
    <Country>Brazil</Country>
    <Orders>
      <Order>
        <OrderID>10365</OrderID>
        <OrderDate>2014-11-27T00:00:00</OrderDate>
        <Total>403.20</Total>
      </Order>
      <Order>
        <OrderID>10507</OrderID>
        <OrderDate>2015-04-15T00:00:00</OrderDate>
        <Total>749.06</Total>
      </Order>
    </Orders>
  </Customer>
</Customers>
```

Na standardowe wyjście wypisz - w oddzielnych wierszach - nazwy firm (`CompanyName`), które złożyły przynajmniej jedno zamówienie w podanym roku. Wynik posortuj rosnąco najpierw według kraju (`Country`), następnie według miasta (`City`) i na końcu, według nazwy firmy (`CompanyName`).

Jeśli nie będzie firm spełniających podane kryteria, wypisz słowo `empty`.

Dla powyższego przykładu program wypisze:

```plaintext
Antonio Moreno Taqueria
Ana Trujillo Emparedados y helados
```

Gdyby w powyższym przykładzie podano rok 2018, program wypisałby tylko słowo `empty`.
