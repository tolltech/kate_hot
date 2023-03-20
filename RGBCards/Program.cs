// See https://aka.ms/new-console-template for more information

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