void fileRead(string filename)    // Метод для чтения файла
{
    string line;
    StreamReader fr = new StreamReader(filename);   // Открыть для чтения

    Console.WriteLine("*******************");   // Отбивка
    Console.WriteLine("FromFile:\n\n");
    while((line = fr.ReadLine()) != null)   // Цикл чтения
    {
        Console.WriteLine(line);
    }
    fr.Close();
}

void fileWrite(string text, string filename)    // Метод для чтения файла
{
    StreamWriter fw = File.AppendText(filename);    // Открыть файл для добавления текста
    fw.Write(text);     // Пишем текст, переданный в аргументах
    fw.Close();     // Закрыть файл
    fileRead(filename);     // Вызов метода для чтения файла (для проверки)
}

void fileUpdate(string filename)    // Метод для ввода текста для дописи при желании
{
    
    string line = $"File updated: {DateTime.Now}";  // Заголовок дописи
    Console.Write("Do You want to update a file? (y/n) ");
    string answer = Console.ReadLine().ToLower();
    if(answer == "y")
    {
        Console.Write("Enter Your text: ");     // Ввод дописи
        line += "\n" + Console.ReadLine() + "\n\n";     // Формирование строки дописи
        fileWrite(line, filename);  // Вызов метода для записи

    }
    else
        if(answer == "n")
        {
            Console.WriteLine("Ok. Bye.");  // До свиданья =)
            return;
        }
    else
    {
        Console.WriteLine("I don't understand. Bye.");  // Ошибочный ввод -- до свиданья =)
        return;
    }
}

void Main()
{
    Console.WriteLine("FileWork");  // Вывод названия проекта

    const string fileName = "file.txt";  // Имя файла определил как константу
    if(!File.Exists(fileName))  // Проверка на существование файла
    {
        File.Create(fileName).Close();  // Не существует -- создаем и сразу закрываем
        string line = $"File created: {DateTime.Now}\n\n";  // Заголовок файла 
        Console.WriteLine(line);    // Вывод заголовка
        fileWrite(line, fileName);  // Вызов метода для записи в файл с заголовком в качестве аргумента
        Console.WriteLine("\n\n");
        fileUpdate(fileName);   // Вызов метода для дописи в файл
    }
    else
    {
        fileRead(fileName);     // Вызов метода чтения файла
        fileUpdate(fileName);   // Вызов метода дописи файла
    }
}

Main();     // Вызов основного метода