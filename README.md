1. Разработать класс Book (ISBN, автор, название, издательство, год издания, количество страниц, цена), переопределив для него необходимые методы класса Object. Для объектов класса реализовать отношения эквивалентности и порядка (используя соответствующие интерфейсы). Для выполнения основных операций со **списком книг**, который **можно загрузить и, если возникнет необходимость, сохранить в некоторое хранилище BookListStorage** разработать класс BookListService (как сервис для работы с **коллекцией книг**) с функциональностью AddBook (добавить книгу, если такой книги нет, в противном случае выбросить исключение); RemoveBook (удалить книгу, если она есть, в противном случае выбросить исключение); FindBookByTag (найти книгу по заданному критерию); SortBooksByTag (отсортировать список книг по заданному критерию), при реализации делегаты не использовать! Работу классов продемонстрировать на примере консольного приложения. В качестве хранилища использовать
    - двоичный файл, для работы с которым использовать **только классы BinaryReader, BinaryWriter**. Хранилище в дальнейшем может измениться/добавиться.
2. Реализовать возможность логирования сообщений различного уровня, предусмотрев возможность использования различных фреймворков для логирования.
3. Для объектов класса Book (ISBN, автор, название, издательство, год издания, количество страниц, цена) реализовать возможность строкового представления различного вида. Например, для объекта со значениями ISBN = 978-0-7356-6745-7, AuthorName  = Jeffrey Richter, Title = CLR via C#, Publisher = Microsoft Press, Year = 2012, NumberOPpages = 826, Price = 59.99$, могут быть следующие варианты:
    - Jeffrey Richter, CLR via C#
    - Jeffrey Richter, CLR via C#, "Microsoft Press", 2012
    - ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, "Microsoft Press", 2012, P. 826.
    - Jeffrey Richter, CLR via C#, "Microsoft Press", 2012
    - ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, "Microsoft Press", 2012, P. 826., 59.99$. и т.д. 
4. Не изменяя класс Book, добавить для объектов данного класса дополнительную возможность форматирования, изначально не предусмотренную классом.  
5. Для реализованных в пп. 3, 4 функциональностей разработать модульные тесты.
