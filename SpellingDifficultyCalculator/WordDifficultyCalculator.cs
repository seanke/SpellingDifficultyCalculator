
namespace SpellingDifficultyCalculator;

public static class WordDifficultyCalculator
{
    public static int CalculateDifficulty(string word)
    {
        if (string.IsNullOrEmpty(word)) return 1;

        var difficulty = 0;
        word = word.ToLower();

        // Calculate based on length
        var lengthScore = Math.Min(word.Length * 10, 300); // Max 300 points for length
        difficulty += lengthScore;

        // Calculate syllables (rough estimate)
        var syllables = CountSyllables(word);
        var syllableScore = Math.Min((syllables - 1) * 50, 200); // Max 200 points for syllables
        difficulty += syllableScore;

        // Calculate phoneme-grapheme irregularity
        if (HasIrregularPhonemeGrapheme(word)) difficulty += 100;

        // Calculate homophones (simple example list)
        if (HasHomophones(word)) difficulty += 100;

        // Calculate morphological complexity
        if (HasMorphologicalComplexity(word)) difficulty += 50;

        // Non-native etymology (basic check)
        if (IsNonNativeEtymology(word)) difficulty += 50;

        // Normalize to range 1-999
        difficulty = Math.Max(1, Math.Min(difficulty, 999));
        return difficulty;
    }

    private static int CountSyllables(string word)
    {
        // Rough estimate: each vowel group counts as a syllable
        var count = 0;
        var lastWasVowel = false;
        var vowels = "aeiouy";

        foreach (char c in word)
        {
            if (vowels.Contains(c))
            {
                if (!lastWasVowel)
                {
                    count++;
                    lastWasVowel = true;
                }
            }
            else
            {
                lastWasVowel = false;
            }
        }

        return count == 0 ? 1 : count;
    }

    private static bool HasIrregularPhonemeGrapheme(string word)
    {
        // Example irregular words
        string[] irregularWords = ["colonel", "knight", "rendezvous", "queue"];
        return irregularWords.Contains(word);
    }

    private static bool HasHomophones(string word)
    {
        // Example homophones list (could be expanded)
        string[] homophones = ["their", "there", "they're", "to", "too", "two", "your", "you're"];
        return homophones.Contains(word);
    }

    private static bool HasMorphologicalComplexity(string word)
    {
        // Simple check for common prefixes and suffixes
        string[] prefixes = ["un", "dis", "re", "pre"];
        string[] suffixes = ["ing", "ed", "ly", "able"];

        return prefixes.Any(word.StartsWith) || suffixes.Any(word.EndsWith);
    }

    private static bool IsNonNativeEtymology(string word)
    {
        // Simple check for common non-native patterns
        string[] nonNativePatterns = ["eau", "que", "oui"];
        return nonNativePatterns.Any(word.Contains);
    }
}