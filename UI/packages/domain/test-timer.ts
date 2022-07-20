export type TimerType = string;

export interface TestTimer {
  text: string;
  type: TimerType;
  description: string;
  seconds: number;
}

export default TestTimer;