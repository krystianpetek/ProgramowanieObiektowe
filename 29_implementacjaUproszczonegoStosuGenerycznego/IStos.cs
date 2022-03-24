namespace _29_implementacjaUproszczonegoStosuGenerycznego
{
    /// <summary>
    /// Interfejs stosu (generyczny)
    /// </summary>
    /// <remarks>
    /// Założenia:
    /// 1. Po utworzeniu stos jest pusty
    /// 2. Stos jest pojemnikiem o nieograniczonej pojemności
    /// 3. Próba zdjęcia lub odczytania szczytowego elementu ze stosu pustego zgłasza wyjątek
    /// 4. Push oraz Pop są czynnościami wzajemnie odwrotnymi
    /// </remarks>
    /// <typeparam name="T">dowolny typ wartościowy lub referencyjny</typeparam>
    public interface IStos<T>
    {
        void Push(T value);

        T Peek { get; }

        T Pop();

        int Count { get; }

        // jeśli stos jest pusty zwraca true
        bool IsEmpty { get; }

        void Clear();

        // kopiuje (płytka kopia) i eksportuje stos do tablicy
        T[] ToArray();
    }
}