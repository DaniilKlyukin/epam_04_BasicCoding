# Basic Coding_04
**Задание 1.**
Даны два целых знаковых четырех байтовых числа и две позиции битов i и j (i<j). Реализовать алгоритм InsertNumber вставки битов с j-ого по i-ый бит одного числа в другое так, чтобы биты второго числа занимали позиции с бита j по бит i (биты нумеруются справа налево). Разработать модульные тесты (NUnit и(!) MS Unit Test) для тестирования метода.
<br/>[Решение](https://github.com/KaBaN4iK357/epam_04_BasicCoding/blob/382f41b6e625070c0a272c28f6509eaf78a867c1/TasksLibrary/TaskWorker.cs#L56)
 [Тесты MSUnit](https://github.com/KaBaN4iK357/epam_04_BasicCoding/blob/382f41b6e625070c0a272c28f6509eaf78a867c1/Izh_04_Basic_Coding/Izh04BasicCodingTests.cs#L21)
[Тесты NUnit](https://github.com/KaBaN4iK357/epam_04_BasicCoding/blob/382f41b6e625070c0a272c28f6509eaf78a867c1/Izh_04_Basic_Coding/Izh04BasicCodingTests.cs#L31)
<br/>
**Задание 2.**
Реализовать рекурсивный алгоритм поиска максимального элемента в неотсортированном целочисленом массиве.
<br/>[Решение](https://github.com/KaBaN4iK357/epam_04_BasicCoding/blob/382f41b6e625070c0a272c28f6509eaf78a867c1/TasksLibrary/TaskWorker.cs#L18)
[Тесты](https://github.com/KaBaN4iK357/epam_04_BasicCoding/blob/382f41b6e625070c0a272c28f6509eaf78a867c1/Izh_04_Basic_Coding/Izh04BasicCodingTests.cs#L72)
<br/>
**Задание 3.**
Реализовать алгоритм поиска в вещественном массиве индекса элемента, для которого сумма элементов слева и сумма элементов спарава равны. Если такого элемента не существует вернуть null (или -1).
<br/>[Решение](https://github.com/KaBaN4iK357/epam_04_BasicCoding/blob/382f41b6e625070c0a272c28f6509eaf78a867c1/TasksLibrary/TaskWorker.cs#L31)
[Тесты](https://github.com/KaBaN4iK357/epam_04_BasicCoding/blob/382f41b6e625070c0a272c28f6509eaf78a867c1/Izh_04_Basic_Coding/Izh04BasicCodingTests.cs#L87)
<br/>
**Задание 4.**
Реализовать алгоритм конкатенации двух строк, содержащих только символы латинского алфавита, исключая повторяющиеся символы.
<br/>[Решение](https://github.com/KaBaN4iK357/epam_04_BasicCoding/blob/382f41b6e625070c0a272c28f6509eaf78a867c1/TasksLibrary/TaskWorker.cs#L82)
[Тесты](https://github.com/KaBaN4iK357/epam_04_BasicCoding/blob/382f41b6e625070c0a272c28f6509eaf78a867c1/Izh_04_Basic_Coding/Izh04BasicCodingTests.cs#L97)
<br/>
**Задание 5.**
Реализовать метод FindNextBiggerNumber, который принимает положительное целое число и возвращает ближайшее наибольшее целое, состоящее из цифр исходного числа, и null (или -1), если такого числа не существует.
Добавить к методу FindNextBiggerNumber возможность вернуть время нахождения заданного числа, рассмотрев различные языковые возможности. Разработать модульные тесты (NUnit или MS Unit Test) для тестирования метода.
<br/>[Решение](https://github.com/KaBaN4iK357/epam_04_BasicCoding/blob/382f41b6e625070c0a272c28f6509eaf78a867c1/TasksLibrary/TaskWorker.cs#L93)
[Тесты](https://github.com/KaBaN4iK357/epam_04_BasicCoding/blob/382f41b6e625070c0a272c28f6509eaf78a867c1/Izh_04_Basic_Coding/Izh04BasicCodingTests.cs#L136)
<br/>
**Задание 6.**
Реализовать метод FilterDigit который принимает массив целых чисел и фильтрует его таким образом, чтобы на выходе остались только числа, содержащие заданную цифру (LINQ-запросы не использовать!) Например, для цифры 7, FilterDigit (7,1,2,3,4,5,6,7,68,69,70, 15,17) -> {7, 7, 70, 17}. Разработать модульные тесты (NUnit и MS Unit Test (включая подход DDT)) для тестирования метода.
<br/>[Решение](https://github.com/KaBaN4iK357/epam_04_BasicCoding/blob/382f41b6e625070c0a272c28f6509eaf78a867c1/TasksLibrary/TaskWorker.cs#L122)
[Тесты NUnit](https://github.com/KaBaN4iK357/epam_04_BasicCoding/blob/382f41b6e625070c0a272c28f6509eaf78a867c1/Izh_04_Basic_Coding/Izh04BasicCodingTests.cs#L155)
[Тесты MSUnit DDT](https://github.com/KaBaN4iK357/epam_04_BasicCoding/blob/382f41b6e625070c0a272c28f6509eaf78a867c1/Izh_04_Basic_Coding/Izh04BasicCodingTests.cs#L175)
[Данные для DDT](https://github.com/KaBaN4iK357/epam_04_BasicCoding/blob/master/Izh_04_Basic_Coding/data.csv)
