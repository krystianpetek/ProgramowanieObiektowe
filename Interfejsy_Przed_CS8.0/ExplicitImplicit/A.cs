namespace Interfejsy_CS.ExplicitImplicit
{
    internal class A : IA
    {
        public void M() => Console.WriteLine("Implementacja niejawna (implicit)");

        void IA.M() => Console.WriteLine("Implementacja jawna (explicit)");
    }
}