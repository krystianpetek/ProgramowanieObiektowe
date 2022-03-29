namespace Zadanie3.Document
{
    public interface IDocument
    {
        /// <summary>
        /// Przechowuje możliwe formaty plików
        /// </summary>
        public enum FormatType
        {
            TXT,
            PDF,
            JPG
        }

        /// <summary>
        /// Zwraca typ formatu dokumentu
        /// </summary>
        public FormatType GetFormatType();

        /// <summary>
        /// Zwraca nazwę pliku dokumentu - nie może być `null` ani pusty `string`
        /// </summary>
        public string GetFileName();
    }
}