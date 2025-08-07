// Package weather crap.
package weather

// CurrentCondition is a string.
var CurrentCondition string
/* CurrentLocation is another string. */
var CurrentLocation string

// Forecast is a function.
func Forecast(city, condition string) string {
	CurrentLocation, CurrentCondition = city, condition
	return CurrentLocation + " - current weather condition: " + CurrentCondition
}
