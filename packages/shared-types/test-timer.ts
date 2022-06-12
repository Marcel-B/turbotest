import { TestType } from "./test-type";

export interface TestTimer {
  text: string;
  type: TestType;
  description: string;
  seconds: number;
}

export default TestTimer;