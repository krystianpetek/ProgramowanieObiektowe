namespace Zadanie4.Device
{
    public interface IDevice
    {
        /// <summary>
        /// Przechowuje możliwe stany urządzeń
        /// </summary>
        public enum State
        {
            ON,
            OFF,
            STANDBY
        };

        /// <summary>
        /// Uruchamia urządzeniem zmienia stan na ON
        /// </summary>
        public void PowerOn()
        {
            SetState(State.ON);
        }
        /// <summary>
        /// Wyłącza urządzenie, zmienia stan na OFF
        /// </summary>
        public void PowerOff()
        {
            SetState(State.OFF);
        }

        /// <summary>
        /// Zwraca aktualny stan urządzenia
        /// </summary>
        State GetState() => state;

        /// <summary>
        /// Przechowuje aktualną liczbę uruchomień urządzenia
        /// </summary>
        int Counter { get; set; }

        /// <summary>
        /// Uruchamia tryb oszczędzania energii urządzenia
        /// </summary>
        void StandbyOn()
        {
            SetState(State.STANDBY);
        }

        /// <summary>
        /// Wyłącza tryb oszczędzania energii urządzenia
        /// </summary>
        void StandbyOff()
        {
            SetState(State.ON);
        }

        /// <summary>
        /// Ustawia stan urządzenia
        /// </summary>
        /// <param name="state"></param>
        abstract protected void SetState(State state);
        public State state { get; set; }
    }
}