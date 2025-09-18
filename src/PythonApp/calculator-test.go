package stringcalculator

import (
	"testing"
)

func TestEmptyStringReturnsZero(t *testing.T) {
	var result = Add("", DummyLogger, nil)
	if result != 0 {
		t.Error("Empty String Should be Zero")
	}
}

func TestSingleDigit(t *testing.T) {
	cases := []struct {
		input    string
		expected int
	}{
		{input: "5", expected: 5},
		{input: "1", expected: 1},
	}

	for _, tc := range cases {
		t.Run(tc.input, func(t *testing.T) {
			actual := Add(tc.input, DummyLogger, nil)
			if actual != tc.expected {
				t.Errorf("For input %v, expected %q, but got %q", tc.input, tc.expected, actual)
			}
		})
	}
}

func TestTwoDigits(t *testing.T) {
	cases := []struct {
		input    string
		expected int
	}{
		{input: "5,5", expected: 10},
		{input: "1,2", expected: 3},
	}

	for _, tc := range cases {
		t.Run(tc.input, func(t *testing.T) {
			actual := Add(tc.input, DummyLogger, nil)
			if actual != tc.expected {
				t.Errorf("For input %v, expected %q, but got %q", tc.input, tc.expected, actual)
			}
		})
	}
}

func TestArbitraryDigits(t *testing.T) {
	cases := []struct {
		input    string
		expected int
	}{
		{input: "1,2,3,4,5,6,7,8,9", expected: 45},
	}

	for _, tc := range cases {
		t.Run(tc.input, func(t *testing.T) {
			actual := Add(tc.input, DummyLogger, nil)
			if actual != tc.expected {
				t.Errorf("For input %v, expected %q, but got %q", tc.input, tc.expected, actual)
			}
		})
	}
}

func TestMixedDelimeters(t *testing.T) {
	cases := []struct {
		input    string
		expected int
	}{
		{input: "1,2\n3", expected: 6},
	}

	for _, tc := range cases {
		t.Run(tc.input, func(t *testing.T) {
			actual := Add(tc.input, DummyLogger, nil)
			if actual != tc.expected {
				t.Errorf("For input %v, expected %q, but got %q", tc.input, tc.expected, actual)
			}
		})
	}
}

func TestCustomDelimeter(t *testing.T) {
	cases := []struct {
		input    string
		expected int
	}{
		{input: "//;\n1;2;3", expected: 6},
		{input: "//|\n1|2|3", expected: 6},
		{input: "//*\n1,2*3", expected: 6},
	}

	for _, tc := range cases {
		t.Run(tc.input, func(t *testing.T) {
			actual := Add(tc.input, DummyLogger, nil)
			if actual != tc.expected {
				t.Errorf("For input %v, expected %q, but got %q", tc.input, tc.expected, actual)
			}
		})
	}
}
