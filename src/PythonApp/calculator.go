package stringcalculator

import (
	"strconv"
	"strings"
)

type Logger struct {
	write func(string) error
}

type WebService struct {
	notify func(string) error
}

func Add(numbers string, logger *Logger, webService *WebService) int {
	if numbers == "" {
		return 0
	} else {
		var numbersToProcess string = numbers
		var customDelimiter string = ""

		// Check for custom delimiter
		if strings.HasPrefix(numbers, "//") {
			// Extract custom delimiter and numbers
			delimiterEndIndex := strings.Index(numbers[2:], "\n")
			if delimiterEndIndex != -1 {
				customDelimiter = string(numbers[2])
				numbersToProcess = numbers[2+delimiterEndIndex+1:]
			}
		}

		// Replace all delimiters with commas for consistent splitting
		normalized := strings.ReplaceAll(numbersToProcess, "\n", ",")
		if customDelimiter != "" {
			normalized = strings.ReplaceAll(normalized, customDelimiter, ",")
		}
		parts := strings.Split(normalized, ",")
		sum := 0
		for _, p := range parts {
			num, err := strconv.Atoi(p)
			if err != nil {
				panic("Invalid input: " + p)
			}
			sum += num
		}
		if logger != nil {
			err := logger.write(numbers)
			if err != nil && webService != nil {
				webService.notify(strconv.Itoa(sum))
			}
		}
		return sum
	}
}
