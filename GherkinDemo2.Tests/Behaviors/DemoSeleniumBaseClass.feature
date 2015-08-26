Feature: Demo Selenium Base Class
	In order to demonstrate the user of a base class for selenium testing
	As a presenter
	I want to create the following scenarios

@SmokeTest
Scenario: Insert good text and validate
	Given I have entered the text "Success"
	When I submit the text
	Then a success result should show
