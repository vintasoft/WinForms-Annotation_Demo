using System;
using System.Collections.Generic;

using Vintasoft.Imaging.Spelling;


namespace DemosCommonCode.Spelling
{
    /// <summary>
    /// Contains collection of helper-algorithms for spell checking.
    /// </summary>
    public class SpellCheckTools
    {

        #region Methods

        #region PUBLIC

        /// <summary>
        /// Creates the spell check manager.
        /// </summary>
        /// <returns>
        /// The spell check manager.
        /// </returns>
        public static SpellCheckManager CreateSpellCheckManager()
        {
            // create engine list
            List<ISpellCheckEngine> engines = new List<ISpellCheckEngine>();

            // add English dictionary
            AddEngine(engines, "en_US");

            // if dictionaries are not created
            if (engines.Count == 0)
                return null;

            // create the spell check manager
            SpellCheckManager spellChecker = new SpellCheckManager();
            // add engines to the manager
            spellChecker.Engines = engines;

            // return the spell check manager
            return spellChecker;
        }

        /// <summary>
        /// Disposes the spell check manager and engines of spell check manager.
        /// </summary>
        /// <param name="manager">The manager to dispose.</param>
        public static void DisposeSpellCheckManagerAndEngines(SpellCheckManager manager)
        {
            if (manager == null)
                return;

            IList<ISpellCheckEngine> engines = manager.Engines;

            manager.Dispose();

            foreach (ISpellCheckEngine engine in engines)
                engine.Dispose();
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Adds the engine to the specified engine list.
        /// </summary>
        /// <param name="engines">The engine list.</param>
        /// <param name="laguageCode">The language code.</param>
        /// <returns>
        ///   <b>True</b> if dictionary is loaded, otherwise <b>false</b>.
        /// </returns>
        private static bool AddEngine(List<ISpellCheckEngine> engines, string languageCode)
        {
            try
            {
                // load and add engine
                engines.Add(new NHunspellSpellCheckEngine(languageCode));
            }
            catch
            {
                return false;
            }
            return true;
        }

        #endregion

        #endregion

    }
}
