// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameData.cs" company="">
//   
// </copyright>
// <summary>
//   The game data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Minesweeper.Models
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    using Minesweeper.Models.Exceptions;

    /// <summary>
    ///     The game data.
    /// </summary>
    public static class MinesweeperGameData
    {
        /// <summary>
        /// The save.
        /// </summary>
        /// <param name="serializableObject">
        /// The serializable object.
        /// </param>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        public static void Save<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null)
            {
                return;
            }

            try
            {
                var xmlDocument = new XmlDocument();
                var serializer = new XmlSerializer(serializableObject.GetType());
                using (var stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch (Exception e)
            {
                throw new InvalidPlayerOperation("Cannot save data!");
            }
        }

        /// <summary>
        /// The load.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public static T Load<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return default(T);
            }

            var objectOut = default(T);

            try
            {
                var attributeXml = string.Empty;

                var xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                var xmlString = xmlDocument.OuterXml;

                using (var read = new StringReader(xmlString))
                {
                    var outType = typeof(T);

                    var serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception)
            {
                throw new InvalidPlayerOperation("Cannot load data!");
            }

            return objectOut;
        }
    }
}