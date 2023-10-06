using System.Linq;

namespace ScrambleTMP.Scripts
{
    public static class ScrambleData
    {
        #region Language
        public enum Language
        {
            EN,
            TR,
            IT,
            ES,
            FR,
            DE,
            ALL
        }
        #endregion

        #region Alphabets
        private static char[] _enAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static char[] _trAlphabet = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZabcçdefgğhıijklmnoöprsştuüvyz".ToCharArray();
        private static char[] _itAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static char[] _esAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static char[] _frAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static char[] _deAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzÄÖÜäöüß".ToCharArray();
        private static char[] _allAlphabets => _enAlphabet
                                    .Concat(_trAlphabet)
                                    .Concat(_itAlphabet)
                                    .Concat(_esAlphabet)
                                    .Concat(_frAlphabet)
                                    .Concat(_deAlphabet).ToArray();
        #endregion

        #region Symbols
        private static char[] _symbols = ".,;():=!'^%&?$#@".ToCharArray();
        #endregion

        #region Get
        /// <summary>
        /// Returns the appropriate alphabet based on the specified language.
        /// </summary>
        /// <param name="language">The language for which you want to get the alphabet.</param>
        public static char[] GetAlphabet(Language language)
        {
            return language switch
            {
                Language.EN => _enAlphabet,
                Language.TR => _trAlphabet,
                Language.IT => _itAlphabet,
                Language.ES => _esAlphabet,
                Language.FR => _frAlphabet,
                Language.DE => _deAlphabet,
                Language.ALL => _allAlphabets,
                _ => _allAlphabets
            };
        }

        /// <summary>
        /// Returns an array of symbols.
        /// </summary>
        public static char[] GetSymbols()
        {
            return _symbols;
        }
        #endregion

        #region Check
        /// <summary>
        /// Checks if the given character is a symbol based on the defined symbol set.
        /// </summary>
        /// <param name="character">The character to check.</param>
        /// <returns>True if the character is a symbol; otherwise, false.</returns>
        public static bool IsSymbol(char character)
        {
            return _symbols.Contains(character);
        }
        #endregion
    }
}