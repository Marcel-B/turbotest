import TestType from "./test-type";

export interface Timer {
  /**
   * Der Name des Timers
   */
  name: string;

  /**
   * Die eingestellten Zeitspanne des Timers
   */
  seconds: number;

  /**
   * Die laufende Zeit
   */
  current: number;

  /**
   * Zeigt an, ob der Alarm ausgelöst werden soll
   */
  ringActive: boolean;

  /**
   * Zeigt an ob die Zeit läuft
   */
  active: boolean;

  /**
   * Der Typ des Timers
   */
  testType: TestType;
}

export default Timer;