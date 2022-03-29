namespace Zadanie3.Device
{
    public interface IDevice
    {
        /// <summary>
        /// Przechowuje możliwe stany urządzeń
        /// </summary>
        public enum State
        {
            ON,
            OFF
        };

        /// <summary>
        /// Uruchamia urządzeniem zmienia stan na ON
        /// </summary>
        void PowerOn();

        /// <summary>
        /// Wyłącza urządzenie, zmienia stan na OFF
        /// </summary>
        void PowerOff();

        /// <summary>
        /// Zwraca aktualny stan urządzenia
        /// </summary>
        State GetState(); // zwraca aktualny stan urządzenia

        /// <summary>
        /// Przechowuje aktualną liczbę uruchomień urządzenia
        /// </summary>
        int Counter { get; }
    }
}