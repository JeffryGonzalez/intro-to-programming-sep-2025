package stringcalculator

import "errors"

var DummyLogger = &Logger{
	write: func(s string) error {
		// Do nothing for testing
		return nil
	},
}

var GrenadeLogger = &Logger{
	write: func(s string) error {
		return errors.New("simulated logging error")
	},
}
