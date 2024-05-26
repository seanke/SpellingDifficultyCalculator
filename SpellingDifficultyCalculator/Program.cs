using SpellingDifficultyCalculator;

Console.WriteLine("Enter a word to calculate its difficulty:");

while (true)
{
    var word = Console.ReadLine();
    var difficulty = WordDifficultyCalculator.CalculateDifficulty(word);
    Console.WriteLine($"The difficulty of the word '{word}' is: {difficulty}");
}