# Поддержка и тестирование программных модулей
## Практическая работа №6.1 
Создание автоматизированных unit-тестов

---
### Цель работы:
Провести тестирование разработанных программных модулей с использованием средств автоматизации Microsoft Visual Studio методом "белого ящика".

---
### Ход работы:
#### 1. Результат работы приложения
<img width="568" height="296" alt="Image" src="https://github.com/user-attachments/assets/d1968e5c-0532-4708-9093-2538ef7e2051"/>

> Логика реализована корректно:
> > На счету было 11,99 денег
> 
> > Положили 5,77
> 
> > Сняли 11,22
> 
> В итоге осталось 6,54 - как и показано на скриншоте


#### 2. Результаты теста Debit 
<img width="1170" height="332" alt="image" src="https://github.com/user-attachments/assets/0db9017d-a161-4a8d-93d0-863e840628fa" />

> Все тесты, описанные в инструкции, реализованы и пройдены успешно

#### 3. Результаты теста Credit
**3.1. Тесты, аналогичные тестам метода Debit (успешные)**
<img width="854" height="298" alt="Image" src="https://github.com/user-attachments/assets/9dcaf189-df76-4b26-ad3c-d4c9de4ab885" />

* `Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange`	- при отрицательной сумме выбрасывается исключение
* `Credit_WithValidAmount_UpdatesBalance`	- баланс увеличивается при корректной сумме
* `Credit_WithZeroAmount_DoesNotChangeBalance` - баланс не меняется при пополнении на 0

**3.2. Уникальные тесты**

**3.2.1 Тесты значений и пополнений (успешные)**
<img width="852" height="301" alt="Image" src="https://github.com/user-attachments/assets/eef5b9c2-7d75-422d-b333-ef11c526e5fc" />

* ``Credit_ManySmallCredits_ShouldAccumulateCorrectly`` - пополнение баланса много раз небольшими суммами
* ``Credit_ShouldNotAffectOtherAccounts`` - пополнение баланса разных аккаунтов независимо друг от друга
* ``Credit_WithLargeAmount_UpdatesBalanceCorrectly`` - пополнение баланса очень большой суммой

**3.2.2 Тест сообщения об ошибке: пополнение меньше нуля**

``Credit_WhenAmountIsLessThanZero_ShouldContainCorrectErrorMessage``
<img width="590" height="239" alt="Image" src="https://github.com/user-attachments/assets/93623aea-ac1f-4c97-9f15-7e2affe1d5b5" />

*Ошибка:*
<img width="1307" height="262" alt="Image" src="https://github.com/user-attachments/assets/bfd25bff-3500-4f6b-b666-ba41e72d074e" />

**Исправление:** добавлена глобальная строковая переменная сообщения об отрицательном пополнении, и теперь она вызывается в качестве исключения

<img width="799" height="238" alt="Image" src="https://github.com/user-attachments/assets/0347ed66-e7c9-403e-af0c-38674e8e8f85" />


*Результат теста:*
<img width="929" height="271" alt="Image" src="https://github.com/user-attachments/assets/f57725d2-024f-4f64-9f55-bce2915ca4f8" />

---
### Вывод
В ходе тестирования метода ``Credit`` класса ``BankAccount`` были проверены все ключевые сценарии работы: пополнение положительной суммой, нулем, отрицательной суммой, множественные пополнения и другие.
Результаты тестирования показали, что метод корректно увеличивает баланс при допустимых значениях и выбрасывает исключение при недопустимых. 
* Первоначально один из тестов не прошёл из-за отсутствия информативного сообщения в исключении для отрицательной суммы
* После исправления метода тест был успешно пройден.

Все остальные тесты успешно подтвердили правильность работы метода, что свидетельствует о его стабильности и надежности при различных сценариях использования.
