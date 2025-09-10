import { expect, test } from "vitest";
import { add } from "./stringcalculator";

test("single number", () => {
  const result = add("");
  expect(result).toBe(0);
});

test.each([
  { a: "1", expected: 1 },
  { a: "420", expected: 420 },
])("Single Number: add(%s) -> %d", ({ a, expected }) => {
  const result = add(a);
  expect(result).toBe(expected);
});
test.each([
  { a: "1,2", expected: 3 },
  { a: "2,2", expected: 4 },
  { a: "108,2", expected: 110 },
])("Two Numbers: add(%s) -> %d", ({ a, expected }) => {
  const result = add(a);
  expect(result).toBe(expected);
});

test.each([
  { a: "1,2,3", expected: 6 },
  { a: "1,2,3,4,5,6,7,8,9", expected: 45 },
])("Arbitrary Numbers: add(%s) -> %d", ({ a, expected }) => {
  const result = add(a);
  expect(result).toBe(expected);
});

test.each([
  { a: "1,2\n3", expected: 6 },
  { a: "1\n2,3", expected: 6 },
  { a: "1,2\n3,4\n5,6,7,8,9", expected: 45 },
])("Mixed Delimeter Numbers: add(%s) -> %d", ({ a, expected }) => {
  const result = add(a);
  expect(result).toBe(expected);
});
