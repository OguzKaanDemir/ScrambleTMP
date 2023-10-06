using TMPro;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;

namespace ScrambleTMP.Scripts
{
    public static class Scramble
    {
        /// <summary>
        /// Scrambles the text of a TMP_Text component with the provided target text and options.
        /// </summary>
        /// <param name="text">The TMP_Text component whose text will be scrambled.</param>
        /// <param name="target">The target text to use for scrambling.</param>
        /// <param name="language">The language used for character generation.</param>
        /// <param name="clearText">Determines whether to clear the original text before scrambling (default: true).</param>
        /// <param name="minCount">The minimum number of character scrambles for each character (default: 3).</param>
        /// <param name="maxCount">The maximum number of character scrambles for each character (default: 7).</param>
        /// <param name="duration">The duration (in seconds) between each character scramble (default: 0.08 seconds).</param>
        /// <returns>An awaitable Task.</returns>
        public static async Task ScrambleText(this TMP_Text text, string target, ScrambleData.Language language, bool clearText = true, int minCount = 3, int maxCount = 7, float duration = .08f)
        {
            try
            {
                var totalLength = target.Length + (clearText ? 0 : text.text.Length + 1);
                var originalText = clearText ? "" : text.text + " ";
                var sbText = new StringBuilder(clearText ? SetText(totalLength) : originalText + SetText(totalLength));

                if (totalLength == 0) return;

                minCount = Mathf.Clamp(minCount, 1, maxCount - 1);
                if (minCount == maxCount)
                {
                    minCount = 3;
                    maxCount = 7;
                }

                for (int i = originalText.Length; i < sbText.Length; i++)
                {
                    var character = target[i - originalText.Length];

                    if (character == ' ')
                        continue;

                    var rCount = Random.Range(minCount, maxCount);

                    for (int r = 0; r < rCount; r++)
                    {
                        sbText[i] = ScrambleData.IsSymbol(character) ?
                            GetSymbol() : GetLetter(language);

                        text.text = sbText.ToString();
                        await Task.Delay((int)(1000 * duration));
                    }

                    sbText[i] = character;
                    text.text = sbText.ToString();
                }
            }
            catch { }
        }

        /// <summary>
        /// Scrambles the text of a TextMeshProUGUI component with the provided target text and options.
        /// </summary>
        /// <param name="text">The TextMeshProUGUI component whose text will be scrambled.</param>
        /// <param name="target">The target text to use for scrambling.</param>
        /// <param name="language">The language used for character generation.</param>
        /// <param name="clearText">Determines whether to clear the original text before scrambling (default: true).</param>
        /// <param name="minCount">The minimum number of character scrambles for each character (default: 3).</param>
        /// <param name="maxCount">The maximum number of character scrambles for each character (default: 7).</param>
        /// <param name="duration">The duration (in seconds) between each character scramble (default: 0.08 seconds).</param>
        /// <returns>An awaitable Task.</returns>
        public static async Task ScrambleText(this TextMeshProUGUI text, string target, ScrambleData.Language language, bool clearText = true, int minCount = 3, int maxCount = 7, float duration = .08f)
        {
            try
            {
                var totalLength = target.Length + (clearText ? 0 : text.text.Length + 1);
                var originalText = clearText ? "" : text.text + " ";
                var sbText = new StringBuilder(clearText ? SetText(totalLength) : originalText + SetText(totalLength));

                if (totalLength == 0) return;

                minCount = Mathf.Clamp(minCount, 1, maxCount - 1);
                if (minCount == maxCount)
                {
                    minCount = 3;
                    maxCount = 7;
                }

                for (int i = originalText.Length; i < sbText.Length; i++)
                {
                    var character = target[i - originalText.Length];

                    if (character == ' ')
                        continue;

                    var rCount = Random.Range(minCount, maxCount);

                    for (int r = 0; r < rCount; r++)
                    {
                        sbText[i] = ScrambleData.IsSymbol(character) ?
                            GetSymbol() : GetLetter(language);

                        text.text = sbText.ToString();
                        await Task.Delay((int)(1000 * duration));
                    }

                    sbText[i] = character;
                    text.text = sbText.ToString();
                }
            }
            catch { }
        }

        /// <summary>
        /// Sets a text with a specified number of spaces.
        /// </summary>
        /// <param name="count">The number of spaces in the text.</param>
        /// <returns>A string containing the specified number of spaces.</returns>
        private static string SetText(int count)
        {
            string s = "";
            for (int i = 0; i < count; i++)
                s += " ";
            return s;
        }

        /// <summary>
        /// Generates and returns a random letter based on the specified language.
        /// </summary>
        /// <param name="language">The language used for letter generation.</param>
        /// <returns>A randomly generated letter.</returns>
        private static char GetLetter(ScrambleData.Language language)
        {
            var alphabet = ScrambleData.GetAlphabet(language);

            var randIndex = Random.Range(0, alphabet.Length - 1);
            var randomValue = alphabet[randIndex];
            return randomValue;
        }

        /// <summary>
        /// Generates and returns a random symbol.
        /// </summary>
        /// <returns>A randomly generated symbol.</returns>
        private static char GetSymbol()
        {
            var symbols = ScrambleData.GetSymbols();

            var randIndex = Random.Range(0, symbols.Length - 1);
            var randomValue = symbols[randIndex];
            return randomValue;
        }
    }
}