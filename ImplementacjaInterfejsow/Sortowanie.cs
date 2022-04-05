namespace ImplementacjaInterfejsow
{
    internal static class Sortowanie
    {
        public static void Sortuj<T>(this IList<T> lista) where T : IComparable<T>
        {
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 0; j < lista.Count; j++)
                    if (lista[i].CompareTo(lista[j]) < 0)
                        lista.SwapElements(i, j);
            }
        }

        public static void Sortuj<T>(this IList<T> lista, IComparer<T> comparer)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 0; j < lista.Count; j++)
                {
                    if (comparer.Compare(lista[i], lista[j]) < 0)
                        lista.SwapElements(i, j);
                }
            }
        }

        public static void Sortuj<T>(this IList<T> lista, Comparison<T> comparison)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 0; j < lista.Count; j++)
                {
                    if (comparison.Invoke(lista[i], lista[j]) < 0)
                        lista.SwapElements(i, j);
                }
            }
        }

        private static void SwapElements<T>(this IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}