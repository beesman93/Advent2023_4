List<string> lines = new List<string>();
using (StreamReader reader = new StreamReader(args[0]))
{
    while (!reader.EndOfStream)
    {
        lines.Add(reader.ReadLine());
    }
}

part1();
part2();

void part1()
{
    int runTotal = 0;
    List<Tuple<int, int>> rodeos = new List<Tuple<int, int>>();

    foreach (var line in lines)
    {
        int wincount = 0;

        List<string> elfSplit = line.Split(':').ToList<string>();

        string? card = elfSplit[0].Trim();
        string? nums = elfSplit[1].Trim();

        //int card_id = Convert.ToInt32(card.Split(' ')[1]);

        List<string> winningNums = nums.Split('|')[0].Split(' ').ToList();
        List<string> myNums = nums.Split('|')[1].Split(' ').ToList();

        foreach (var num in winningNums)
        {
            foreach (var num2 in myNums)
            {
                if (num != "" && num2 != "")

                {
                    if (num == num2)
                    {
                        if (wincount == 0)
                            wincount=1;
                        else
                            wincount *= 2;
                    }
                }
            }
        }
        runTotal += wincount;

    }
    Console.WriteLine(runTotal);
}

void part2()
{
    int runTotal = 0;

    List<Tuple<int, int>> rodeos = new List<Tuple<int, int>>();

    foreach (var line in lines)
    {

        int howManyTimesDoIrunYou = 1;

        int wincount = 0;

        List<string> elfSplit = line.Split(':').ToList<string>();

        string? card = elfSplit[0].Trim();
        string? nums = elfSplit[1].Trim();

        //int card_id = Convert.ToInt32(card.Split(' ')[1]);

        List<string> winningNums = nums.Split('|')[0].Split(' ').ToList();
        List<string> myNums = nums.Split('|')[1].Split(' ').ToList();

        foreach (var num in winningNums)
        {
            foreach (var num2 in myNums)
            {
                if (num != "" && num2 != "")

                {
                    if (num == num2)
                    {
                        //if (wincount == 0)
                        wincount++;
                        //else
                        //   wincount *= 2;
                    }
                }
            }
        }

        for (int i = 0; i < rodeos.Count; i++)
        {
            if (rodeos[i].Item1 > 0)
            {
                rodeos[i] = new Tuple<int, int>(rodeos[i].Item1 - 1, rodeos[i].Item2);
                howManyTimesDoIrunYou += rodeos[i].Item2;
            }
        }

        rodeos.Add(new Tuple<int, int>(wincount, howManyTimesDoIrunYou));

        runTotal += howManyTimesDoIrunYou;

    }
    Console.WriteLine(runTotal);
}