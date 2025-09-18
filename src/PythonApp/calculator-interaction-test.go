package stringcalculator

import (
	"testing"
)

func TestResponsesAreLogged(t *testing.T) {
	message := ""
	var logger = &Logger{
		write: func(s string) error {
			message = s
			return nil
		},
	}
	Add("12", logger, nil)
	if message != "12" {
		t.Error("Expected log message to be '12', but got", message)
	}
}

func TestWebServiceNotifiedIfLoggerError(t *testing.T) {
	message := ""
	webServiceMock := &WebService{
		notify: func(s string) error {
			message = s
			return nil
		},
	}
	Add("12", GrenadeLogger, webServiceMock)
	if message != "12" {
		t.Error("Expected log message to be '12', but got", message)
	}
}
