class Solution
{

    /*
    Input: words = [book, bake, bear], order =  “oabcdefghijklmnpqrstuvwxyz”
    return true
    
    Input: words = ["word","world","row"], order = "worldabcefghijkmnpqstuvxyz" 
    return false
    
    [1,2,3,4,5] 
    [1,4,2,3,5]
       ^ ^
    */

    public bool IsSorted(string[] words, string order)
    {
        // Create a mapping from character to its index in the custom order for quick lookup
        Dictionary<char, int> orderMap = new Dictionary<char, int>();

        for (int i = 0; i < order.Length; i++)
        {
            orderMap[order[i]] = i;
        }

        // Check each pair of adjacent words to see if they are in the correct order
        for (int i = 0; i < words.Length - 1; i++)
        {
            if (!IsLessOrEqual(words[i], words[i + 1], orderMap))
            {
                return false;
            }
        }

        return true;
    }

    // Helper method to compare two words according to the custom alphabet order
    private bool IsLessOrEqual(string word1, string word2, Dictionary<char, int> orderMap)
    {
        int i = 0, j = 0;

        while (i < word1.Length && j < word2.Length)
        {
            // Get the rank of characters from the custom order
            int rank1 = orderMap[word1[i]];
            int rank2 = orderMap[word2[j]];

            // Compare the ranks to determine order
            if (rank1 < rank2)
            {
                return true;
            }

            if (rank1 > rank2)
            {
                return false;
            }

            // Move to the next character if ranks are equal
            i++;
            j++;
        }

        // If the first word is shorter than the second word, it is considered less or equal
        return i == word1.Length;
    }

    static void Main(String[] args)
    {
        Solution test = new Solution();

        // Test case: Should return true since the words are in correct custom alphabetical order
        Console.WriteLine(test.IsSorted(new string[] { "book", "bake", "bear" }, "oabcdefghijklmnpqrstuvwxyz"));

        // Test case: Should return false since the words are not in correct custom alphabetical order
        Console.WriteLine(test.IsSorted(new string[] { "word", "world", "row" }, "worldabcefghijkmnpqstuvxyz"));
    }
}
