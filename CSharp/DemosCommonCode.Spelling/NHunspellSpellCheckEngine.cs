using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Vintasoft.Imaging.Spelling;


namespace DemosCommonCode.Spelling
{
    /// <summary>
    /// Represents the "Hunspell" spell check engine.
    /// </summary>
    public class NHunspellSpellCheckEngine : ISpellCheckEngine
    {

        #region Constants

        /// <summary>
        /// The filename template of the custom dictionary.
        /// </summary>
        const string CUSTOM_DICTIONARY_FILENAME_TEMPLATE = "NHunspell_{0}_CustomDict.txt";

        #endregion



        #region Fields

        /// <summary>
        /// The "Hunspell" engine.
        /// </summary>
        NHunspell.Hunspell _hunspell;

        /// <summary>
        /// The dictionary for custom words.
        /// </summary>
        Dictionary<string, bool> _customDictionary = new Dictionary<string, bool>();

        /// <summary>
        /// The available symbols for language.
        /// </summary>
        Dictionary<char, bool> _availableSymbols = new Dictionary<char, bool>();

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NHunspellSpellCheckEngine"/> class.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if
        /// <i>language</i> is <b>null</b> or <b>empty</b>.</exception>
        public NHunspellSpellCheckEngine(string language)
        {
            // if language is not correct
            if (string.IsNullOrEmpty(language))
                throw new ArgumentNullException();

            // save languages
            _languages = new string[] { language };

            string affixFileDataPath = language + ".aff";
            // load affix data
            byte[] affixFileData = DemosResourcesManager.GetExternalResourceAsBytes(affixFileDataPath);


            string dictionaryFileDataPath = language + ".dic";
                // load dictionary data
            byte[] dictionaryFileData = DemosResourcesManager.GetExternalResourceAsBytes(dictionaryFileDataPath);

            // create engine
            _hunspell = new NHunspell.Hunspell(affixFileData, dictionaryFileData);

            // load available symbols of language
            InitializeAvailableSymbols(language);

            // load custom words dictionary
            LoadCustomWordsDictionary();
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets the name of spell check engine.
        /// </summary>
        public string Name
        {
            get
            {
                return string.Format("NHunspell ({0})", _languages[0]);
            }
        }

        string[] _languages;
        /// <summary>
        /// Gets a list of languages, which are supported by this spell check engine.
        /// </summary>
        public IList<string> Languages
        {
            get
            {
                return _languages;
            }
        }

        bool _isEnabled = true;
        /// <summary>
        /// Gets or sets a value indicating whether
        /// the spell check engine is enabled.
        /// </summary>
        /// <value>
        /// <b>True</b> - the spell check engine is enabled;
        /// <b>false</b> - the spell check engine is NOT enabled.
        /// </value>
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Spells the specified word.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns>
        /// <b>True</b> if word is correct; otherwise, <b>false</b>.
        /// </returns>
        public bool Spell(string word)
        {
            // if spell check engine is not enabled
            if (!IsEnabled)
                return false;

            return _hunspell.Spell(word);
        }

        /// <summary>
        /// Returns a list of suggestions for the specified (misspelled) word.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns>
        /// A list of suggestions for the specified (misspelled) word.
        /// </returns>
        public IList<string> Suggest(string word)
        {
            // if spell check engine is not enabled
            if (!IsEnabled)
                return new List<string>();

            return _hunspell.Suggest(word);
        }

        /// <summary>
        /// Adds the specified word to the internal dictionary.
        /// </summary>
        /// <param name="word">The word to add.</param>
        /// <returns>
        /// <b>True</b> if the word was successfully added; otherwise, <b>false</b>.
        /// </returns>
        public bool Add(string word)
        {
            // if spell check engine is not enabled
            if (!IsEnabled)
                return false;

            if (_hunspell.Add(word))
            {
                _customDictionary.Add(word, false);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified word can be added to the internal dictionary.
        /// </summary>
        /// <param name="word">The word to add.</param>
        /// <returns>
        /// <b>True</b> if the word can be added; otherwise, <b>false</b>.
        /// </returns>
        public bool CanAdd(string word)
        {
            // if spell check engine is not enabled
            if (!IsEnabled)
                // word cannot be added to the internal dictionary
                return false;

            // for each symbol in word
            foreach (char symbol in word)
            {
                // if symbol is letter
                if (char.IsLetter(symbol))
                {
                    // if symbol is NOT contained in list of available symbols
                    if (!_availableSymbols.ContainsKey(symbol))
                        // word cannot be added to the internal dictionary
                        return false;
                }
            }

            // word can be added to the internal dictionary
            return true;
        }

        /// <summary>
        /// Removes the specified word from the internal dictionary.
        /// </summary>
        /// <param name="word">The word to remove.</param>
        /// <returns>
        /// <b>True</b> if the word was successfully removed; otherwise, <b>false</b>.
        /// </returns>
        public bool Remove(string word)
        {
            // if spell check engine is not enabled
            if (!IsEnabled)
                return false;

            _customDictionary.Remove(word);
            return _hunspell.Remove(word);
        }

        /// <summary>
        /// Releases all resources used by this spell check engine.
        /// </summary>
        public void Dispose()
        {
            if (_hunspell != null)
            {
                _hunspell.Dispose();
                _hunspell = null;
            }

            SaveCustomWordsDictionary();
        }

        /// <summary>
        /// Saves the changes in custom words dictionary.
        /// </summary>
        public void SaveChanges()
        {
            SaveCustomWordsDictionary();
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Initializes available symbols of language.
        /// </summary>
        /// <param name="language">The language.</param>
        private void InitializeAvailableSymbols(string language)
        {
            _availableSymbols.Clear();

            switch (language.ToUpperInvariant())
            {
                case "EN_US":
                    for (int ch = (int)'A'; ch <= (int)'Z'; ch++)
                        _availableSymbols.Add((char)ch, false);
                    for (int ch = (int)'a'; ch <= (int)'z'; ch++)
                        _availableSymbols.Add((char)ch, false);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Returns path to a custom words dictionary.
        /// </summary>
        /// <returns>
        /// The path to a custom words dictionary.
        /// </returns>
        private string GetCustomWordsDictionaryPath()
        {
            string pathToAssembly = Path.GetDirectoryName(typeof(NHunspellSpellCheckEngine).Assembly.Location);

            string fileName = string.Format(CUSTOM_DICTIONARY_FILENAME_TEMPLATE, _languages[0]);

            return Path.Combine(pathToAssembly, fileName);
        }

        /// <summary>
        /// Loads the custom words dictionary.
        /// </summary>
        private void LoadCustomWordsDictionary()
        {
            _customDictionary.Clear();

            try
            {
                // get path to custom words dictionary
                string pathToDictionary = GetCustomWordsDictionaryPath();

                // if file exists
                if (File.Exists(pathToDictionary))
                {
                    // load words
                    string[] words = File.ReadAllLines(pathToDictionary, Encoding.UTF8);

                    // for each word
                    foreach (string word in words)
                    {
                        // if word is added
                        if (_hunspell.Add(word))
                            // add word to the custom dictionary
                            _customDictionary.Add(word, false);
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Saves the custom words dictionary.
        /// </summary>
        private void SaveCustomWordsDictionary()
        {
            try
            {
                // get path to the custom words dictionary
                string pathToDictionary = GetCustomWordsDictionaryPath();


                if (_customDictionary.Count > 0)
                {
                    // get custom words
                    string[] words = new string[_customDictionary.Count];
                    _customDictionary.Keys.CopyTo(words, 0);

                    // save custom words to a file
                    File.WriteAllLines(pathToDictionary, words, Encoding.UTF8);
                }
                else
                {
                    if (File.Exists(pathToDictionary))
                        File.Delete(pathToDictionary);
                }
            }
            catch
            {
            }
        }

        #endregion

        #endregion

    }
}
