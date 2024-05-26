// See https://aka.ms/new-console-template for more information

using Journeys;

Solution.LoadJourneys();
Console.WriteLine("6.feladat");
Console.WriteLine($"\t{Solution.GetJourneysByPlane().Trim()}");
Console.WriteLine("7.feladat");
Console.WriteLine(Solution.GetJourneysByType());