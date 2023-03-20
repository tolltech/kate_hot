//Simple();
Complex();

void Simple()
{
    var deck = new List<string>();
    for (var i = 1; i <= 10; i++)
    {
        deck.Add($"R{i}");
        deck.Add($"G{i}");
        deck.Add($"B{i}");
        deck.Add($"W{i}");
    }

    var startInput = Console.ReadLine();
    var inputs = startInput.Replace("start ", string.Empty).Split(" ");
    var n = int.Parse(inputs[0]);
    var c = int.Parse(inputs[1]);

    var totalCardCount = deck.Count;
    if (n * c > totalCardCount)
    {
        Console.WriteLine($"Нельзя раздать {n} карт {c} игрокам, т.к. в колоде не хватает карт ({totalCardCount})");
        return;
    }

    var rnd = new Random();
    var players = new string[c];
    for (var player = 0; player < c; player++)
    for (var i = 0; i < n; i++)
    {
        var randomIndex = rnd.Next(deck.Count);
        players[player] = players[player] + " " + deck[randomIndex];
        deck.RemoveAt(randomIndex);
    }

    var getCardCommandStr = Console.ReadLine();
    var getCardCommand = getCardCommandStr.Split(" ")[1];
    var playerNumber = int.Parse(getCardCommand);

    if (playerNumber > c)
    {
        Console.WriteLine($"Нет игрока с номером {playerNumber}. Их всего {c}");
        return;
    }

    Console.WriteLine($"{playerNumber} " + players[playerNumber - 1]);
}

void Complex()
{
    var deck = Enumerable.Range(0, 10)
        .SelectMany(i => new[] { "R", "G", "B", "W" }
            .Select(c => $"{c}{i}"))
        .OrderBy(x => Guid.NewGuid())
        .ToList();

    var startInputs = Console.ReadLine().Split(" ").Where(x => int.TryParse(x, out _)).Select(x => int.Parse(x))
        .ToArray();
    var n = startInputs[0];
    var c = startInputs[1];
    if (n * c > deck.Count)
    {
        Console.WriteLine($"Нельзя раздать {n} карт {c} игрокам, т.к. в колоде не хватает карт ({deck.Count})");
        return;
    }
    
    var players = new string[c];
    for (var i = 0; i < players.Length; i++)
    {
        players[i] = string.Join(" ", deck.Take(n));
        deck.RemoveRange(0, n);
    }
    
    var playerNumber = int.Parse(Console.ReadLine().Split(" ")[1]);
    if (playerNumber > c)
    {
        Console.WriteLine($"Нет игрока с номером {playerNumber}. Их всего {c}");
        return;
    }
    
    Console.WriteLine($"{playerNumber} " + players[playerNumber - 1]);
}