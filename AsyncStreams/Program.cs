async IAsyncEnumerable<int> GetNumberAsync()
{
    for (int i = 0; i < 10; i++)
    {
        await Task.Delay(100);
        yield return i;
    }
}

Console.WriteLine("Example #1");

await foreach (var i in GetNumberAsync())
{
    Console.WriteLine(i);
}

Console.WriteLine("\nExample #2\n");

Repository repo = new();

await foreach(var data in repo.GetDataAsync())
{
    Console.WriteLine(data);
}

class Repository
{
    string[] data =
    {
        "Понедельник","Вторник","Среда","Четверг","Пятница","Суббота","Воскресенье",
    };

    public async IAsyncEnumerable<string> GetDataAsync()
    {
        for(int i = 0; i < data.Length; i++)
        {          
            await Task.Delay(100);
            yield return "Days of week " + data[i] ;
        }
    }
}